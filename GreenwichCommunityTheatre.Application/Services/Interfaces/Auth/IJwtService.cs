using GreenwichCommunityTheatre.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenwichCommunityTheatre.Application.Services.Interfaces.Auth
{
    public interface IJwtService
    {
        Task<string> CreateJwtToken(User user);
    }
}
