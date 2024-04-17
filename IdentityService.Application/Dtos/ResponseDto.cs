using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityService.Application.Dtos
{
    public class ResponseDto<T>
    {
        public T Data { get; set; }
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
    }

    public class RegisterResponseDto
    {
        public string Token { get; set; }
        public string Message { get; set; }
        public bool IsSuccess { get; set; }

    }
}
