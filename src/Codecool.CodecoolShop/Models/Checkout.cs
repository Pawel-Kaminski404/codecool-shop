using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Codecool.CodecoolShop.Models
{
    public class Checkout : BaseModel
    {
        [Required]
        public string Name { get; set; }
        
        [Required]
        [RegularExpression(@"^(([^<>()[\]\\.,;:\s]+(\.[^<>()[\]\\.,;:\s]+)*)|(.+))((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$")]
        public string Email { get; set; }
        
        [Required]
        [RegularExpression(@"\(?([0-9]{3})\)?([ .-]?)([0-9]{3})\2([0-9]{3})")]
        public string PhoneNumber { get; set; }
        
        [Required]
        public string Address { get; set; }
        
        [Required]
        [RegularExpression(@"^\d{2,5}(?:[-\s]\d{3,4})?$")]
        public string ZipCode { get; set; }
        
        [Required]
        public string Country { get; set; }
        
        [Required]
        public string City { get; set; }
        
        public bool Validate(){
            ValidationContext context = new ValidationContext(this, serviceProvider: null, items: null);
            List<ValidationResult> results = new List<ValidationResult>();
            return Validator.TryValidateObject(this, context, results, true);

        }
        
    }
    
   
}