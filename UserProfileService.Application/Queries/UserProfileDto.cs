using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserProfileService.Application.Queries
{
    public record UserProfileDto(int Id,string UserName,string Email);
    
}
