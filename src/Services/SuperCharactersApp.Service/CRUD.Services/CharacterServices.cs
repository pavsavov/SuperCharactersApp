namespace SuperCharactersApp.Services.CRUD.Services
{
    using System;
    using System.Linq;
    using SuperCharacters.Models;
    using SuperCharactersApp.Services.CRUD.Services.Contracts;
    using SuperCharacters.Services.Mapping;
    using System.Collections.Generic;
    using AutoMapper;
    using SuperCharactersApp.Repository.Contracts;
    using SuperCharactersApp.ViewModels.DTO.CharacterViewModels;

    /// <summary>
    /// This class is responsible for all CRUD operations on Characters Entity.
    /// It receives input from respective controller and forwards parameters to the
    /// GenericRepository class with registered type in the UnitOfWork class.
    /// Also when is required, here happens the actual mapping from ViewModel to real Db model using Automapper.
    /// </summary>
    public class CharacterServices : IService<CharacterViewModel>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CharacterServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Create(CharacterViewModel model)
        {
            Character character = CharacterMapping(model.CharacterType, model);

            //Creates Secret identity for the Superhero/villain if there is such input
            CreateCharacterSecretIdentityIfAny(character);

            foreach (var superpowerId in model.SuperPowerId)
            {
                var superpower = _unitOfWork.SuperPowerRepository.GetById(superpowerId);
                character.SuperPowers.Add(superpower);
            }

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

        public IEnumerable<CharacterViewModel> GetAll()
        {
            return _unitOfWork.CharacterRepository
                .GetAll()
                .To<CharacterViewModel>()
                .ToList();
        }

        public CharacterViewModel GetById(string Id)
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

        public void Edit(CharacterViewModel modelToUpdate)
        {

            var characterMapped = Mapper.Map<Character>(modelToUpdate);

            var character = _unitOfWork.CharacterRepository.GetById(characterMapped.Id);

            character.CharacterType = characterMapped.CharacterType;
            character.Name = characterMapped.Name;
            character.Damage = characterMapped.Damage;
            character.Armour = characterMapped.Armour;
            character.SecretIdentity = characterMapped.SecretIdentity;
            character.SuperPowers = characterMapped.SuperPowers;
            character.Team = characterMapped.Team;

            //var teamMapped = Mapper.Map<Team>(modelToUpdate.Team);
            //_unitOfWork.TeamRepository.Edit(teamMapped);


            //_unitOfWork.CharacterRepository.Edit(characterMapped);



            _unitOfWork.Save();
        }


        #region AdditionalServices
        private Character CharacterMapping(string charType, CharacterViewModel model)
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
                //_unitOfWork.Save();
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
