using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Model_Validation
{
    public class CustomValidationAttribute : ValidationAttribute
    {
        private readonly string _fieldType;

        public CustomValidationAttribute(string fieldType)
        {
            _fieldType = fieldType;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                var stringValue = value.ToString();

                switch (_fieldType.ToLower())
                {
                    case "username":
                        if (!Regex.IsMatch(stringValue, @"^[a-zA-Z0-9]*$"))
                        {
                            return new ValidationResult("Username must be alphanumeric.");
                        }
                        break;

                    case "email":
                        if (!new EmailAddressAttribute().IsValid(stringValue))
                        {
                            return new ValidationResult("Invalid email format.");
                        }
                        break;

                    case "password":
                        if (stringValue.Length < 6)
                        {
                            return new ValidationResult("Password must be at least 6 characters long.");
                        }
                        break;

                    case "name":
                        if (!Regex.IsMatch(stringValue, @"^[a-zA-Z]+$"))
                        {
                            return new ValidationResult("Name must contain only letters.");
                        }
                        break;

                    case "dateofbirth":
                        if (DateTime.TryParse(stringValue, out var date))
                        {
                            if (date > DateTime.Today)
                            {
                                return new ValidationResult("Date of Birth cannot be in the future.");
                            }
                        }
                        else
                        {
                            return new ValidationResult("Invalid Date of Birth format.");
                        }
                        break;

                    default:
                        return ValidationResult.Success;
                }
            }
            return ValidationResult.Success;
        }
    }
}
