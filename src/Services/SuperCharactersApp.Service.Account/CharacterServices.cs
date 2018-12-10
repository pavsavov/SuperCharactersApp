namespace SuperCharactersApp.Services
{
    using System;
    using System.Linq;
    using SuperCharacters.Models;
    using SuperCharactersApp.Services.CRUD.Services.Contracts;
    using SuperCharacters.Services.Mapping;
    using SuperCharactersApp.ViewModels.DTO.CharacterViewModels;
    using System.Collections.Generic;
    using AutoMapper;
    using SuperCharactersApp.Repository.Contracts;

    public class CharacterServices : IService<CharacterViewModel>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CharacterServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void Create(CharacterViewModel model) //Map viewModel to DbModel 
        {

            var character = Mapper.Map<Character>(model);

            _unitOfWork.CharacterRepository.Create(character);

            _unitOfWork.Save();

        }

        public void DeleteById(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CharacterViewModel> GetAll()
        {
            return _unitOfWork.CharacterRepository
                .GetAll()
                .To<CharacterViewModel>()
                .ToList();
        }

        public CharacterViewModel GetById(string id) //Map DbModel to ViewModel
        {

            throw new NotImplementedException();
            //return
            //     this.unitOfWork.AccountRepository
            //    .All()
            //    .Where(x => x.Id == id)
            //    .To<LoginBindingModel>()
            //    .FirstOrDefault();
        }

        public void Update(CharacterViewModel modelToUpdate)   //Map viewModel to DbModel
        {
            throw new NotImplementedException();
        }
    }
}
