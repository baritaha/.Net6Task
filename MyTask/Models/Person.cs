using System.ComponentModel.DataAnnotations;
using System.Configuration;

namespace MyTask.Models
{
    public class Person
    {
        
            public int Id { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        [Display(Name ="First Name")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "First Name must contain only letters")]
        [DataType(DataType.Text)]
        [MinLength(3,ErrorMessage ="minimum lenth 3 characters")]
        [MaxLength(6, ErrorMessage = "maximum lenth 6 characters")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        [Display(Name = "Last Name")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Last Name must contain only letters")]
        [DataType(DataType.Text)]
        [MinLength(3, ErrorMessage = "minimum lenth 3 characters")]
        [MaxLength(6, ErrorMessage = "maximum lenth 6 characters")]
        public string LastName { get; set; }

        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
            public string Email { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Phone Number is required")]
        [Phone(ErrorMessage = "Invalid phone number")]
        [MinLength(10, ErrorMessage = "minimum lenth 10 Numbers")]
        [MaxLength(10, ErrorMessage = "maximum lenth 3 characters")]
        public string PhoneNumber { get; set; }
        
    }
}
