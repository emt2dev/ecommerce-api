using apitesting.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apitesting.Models
{
    internal class TaxCodeModel
    {
        public int Id { get; set; }
        public string Key { get; set; }
        public string? Value { get; set; }
        public TaxCodeModel(TaxCodeDTO DTO)
        {
            this.Id = 0;
            this.Key = DTO.Key;
            this.Value = DTO.Value;
        }
    }
}
