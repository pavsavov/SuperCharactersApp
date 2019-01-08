namespace SuperCharactersApp.ViewModels.DTO.SecretIdentityViewModels
{
    using SuperCharacters.Models;
    using SuperCharacters.Services.Mapping.Contracts;
    using System.ComponentModel.DataAnnotations;

    public class SecretIdentityViewModel :
        IMapTo<SecretIdentity>,
        IMapFrom<SecretIdentity>
        
    {
        public string Id { get; set; }

        [StringLength(50, MinimumLength = 1)]
        [Display(Name ="First name")]
        public string FirstName { get; set; }
        [StringLength(50, MinimumLength = 1)]
        [Display(Name = "Last name")]
        public string LastName { get; set; }
    }
}
