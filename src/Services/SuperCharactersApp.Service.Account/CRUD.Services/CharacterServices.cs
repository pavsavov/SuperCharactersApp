namespace SuperCharactersApp.Services.Account
{
    using SuperCharactersApp.Services.Account.Contracts;
    using System;
    using SuperCharactersApp.Repository;
    using SuperCharactersApp.Services.Account.ViewModels.Contracts;

    public class CharacterServices : IService<IViewModel>
    {
        private readonly UnitOfWork unitOfWork;

        public CharacterServices(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public void Create(IViewModel user) //Map viewModel to DbModel 
        {
            throw new NotImplementedException();
        }

        public void DeleteById(string id)
        {
            throw new NotImplementedException();
        }

        public IViewModel GetById(string id) //Map DbModel to ViewModel
        {

            throw new NotImplementedException();
            //return
            //     this.unitOfWork.AccountRepository
            //    .All()
            //    .Where(x => x.Id == id)
            //    .To<LoginBindingModel>()
            //    .FirstOrDefault();
        }
        
        public void Update(IViewModel userToUpdate)   //Map viewModel to DbModel
        {
            throw new NotImplementedException(); 
        }
    }
}
