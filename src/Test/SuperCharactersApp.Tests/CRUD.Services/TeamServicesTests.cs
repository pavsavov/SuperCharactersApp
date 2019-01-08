using System.Linq;
using Shouldly;

namespace SuperCharactersApp.Tests.CRUD.Services
{
    using System;
    using System.Collections.Generic;
    using AutoMapper;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using SuperCharacters.DataAccess;
    using SuperCharacters.Services.Mapping;
    using Repository;
    using Repository.Contracts;
    using SuperCharactersApp.Services.CRUD.Services;
    using SuperCharactersApp.Services.CRUD.Services.Contracts;
    using ViewModels.DTO.TeamViewModels;
    using Xunit;

    [Collection("ServicesTests")]
    public class TeamServicesTests
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IServiceProvider _serviceProvider;
        private readonly IService<TeamViewModel> _teamServices;
        private readonly SuperCharactersAppDbContext _dbContext;
        private readonly IList<TeamViewModel> _teamData;

        public TeamServicesTests()
        {
            var services = new ServiceCollection();

            services.AddDbContext<SuperCharactersAppDbContext>(options =>
                options.UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()));
            services.AddScoped<TeamServices>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            _serviceProvider = services.BuildServiceProvider();

            _dbContext = _serviceProvider.GetService<SuperCharactersAppDbContext>();
            _teamServices = _serviceProvider.GetService<TeamServices>();
            _unitOfWork = _serviceProvider.GetService<IUnitOfWork>();

            Mapper.Reset();

            AutoMapperConfig.RegisterMappings(
                typeof(TeamViewModel).Assembly
            );

            _teamData = TeamDataSeed();
        }

        //Create method tests
        [Fact]
        public void CreateShouldAddNewTeamToDb()
        {
            var team = _teamData[0];

            _teamServices.Create(team);

            var createdTeam = _teamServices.GetById(team.Id);

            createdTeam.ShouldNotBeNull();
        }

        [Fact]
        public void CreateShouldReturnTrueIfSucceeded()
        {
            var team = _teamData[1];

            var result = _teamServices.Create(team);

            result.ShouldBeTrue();
        }

        //GetAll method tests
        [Fact]
        public void GetAllShouldReturnAllTeamsInDb()
        {
            var result = _teamServices.GetAll().ToList();

            result.ShouldNotBeNull();
        }

        //DeleteById method tests
        [Fact]
        public void DeleteByIdShouldReturnTrueIfEntityDeletedSuccesfull()
        {
            var team = _teamData[1];

            _teamServices.Create(team);

            var result = _teamServices.DeleteById(team.Id);

            result.ShouldBeTrue();
        }

        [Fact]
        public void DeleteByIdShouldReturnFalseIfIdIsNull()
        {
            string id = null;

            var result = _teamServices.DeleteById(id);

            result.ShouldBeFalse();
        }

        //Edit method tests
        [Fact]
        public void EditShouldChangeTeamNameIfSucceded()
        {
            var team = _teamData[1];
            _teamServices.Create(team);
            var teamNewName = "Legion in Samokov";
            team.TeamName = teamNewName;
            _teamServices.Edit(team);

            var editedTeam = _teamServices.GetById(team.Id);

            team.TeamName.ShouldBeSameAs(editedTeam.TeamName);
        }

        #region TestData
        public List<TeamViewModel> TeamDataSeed()
        {
            var teams = new List<TeamViewModel>
            {
                new TeamViewModel
                {
                    Id = "1",
                    TeamName = "Hello Kitty Team"
                },
                new TeamViewModel
                {
                    Id="2",
                    TeamName = "Dream Team Space Jam"

                },
                new TeamViewModel
                {
                
                    Id="3",
                    TeamName = "Tortuga",
                }
            };

            return teams;
        }
        #endregion
    }
}
