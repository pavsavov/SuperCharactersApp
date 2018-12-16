namespace SuperCharactersApp.Services.CRUD.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using SuperCharacters.Models;
    using SuperCharacters.Services.Mapping;
    using SuperCharactersApp.Repository.Contracts;
    using SuperCharactersApp.Services.CRUD.Services.Contracts;
    using SuperCharactersApp.ViewModels.DTO.SuperPowerViewModels;

    /// <summary>
    /// This class is responsible for all CRUD operations on SuperPowers Entity.
    /// It receives input from respective controller and forwards parameters to the
    /// GenericRepository class with registered type in the UnitOfWork class.
    /// Also when is required, here happens the actual mapping from ViewModel to real Db model using Automapper.
    /// </summary>
    public class SuperpowerServices : IService<SuperPowersListingViewModel>
    {
        private readonly IUnitOfWork _unitOfWork;
        public SuperpowerServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Create(SuperPowersListingViewModel model)
        {
            var superpower = Mapper.Map<SuperPower>(model);

            _unitOfWork.SuperPowerRepository.Create(superpower);

            _unitOfWork.Save();
        }

        public bool DeleteById(string id)
        {
            if (id != null)
            {
                _unitOfWork.SuperPowerRepository.DeleteById(id);
                return true;
            }

            return false;
        }

        public IEnumerable<SuperPowersListingViewModel> GetAll()
        {
            var superpowers = _unitOfWork.SuperPowerRepository.GetAll();

            return superpowers.AsQueryable()
                .To<SuperPowersListingViewModel>()
                .ToList(); ;
        }

        public SuperPowersListingViewModel GetById(string id)
        {
            var superPower = _unitOfWork.SuperPowerRepository
                .GetById(id);

            var mappedSuperPower = Mapper.Map<SuperPowersListingViewModel>(superPower);

            return mappedSuperPower;
        }

        public void Update(SuperPowersListingViewModel modelToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
