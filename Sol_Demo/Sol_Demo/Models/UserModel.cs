using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Sol_Demo.Models
{
    public class UserModel
    {
        // https://docs.microsoft.com/en-us/aspnet/core/mvc/models/validation?view=aspnetcore-3.1
        // Pre Defined Data Annotations
        [Required]
        [MaxLength(50, ErrorMessage = "First Name should be less than 50 character")]
        [DisplayName("First Name")]
        public String FirstName { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Last Name should be less than 50 character")]
        [DisplayName("Last Name")]
        public String LastName { get; set; }

        [Required]
        [EmailAddress]
        [DisplayName("Email Id")]
        public String EmailId { get; set; }

        [Required]
        [MaxLength(10, ErrorMessage = "10 digit no allowed only")]
        [MobileNoValidation]
        [DisplayName("Mobile No")]
        public String MobileNo { get; set; }

        private class MobileNoValidation : ValidationAttribute
        {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                ValidationResult validateResult = null;

                if (Convert.ToString(value).StartsWith("0"))
                {
                    validateResult = new ValidationResult("Mobile no does not start with 0");
                }
                else if (Convert.ToString(value).Length != 10)
                {
                    validateResult = new ValidationResult("10 digit no allowed only");
                }
                else
                {
                    validateResult = ValidationResult.Success;
                }
                //else if (Convert.ToString(value).Length != 10)
                //{
                //    validateResult = new ValidationResult("10 digit number allowed only");
                //}

                return validateResult;
            }
        }
    }
}