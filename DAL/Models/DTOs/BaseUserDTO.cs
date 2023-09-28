using System.ComponentModel.DataAnnotations;

namespace api.DAL.Models.DTOs
{
    public class BaseUserDTO
    {
        public string? Id { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        public string Source { get; set; }
        public string? Currency { get; set; }
        public bool? IsDeveloper { get; set; }
        public bool? IsOwner { get; set; }
        public bool? IsManager { get; set; }
        public bool? IsEmployee { get; set; }
        public string? Name { get; set; }
        public string? ShippingAddress { get; set; }

        public BaseUserDTO() { }
        public BaseUserDTO(UserModel Obj)
        {
            this.Id = Obj.Id;
            this.Email = Obj.Email;
            this.Source = "DTO";
            this.IsDeveloper = Obj.IsDeveloper;
            this.IsOwner = Obj.IsOwner;
            this.IsManager = Obj.IsManager;
            this.IsEmployee = Obj.IsEmployee;

            if(Obj.Name is not null) this.Name = Obj.Name;
            if (Obj.ShippingAddress is not null) this.ShippingAddress = Obj.ShippingAddress;
        }
    }
}
