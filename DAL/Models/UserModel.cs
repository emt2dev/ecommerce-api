using api.DAL.Models.DTOs;
using Microsoft.AspNetCore.Identity;

namespace api.DAL.Models
{
    public class UserModel : IdentityUser
    {
        public string Currency = "USD";
        public bool IsDeveloper { get; set; }
        public bool IsOwner { get; set; }
        public bool IsManager { get; set; }
        public bool IsEmployee { get; set; }
        public string Name { get; set; }
        public string ShippingAddress { get; set; }

        public UserModel(BaseUserDTO DTO)
        {
            this.Email = DTO.Email;
            this.UserName = DTO.Email;
            this.Currency = "USD";
        }
    }
}
