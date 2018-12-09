namespace SuperCharactersApp.Services.Account
{
    using SuperCharacters.Models;
    using SuperCharactersApp.Services.Account.Contracts;
    using System;
    using SuperCharactersApp.Repository;
    using SuperCharacters.Web.ViewModels.Account;
    using SuperCharacters.Services.Mapping;
    using System.Linq;
    using SuperCharactersApp.Services.Account.ViewModels.Contracts;

    public class AccountServices : IAccountServices
    {
        private readonly UnitOfWork unitOfWork;

        public AccountServices(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public void Create(SuperCharactersUser user)
        {
            throw new NotImplementedException();
        }

        public void DeleteById(string id)
        {
            throw new NotImplementedException();
        }

        public IViewModel GetById(string id)
        {

            throw new NotImplementedException();
            //return
            //     this.unitOfWork.AccountRepository
            //    .All()
            //    .Where(x => x.Id == id)
            //    .To<LoginBindingModel>()
            //    .FirstOrDefault();
        }

        public void Update(SuperCharactersUser userToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
