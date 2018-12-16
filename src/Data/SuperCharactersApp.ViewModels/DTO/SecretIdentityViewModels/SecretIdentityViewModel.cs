namespace SuperCharactersApp.ViewModels.DTO.SecretIdentityViewModels
{
    using SuperCharacters.Models;
    using SuperCharacters.Services.Mapping.Contracts;
    using System.ComponentModel.DataAnnotations;

    public class SecretIdentityViewModel :
        IMapTo<SecretIdentity>,
        IMapFrom<SecretIdentity>
    {
        [Required]
        [StringLength(50, MinimumLength = 1)]
        [Display(Name ="First name")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 1)]
        [Display(Name = "Last name")]

        public string LastName { get; set; }
    }
}
