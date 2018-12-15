using SuperCharacters.Models;
using SuperCharacters.Services.Mapping.Contracts;

namespace SuperCharactersApp.ViewModels.DTO.SecretIdentityViewModels
{
    public class SecretIdentityViewModel : IMapTo<SecretIdentity>, IMapFrom<SecretIdentity>
    {
        /*-	First Name: String between 1 and 50
-	Last Name: String between 1 and 50
*/
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
