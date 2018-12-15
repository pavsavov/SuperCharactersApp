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

    public class SecretIdentityServices : IService<SecretIdentityViewModel>
    {
        private readonly IUnitOfWork _unitOfWork;

        public SecretIdentityServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Create(SecretIdentityViewModel model) //Map viewModel to DbModel 
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

        public SecretIdentityViewModel GetById(string id) //Map DbModel to ViewModel
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

        public void Update(SecretIdentityViewModel modelToUpdate)   //Map viewModel to DbModel
        {
            throw new NotImplementedException();
        }
    }
}
