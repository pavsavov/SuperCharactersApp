using System.Linq;
using Shouldly;
using SuperCharactersApp.ViewModels.DTO.SecretIdentityViewModels;
using Xunit;

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

    [Collection("ServicesTests")]
    public class SecretIdentityServicesTests
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IServiceProvider _serviceProvider;
        private readonly IService<ViewModels.DTO.SecretIdentityViewModels.SecretIdentityViewModel> _secretIdentityServices;
        private readonly SuperCharactersAppDbContext _dbContext;
        private readonly IList<ViewModels.DTO.SecretIdentityViewModels.SecretIdentityViewModel> _secretIdentityData;

        public SecretIdentityServicesTests()
        {
            var services = new ServiceCollection();

            services.AddDbContext<SuperCharactersAppDbContext>(options =>
                options.UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()));
            services.AddScoped<SecretIdentityServices>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            _serviceProvider = services.BuildServiceProvider();

            _dbContext = _serviceProvider.GetService<SuperCharactersAppDbContext>();
            _secretIdentityServices = _serviceProvider.GetService<SecretIdentityServices>();
            _unitOfWork = _serviceProvider.GetService<IUnitOfWork>();

            Mapper.Reset();

            AutoMapperConfig.RegisterMappings(
                typeof(SecretIdentityViewModel).Assembly
            );

            _secretIdentityData = SecretIdentityDataSeed();
        }

        //Create method tests
        [Fact]
        public void CreateShouldAddNewEntityToDb()
        {
            var secretIdentity = _secretIdentityData[1];

            var result = _secretIdentityServices.Create(secretIdentity);

            result.ShouldBeTrue();
        }

        //GetAll method tests
        [Fact]
        public void GetAllShouldRetrieveAllSecretIdentitiesFromDb()
        {
            var result = _secretIdentityServices.GetAll().ToList();

            result.ShouldNotBeNull();
        }

        //GetById method tests
        [Fact]
        public void GetByIdShouldRetrieveAnySecretIdentityByItsGivenId()
        {
            var secretIdentity = _secretIdentityData[0];

            _secretIdentityServices.Create(secretIdentity);

            var result = _secretIdentityServices.GetById(secretIdentity.Id);

            result.ShouldNotBeNull();
        }


        #region TestDataSeed
        public List<SecretIdentityViewModel> SecretIdentityDataSeed()
        {
            var secretIdentities = new List<SecretIdentityViewModel>
            {
                new SecretIdentityViewModel
                {
                    Id = "1",
                    FirstName = "Bobi",
                    LastName="Turboto"

                },
                new SecretIdentityViewModel
                {
                    Id="2",
                    FirstName = "Sasho",
                    LastName = "Dikov"

                }
            };

            return secretIdentities;
        }

        #endregion

    }
}
