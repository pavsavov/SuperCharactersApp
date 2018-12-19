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
    using X.PagedList;

    /// <summary>
    /// This class is responsible for all CRUD operations on Characters Entity.
    /// It receives input from respective controller and forwards parameters to the
    /// GenericRepository class with registered type in the UnitOfWork class.
    /// Also when is required, here happens the actual mapping from ViewModel to real Db model using Automapper.
    /// </summary>
    public class CharacterServices : IService<ICharacterViewModel>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CharacterServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Create(ICharacterViewModel model)
        {
            Character character = CharacterMapping(model.CharacterType, model);

            CreateCharacterSecretIdentityIfAny(character);

            var team = _unitOfWork.TeamRepository.GetById(character.TeamId);

            character.Team = team;

            _unitOfWork.CharacterRepository.Create(character);

            _unitOfWork.Save();

        }

        public bool DeleteById(string id)
        {
            if (_unitOfWork.CharacterRepository.GetById(id) != null)
            {
                _unitOfWork.CharacterRepository.DeleteById(id);

                _unitOfWork.Save();

                return true;
            }
            return false;
        }

        public IEnumerable<ICharacterViewModel> GetAll()
        {
            return _unitOfWork.CharacterRepository
                .GetAll()
                .To<CharacterViewModel>()
                .ToList();
        }

        public ICharacterViewModel GetById(string Id)
        {
            if (Id == null)
            {
                throw new ArgumentNullException();
            }

            return
                 _unitOfWork.CharacterRepository
                .GetAll()
                .Where(x => x.Id == Id)
                .To<CharacterViewModel>()
                .FirstOrDefault();
        }

        public void Edit(ICharacterViewModel modelToUpdate)
        {
            throw new NotImplementedException();
        }

        #region AdditionalServices
        private Character CharacterMapping(string charType, ICharacterViewModel model)
        {

            Character character;
            if (charType == "Superhero")
            {
                return character = Mapper.Map<SuperHero>(model);
            }
            else
            {
                return character = Mapper.Map<SuperVillain>(model);
            }

        }

        private bool CreateCharacterSecretIdentityIfAny(Character character)
        {
            bool createdCharacter;

            if (character.SecretIdentity.FirstName != null ||
                character.SecretIdentity.LastName != null)
            {

                _unitOfWork.SecretIdentityRepository.Create(character.SecretIdentity);
                _unitOfWork.Save();
                createdCharacter = true;
            }
            else
            {
                character.SecretIdentity = null;
                createdCharacter = false;
            }

            return createdCharacter;
        }
        #endregion
    }
}
