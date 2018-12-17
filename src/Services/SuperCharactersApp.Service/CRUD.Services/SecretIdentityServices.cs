namespace SuperCharactersApp.Services.CRUD.Services
{
    using AutoMapper;
    using SuperCharacters.Models;
    using SuperCharacters.Services.Mapping;
    using SuperCharactersApp.Repository.Contracts;
    using SuperCharactersApp.Services.CRUD.Services.Contracts;
    using SuperCharactersApp.ViewModels.DTO.SecretIdentityViewModels;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// This class is responsible for all CRUD operations on SecretIdentities Entity.
    /// It receives input from respective controller and forwards parameters to the
    /// GenericRepository class with registered type in the UnitOfWork class.
    /// Also when is required, here happens the actual mapping from ViewModel to real Db model using Automapper.
    /// </summary>
    public class SecretIdentityServices : IService<SecretIdentityViewModel>
    {
        private readonly IUnitOfWork _unitOfWork;

        public SecretIdentityServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Create(SecretIdentityViewModel model) 
        {
            if (model.FirstName != null && model.LastName != null)
            {
                var secretIdentity = Mapper.Map<SecretIdentity>(model);

                _unitOfWork.SecretIdentityRepository.Create(secretIdentity);

                _unitOfWork.Save();
            }
        }

        public bool DeleteById(string id)
        {
            if (id != null)
            {
                _unitOfWork.SecretIdentityRepository.DeleteById(id);
                return true;
            }

            return false;
        }

        public IEnumerable<SecretIdentityViewModel> GetAll()
        {
            return _unitOfWork.SecretIdentityRepository
                .GetAll()
                .To<SecretIdentityViewModel>()
                .ToList();
        }

        public SecretIdentityViewModel GetById(string id) 
        {
            if (id == null)
            {
                throw new NullReferenceException();
            }

            var secretIdentity = _unitOfWork.SecretIdentityRepository
                .GetById(id);

            var mappedSecretIdentity = Mapper.Map<SecretIdentityViewModel>(secretIdentity);

            return mappedSecretIdentity;
        }

        public void Update(SecretIdentityViewModel modelToUpdate)  
        {
            throw new NotImplementedException();
        }
    }
}
