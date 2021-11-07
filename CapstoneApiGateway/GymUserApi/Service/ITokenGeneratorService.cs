using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace GymUserApi.Service
{
    public interface ITokenGeneratorService
    {
        string GenerateToken(Claim[] authClaims);
    }
}
