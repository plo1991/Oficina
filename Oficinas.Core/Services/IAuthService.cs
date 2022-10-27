using Oficinas.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oficinas.Core.Services
{
    public interface IAuthService
    {
        string GenerateJwtToken(string email, RolesEnum role);
        string ComputeSha256Hash(string password);
    }
}
