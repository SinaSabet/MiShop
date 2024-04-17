using IdentityService.Application.Command.UserRegister;
using IdentityService.Application.Dtos;
using Newtonsoft.Json;
using Polly;
using Polly.CircuitBreaker;
using Polly.Retry;
using System.Text;


namespace IdentiyService.Messaging.Http
{
    public class MessagingHttpService : IMessagingHttpService
    {
        private readonly HttpClient _httpClient;
        private AsyncRetryPolicy _retryPolicy;
        private AsyncCircuitBreakerPolicy _circuitBreakerPolicy;
        public MessagingHttpService(HttpClient httpClient)
        {
            _httpClient = httpClient;

            _retryPolicy =  Policy.Handle<Exception>()
                .WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));

            _circuitBreakerPolicy = Policy.Handle<Exception>()
                .CircuitBreakerAsync(1, TimeSpan.FromSeconds(5));
        }

        public async Task<int> CreateUserAsync(UserRegisterCommand data)
        {
            string url = "http://localhost:5296/api/User/CreateUser";

            try
            {
                var response = await _retryPolicy.WrapAsync(_circuitBreakerPolicy).ExecuteAsync(async () =>
                {
                    var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
                    var httpResponse = await _httpClient.PostAsync(url, content);
                    return httpResponse;
                });

                if (response.IsSuccessStatusCode)
                {
                    var responseBody = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<ResponseDto<int>>(responseBody);
                    return result.Data;
                }
                else
                {
                    throw new Exception($"An error occurred while creating the user. StatusCode: {response.StatusCode}, Reason: {response.ReasonPhrase}");
                }
            }
            catch (Exception ex) when (_circuitBreakerPolicy.CircuitState == CircuitState.Open)
            {
                throw new Exception("The circuit breaker is open. Please try again later.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while creating the user.", ex);
            }
        }
    }
}

