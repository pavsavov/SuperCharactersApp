namespace SuperCharactersApp.Services.CRUD.Services
{
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
    /// It receives input from respective controller and forwards parameters to the GenericRepository class with registered type
    /// in the UnitOfWork class. Also when needed, here happens the actual mapping from ViewModel to real Db model using Automapper.
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

        public void DeleteById(string id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<SuperPowersListingViewModel> GetAll()
        {
            var teams = _unitOfWork.SuperPowerRepository.GetAll();

            return teams.AsQueryable()
                .To<SuperPowersListingViewModel>()
                .ToList(); ;
        }

        public SuperPowersListingViewModel GetById(string id)
        {
            throw new System.NotImplementedException();
        }

        public void Update(SuperPowersListingViewModel modelToUpdate)
        {
            throw new System.NotImplementedException();
        }
    }
}
