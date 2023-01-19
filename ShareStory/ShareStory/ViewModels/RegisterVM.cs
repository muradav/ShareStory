using System.ComponentModel.DataAnnotations;

namespace ShareStory.ViewModels
{
    public class RegisterVM
    {
            [Required(ErrorMessage = ("Adınızı daxil edin")), StringLength(100)]
            public string Name { get; set; }

            [Required(ErrorMessage = ("Soyadınızı daxil edin")), StringLength(100)]
            public string Surname { get; set; }

            [Required(ErrorMessage = ("İstifadəçi adı daxil edin")), StringLength(100)]
            public string Username { get; set; }

            [Required(ErrorMessage = ("Elektron poçt daxil edin")), DataType(DataType.EmailAddress)]
            public string Email { get; set; }

            [Required(ErrorMessage = ("Telefon nömrəsi daxil edin")), DataType(DataType.PhoneNumber)]
            [Phone(ErrorMessage = ("Telefon nömrəsi daxil edin"))]
            public string PhoneNumber { get; set; }

            [Required(ErrorMessage = ("Şifrə daxil edin")), DataType(DataType.Password)]
            public string Password { get; set; }

            [Required(ErrorMessage = ("Şifrəni təkrar daxil edin")), DataType(DataType.Password), Compare(nameof(Password), ErrorMessage = "Düzgün şifrə daxil edin")]
            public string RepeatPassword { get; set; }
    }
}
