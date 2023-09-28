using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.DAL.DTOs
{
    public class TaxCodeDTO
    {
        public string Key { get; set; }
        public string? Value { get; set; }
        public TaxCodeDTO(string key, string value)
        {
            this.Key = key;
            this.Value = value;
        }
    }
}
