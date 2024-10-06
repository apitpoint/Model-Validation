using Microsoft.AspNetCore.Mvc;
using Model_Validation.Models;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Model_Validation.Controllers
{
    public class UsersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult UsersRegister()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(UsersModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("UsersRegister"); // Return the same view with validation errors
            }

            // Logic to save user to database (omitted for brevity)

            return RedirectToAction("Success");
        }
        public IActionResult Success()
        {
            return View();
        }

        public IActionResult UsertsCustomvalidation()
        { return View(); }
        [HttpPost]
        public IActionResult RegisterCustom(UserModelCustom user)
        {
            //if (!ModelState.IsValid)
            //{
            //    // If validation fails, return the same view with model to show errors
            //    return View("UsertsCustomvalidation");
            //}

            //return RedirectToAction("Success");
            // second way either we can call using manual
            ValidateModel(user);

            if (!ModelState.IsValid)
            {
                return View("UsertsCustomvalidation"); // Return the same view with validation errors
            }

            return RedirectToAction("Success");
        }


        private void ValidateModel(UserModelCustom model)
        {
            var validationContext = new ValidationContext(model);

            // Validate each property
            foreach (var property in typeof(UserModelCustom).GetProperties())
            {
                var value = property.GetValue(model);
                var attributes = property.GetCustomAttributes(typeof(ValidationAttribute), true);

                foreach (ValidationAttribute attribute in attributes)
                {
                    var result = attribute.GetValidationResult(value, validationContext);
                    if (result != ValidationResult.Success)
                    {
                        ModelState.AddModelError(property.Name, result.ErrorMessage);
                    }
                }
            }
        }
    }
}
