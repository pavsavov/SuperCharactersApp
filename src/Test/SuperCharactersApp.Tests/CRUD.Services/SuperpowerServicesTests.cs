using AutoMapper;
using SuperCharactersApp.Repository;
using SuperCharactersApp.Services.CRUD.Services.Contracts;
using Xunit;

namespace SuperCharactersApp.Tests.CRUD.Services
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using SuperCharacters.DataAccess;
    using SuperCharacters.Services.Mapping;
    using SuperCharactersApp.Repository.Contracts;
    using SuperCharactersApp.Services.CRUD.Services;
    using SuperCharactersApp.ViewModels.DTO.SuperPowerViewModels;
    using System;
    using System.Collections.Generic;
    using Shouldly;

    [Collection("ServicesTests")]
    public class SuperpowerServicesTests
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IServiceProvider _serviceProvider;
        private readonly IService<SuperPowersListingViewModel> _superpowerSevices;
        private readonly SuperCharactersAppDbContext _dbContext;
        private readonly IList<SuperPowersListingViewModel> _superpowerData;

        public SuperpowerServicesTests()
        {
            var services = new ServiceCollection();

            services.AddDbContext<SuperCharactersAppDbContext>(options =>
                options.UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()));
            services.AddScoped<SuperpowerServices>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            _serviceProvider = services.BuildServiceProvider();

            _dbContext = _serviceProvider.GetService<SuperCharactersAppDbContext>();
            _superpowerSevices = _serviceProvider.GetService<SuperpowerServices>();
            _unitOfWork = _serviceProvider.GetService<IUnitOfWork>();

            Mapper.Reset();


            AutoMapperConfig.RegisterMappings(
                typeof(SuperPowersListingViewModel).Assembly
            );



            _superpowerData = SuperpowerDataSeed();

        }

        [Fact]
        public void GetByIdShouldReturnObjectOfTypeSuperpowersListingVieModel()
        {
 

            var superpower = _superpowerData[0];

            _superpowerSevices.Create(superpower);

            var result = _superpowerSevices.GetById(superpower.Id);

            result.ShouldBeOfType<SuperPowersListingViewModel>();
        }

        #region TestDataSeed

        public List<SuperPowersListingViewModel> SuperpowerDataSeed()
        {
            var superpowers = new List<SuperPowersListingViewModel>
            {
                new SuperPowersListingViewModel
                {
                    Id = "1",
                    SuperPowerName = "Flying Dutchman",
                    Type = "Damage",
                    Value = 133
                },
                new SuperPowersListingViewModel
                {
                    Id="123",
                    SuperPowerName = "Jack Sparrow",
                    Type = "Heal",
                    Value = 23
                }
            };

            return superpowers;
        }

        #endregion
    }
}
 