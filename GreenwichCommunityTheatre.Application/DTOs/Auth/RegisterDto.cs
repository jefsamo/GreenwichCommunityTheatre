using System.ComponentModel.DataAnnotations;

namespace GreenwichCommunityTheatre.Application.DTOs.Auth
{
    public class RegisterDto
    {
        [Required(ErrorMessage = "First Name can't be blank")]
        public required string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name can't be blank")]
        public required string LastName { get; set; }

        [Required(ErrorMessage = "Email can't be blank")]
        [EmailAddress(ErrorMessage = "Email should be in a proper email address format")]
        public required string Email { get; set; }


        [Required(ErrorMessage = "Phone can't be blank")]
        [RegularExpression(@"^(\+44\s?7\d{3}|\(?07\d{3}\)?)\s?\d{3}\s?\d{3}$", ErrorMessage = "Please enter a valid UK phone number.")]
        [DataType(DataType.PhoneNumber)]
        public required string PhoneNumber { get; set; }


        [Required(ErrorMessage = "Password can't be blank")]
        [DataType(DataType.Password)]
        public required string Password { get; set; }


        [Required(ErrorMessage = "Confirm Password can't be blank")]
        [DataType(DataType.Password)]
        public required string ConfirmPassword { get; set; }
    }
}
