using api.DAL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.DAL.Models
{
    public class NoteModel
    {
        public string EmployeeEmail { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Text { get; set; }
        public IList<string> Images { get; set; }
        public NoteModel()
        {
            this.CreatedDate = DateTime.Now;
            this.EmployeeEmail = "SystemDefault";
            this.Text = "This is a system generated message";
        }

        public NoteModel(NoteDTO DTO)
        {
            this.CreatedDate = DateTime.Now;
            this.EmployeeEmail = DTO.EmployeeEmail;
            this.Text = DTO.Text;

            /*
             * foreach IFormFile, upload to cloudinary 
             */
            foreach (string Image in DTO.Images)
            {
                this.Images.Add(Image);
            }
        }
    }
}
