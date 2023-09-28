using api.DAL.Interfaces;
using api.DAL.Models;
using api.DAL.Models.DTOs;
using Humanizer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace api.DAL.Services
{
    public class EntryService : IEntryService
    {
        private UserModel _User;
        private UserManager<UserModel> _UM;
        private readonly IConfiguration _Config;
        private static readonly string JwtProvider = "ValsCandyShelf";
        private static readonly string RefreshToken = "ValsCandyShelfRefreshToken";

        public EntryService(UserManager<UserModel> UM, IConfiguration Config)
        {
            this._UM = UM;
            this._Config = Config;
        }

        public async Task<IEnumerable<IdentityError>> RegisterUser(BaseUserDTO DTO)
        {
            _User = new UserModel(DTO);
            var result = await _UM.CreateAsync(_User, DTO.Password);

            if (DTO.Source == "Developer" && result.Succeeded)
            {
                await _UM.AddToRoleAsync(_User, "Developer");
                await _UM.AddToRoleAsync(_User, "Owner");
                await _UM.AddToRoleAsync(_User, "Manager");
                await _UM.AddToRoleAsync(_User, "Employee");
                await _UM.AddToRoleAsync(_User, "Shopper");
            }
                if (DTO.Source == "Owner" && result.Succeeded)
            {
                await _UM.AddToRoleAsync(_User, "Owner");
                await _UM.AddToRoleAsync(_User, "Manager");
                await _UM.AddToRoleAsync(_User, "Employee");
                await _UM.AddToRoleAsync(_User, "Shopper");
            }
            if (DTO.Source == "Manager" && result.Succeeded)
            {

                await _UM.AddToRoleAsync(_User, "Manager");
                await _UM.AddToRoleAsync(_User, "Employee");
                await _UM.AddToRoleAsync(_User, "Shopper");
            }

            if (DTO.Source == "Employee" && result.Succeeded)
            {
                await _UM.AddToRoleAsync(_User, "Employee");
                await _UM.AddToRoleAsync(_User, "Shopper");
            }
            if (DTO.Source == "Shopper" && result.Succeeded) await _UM.AddToRoleAsync(_User, "Shopper");

            return result.Errors;
        }

        public async Task<JwtDTO> Login(BaseUserDTO DTO)
        {
            var _User = await _UM.FindByEmailAsync(DTO.Email);

            if (_User is null) return null;

            bool validPassword = await _UM.CheckPasswordAsync(_User, DTO.Password);

            if (!validPassword) return null;

            var givenToken = await NewJwt();

            return new JwtDTO { jwToken = givenToken, refreshToken = await NewRefreshToken() };
        }

        public async Task<JwtDTO> VerifyRefreshToken(JwtDTO DTO)
        {
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var tokenContent = jwtSecurityTokenHandler.ReadJwtToken(DTO.jwToken);

            var Id = tokenContent.Claims.ToList().FirstOrDefault(found => found.Type == JwtRegisteredClaimNames.Sub)?.Value;

            _User = await _UM.FindByIdAsync(Id);

            if (_User == null) return null;

            var isValidRefreshToken = await _UM.VerifyUserTokenAsync(_User, JwtProvider, RefreshToken, DTO.refreshToken);

            if (isValidRefreshToken)
            {
                var newToken = await NewJwt();

                return new JwtDTO
                {
                    jwToken = newToken,
                    refreshToken = await NewRefreshToken()
                };
            }

            await _UM.UpdateSecurityStampAsync(_User);

            return null;
        }

        public async Task<string> NewJwt()
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_Config["JwtSettings:Key"]));

            var userCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var userRoles = await _UM.GetRolesAsync(_User);

            var userRoleClaims = userRoles.Select(role => new Claim(ClaimTypes.Role, role)).ToList();

            /* Below is the method to retrieve claims that are stored in database */
            var userClaims = await _UM.GetClaimsAsync(_User);

            var userClaimsList = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, _User.Id),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            }
            .Union(userClaims)
            .Union(userRoleClaims);

            var newToken = new JwtSecurityToken(
                issuer: _Config["JwtSettings:Issuer"],
                audience: _Config["JwtSettings:Audience"],
                claims: userClaimsList,
                expires: DateTime.Now
                    .AddMinutes(Convert.ToDouble(
                    _Config["JwtSettings:DurationInMinutes"])),

                signingCredentials: userCredentials
                );

            return new JwtSecurityTokenHandler()
                .WriteToken(newToken);
        }

        public async Task<string> NewRefreshToken()
        {
            await _UM.RemoveAuthenticationTokenAsync(_User, JwtProvider, RefreshToken);
            var newToken = await _UM.GenerateUserTokenAsync(_User, JwtProvider, RefreshToken);
            var setToken = await _UM.SetAuthenticationTokenAsync(_User, JwtProvider, RefreshToken, newToken);

            return newToken;
        }

        public string? ParseTokenForUserId(string Jwt)
        {
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var tokenContent = jwtSecurityTokenHandler.ReadJwtToken(Jwt);

            var userId = tokenContent.Claims.ToList().FirstOrDefault(found => found.Type == JwtRegisteredClaimNames.Sub)?.Value;

            if (userId is null) return null;
            else return userId;
        }

        public async Task<List<Claim>> GetRolesById(string UserId)
        {
            _User = await _UM.FindByIdAsync(UserId);

            if (_User is null) return null;

            var userRoles = await _UM.GetRolesAsync(_User);

            var userRoleClaims = userRoles.Select(role => new Claim(ClaimTypes.Role, role)).ToList();

            return userRoleClaims;
        }
    }
}
