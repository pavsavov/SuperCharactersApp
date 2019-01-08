namespace SuperCharactersApp.Services.CRUD.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using SuperCharacters.Models;
    using SuperCharacters.Services.Mapping;
    using SuperCharactersApp.Repository.Contracts;
    using Contracts;
    using ViewModels.DTO.SuperPowerViewModels;

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

        public bool Create(SuperPowersListingViewModel model)
        {
            var superpower = Mapper.Map<SuperPower>(model);

            _unitOfWork.SuperPowerRepository.Create(superpower);

            _unitOfWork.Save();

            return true;
        }

        public bool DeleteById(string id)
        {
            if (id != null)
            {
                _unitOfWork.SuperPowerRepository.DeleteById(id);
                _unitOfWork.Save();
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

        public void Edit(SuperPowersListingViewModel editModel)
        {
            var superpowerMapped = Mapper.Map<SuperPower>(editModel);

            ManuallyPassValueToEachProperty(superpowerMapped);

            _unitOfWork.Save();
        }

        #region SupportiveMethodsForCRUDoperations

        public void ManuallyPassValueToEachProperty(SuperPower superpowerMapped)
        {
            var superpower = _unitOfWork.SuperPowerRepository.GetById(superpowerMapped.Id);

            superpower.Id = superpowerMapped.Id;
            superpower.SuperPowerName = superpowerMapped.SuperPowerName;
            superpower.Type = superpowerMapped.Type;
            superpower.Value = superpowerMapped.Value;
        }
        #endregion
    }
}
