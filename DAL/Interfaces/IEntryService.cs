using api.DAL.Models.DTOs;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace api.DAL.Interfaces
{
    public interface IEntryService
    {
        public Task<IEnumerable<IdentityError>> RegisterUser(BaseUserDTO DTO);
        public Task<JwtDTO> Login(BaseUserDTO DTO);
        public Task<JwtDTO> VerifyRefreshToken(JwtDTO DTO);
        public Task<string> NewJwt();
        public Task<string> NewRefreshToken();
        public string? ParseTokenForUserId(string Jwt);
        public Task<List<Claim>> GetRolesById(string UserId);
    }
}
