using System.ComponentModel.DataAnnotations;

namespace Store.System.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}