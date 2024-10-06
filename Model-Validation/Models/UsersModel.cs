﻿using System.ComponentModel.DataAnnotations;

namespace Model_Validation.Models
{
    public class UsersModel
    {

        [Required(ErrorMessage = "Username is required.")]
        [StringLength(40, ErrorMessage = "Username may not be longer than 40 characters.")]
        public string? Username { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Password must be at least 6 characters long.")]
        public string? Password { get; set; }

        [Required(ErrorMessage = "First Name is required.")]
        [StringLength(40, ErrorMessage = "First Name can't be longer than 40 characters.")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required.")]
        [StringLength(40, ErrorMessage = "Last Name can't be longer than 40 characters.")]
        public string? LastName { get; set; }

        [Required(ErrorMessage = "Date of Birth is required.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Confirm Password is required.")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Confirm Password must match the Password.")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string? ConfirmPassword { get; set; }
    }
}