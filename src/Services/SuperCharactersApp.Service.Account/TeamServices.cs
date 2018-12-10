using AutoMapper;
using SuperCharacters.Models;
using SuperCharacters.Services.Mapping;
using SuperCharactersApp.Repository.Contracts;
using SuperCharactersApp.Services.CRUD.Services.Contracts;
using SuperCharactersApp.ViewModels.DTO.TeamViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperCharactersApp.Services
{
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

        public void DeleteById(string id)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public void Update(CreateTeamViewModel modelToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
