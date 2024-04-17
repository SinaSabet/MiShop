using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityService.Application.Service
{
    public interface ITokenService
    {
        string GenerateToken(int userid,string username,string email);
    }
}
