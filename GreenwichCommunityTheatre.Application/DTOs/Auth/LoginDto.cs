using System.ComponentModel.DataAnnotations;


namespace GreenwichCommunityTheatre.Application.DTOs.Auth
{
    public class LoginDto
    {
        [Required(ErrorMessage = "Email can't be blank")]
        [EmailAddress(ErrorMessage = "Email should be in a proper email address format")]
        public required string Email { get; set; }

        [Required(ErrorMessage = "Password can't be blank")]
        [DataType(DataType.Password)]
        public required string Password { get; set; }
    }
}
