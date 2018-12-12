namespace SuperCharactersApp.Services.CRUD.Services
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
    using SuperCharactersApp.ViewModels.Contracts;

    public class CharacterServices : IService<ICharacterViewModel>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CharacterServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void Create(ICharacterViewModel model) //Map viewModel to DbModel 
        {
            Character character = new Character();

            character = Mapper.Map<SuperHero>(model);

            var team = _unitOfWork.TeamRepository.GetById(character.TeamId);

            character.Team = team;

            _unitOfWork.CharacterRepository.Create(character);

            _unitOfWork.Save();

        }

        public void DeleteById(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ICharacterViewModel> GetAll()
        {
            return _unitOfWork.CharacterRepository
                .GetAll()
                .To<CharacterViewModel>()
                .ToList();
        }

        public ICharacterViewModel GetById(string id) //Map DbModel to ViewModel
        {

            throw new NotImplementedException();
            //return
            //     this.unitOfWork.AccountRepository
            //    .All()
            //    .Where(x => x.Id == id)
            //    .To<LoginBindingModel>()
            //    .FirstOrDefault();
        }

        public void Update(ICharacterViewModel modelToUpdate)   //Map viewModel to DbModel
        {
            throw new NotImplementedException();
        }
    }
}
