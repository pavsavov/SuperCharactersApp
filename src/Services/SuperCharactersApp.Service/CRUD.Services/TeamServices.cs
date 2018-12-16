﻿namespace SuperCharactersApp.Services.CRUD.Services
{
    using AutoMapper;
    using SuperCharacters.Models;
    using SuperCharacters.Services.Mapping;
    using SuperCharactersApp.Repository.Contracts;
    using SuperCharactersApp.Services.CRUD.Services.Contracts;
    using SuperCharactersApp.ViewModels.DTO.TeamViewModels;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// This class is responsible for all CRUD operations on Teams Entity.
    /// It receives input from respective controller and forwards parameters to the GenericRepository class with registered type
    /// in the UnitOfWork class. Also when needed, here happens the actual mapping from ViewModel to real Db model using Automapper.
    /// </summary>
    public class TeamServices : IService<CreateTeamViewModel>
    {
        private readonly IUnitOfWork _unitOfWork;

        public TeamServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Create(CreateTeamViewModel model)
        {

            var team = Mapper.Map<Team>(model);

            _unitOfWork.TeamRepository.Create(team);

            _unitOfWork.Save();
        }

        public bool DeleteById(string id)
        {
            if (id != null)
            {
                _unitOfWork.TeamRepository.DeleteById(id);
                return true;
            }

            return false;
        }

        public IEnumerable<CreateTeamViewModel> GetAll()
        {
            var teams = _unitOfWork.TeamRepository.GetAll();

            return teams.AsQueryable()
                .To<CreateTeamViewModel>()
                .ToList();

        }

        public CreateTeamViewModel GetById(string id)
        {
            var team = _unitOfWork.TeamRepository
                .GetById(id);

            var mappedTeam = Mapper.Map<CreateTeamViewModel>(team);

            return mappedTeam;
        }

        public void Update(CreateTeamViewModel modelToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
