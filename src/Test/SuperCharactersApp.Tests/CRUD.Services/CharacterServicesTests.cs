namespace SuperCharactersApp.Tests
{
    using AutoMapper;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using Shouldly;
    using SuperCharacters.DataAccess;
    using SuperCharacters.Models;
    using SuperCharacters.Services.Mapping;
    using Repository;
    using Repository.Contracts;
    using SuperCharactersApp.Services.CRUD.Services;
    using SuperCharactersApp.Services.CRUD.Services.Contracts;
    using ViewModels.DTO.CharacterViewModels;
    using ViewModels.DTO.SecretIdentityViewModels;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Xunit;
    using ViewModels.DTO.SuperPowerViewModels;

    public class CharacterServicesTests
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IServiceProvider _serviceProvider;
        private readonly IService<CharacterViewModel> _characterSevices;
        private readonly IService<SuperPowersListingViewModel> _superpowerSevices;
        private readonly SuperCharactersAppDbContext _dbContext;
        private readonly IList<CharacterViewModel> _characterData;
        private readonly IList<SuperPowersListingViewModel> _superpowerData;

        public CharacterServicesTests()
        {
            var service = new ServiceCollection();

            service.AddDbContext<SuperCharactersAppDbContext>(options =>
                options.UseInMemoryDatabase(Guid.NewGuid().ToString()));
            service.AddScoped<CharacterServices>();
            service.AddScoped<SuperpowerServices>();
            service.AddScoped<IUnitOfWork, UnitOfWork>();

            _serviceProvider = service.BuildServiceProvider();

            _dbContext = _serviceProvider.GetService<SuperCharactersAppDbContext>();
            _unitOfWork = new UnitOfWork(_dbContext);
            _characterSevices = _serviceProvider.GetService<CharacterServices>();
            _superpowerSevices = _serviceProvider.GetService<SuperpowerServices>();

            Mapper.Reset();

            AutoMapperConfig.RegisterMappings(
                 typeof(CharacterViewModel).Assembly
                 );

            _characterData = CharacterDataSeed();
            _superpowerData = SuperpowerDataSeed();
        }
        [Fact]
        public void CreateNewCharacterShouldReturnTrueIfSucceeded()
        {
            var result = _characterSevices.Create(_characterData[0]);

            _unitOfWork.Save();

            result.ShouldBeTrue();

        }

        [Fact]
        public void CreateNewCharacterShouldBeFoundInDb()
        {
            var currentCharacter = _characterData[3];
            var superpower = _superpowerData[0];

            _superpowerSevices.Create(superpower);
            _characterSevices.Create(currentCharacter);
            var result = _characterSevices.GetById(currentCharacter.Id);

            result.Id.ShouldBeSameAs(currentCharacter.Id);

        }

        [Fact]
        public void DeleteByIdShouldReturnTrueIfSuccessfull()
        {
            var entityToDelete = _characterData[0];
            _characterSevices.Create(entityToDelete);

            var result = _characterSevices.DeleteById(entityToDelete.Id);

            result.ShouldBeTrue();
        }
        [Fact]
        public void DeletetedEntityShouldNotBeFoundIfDeletedSuccessfully()
        {
            var entityToDelete = _characterData[0];
            _characterSevices.Create(entityToDelete);

            _characterSevices.DeleteById(entityToDelete.Id);

            var deletedEntity = _unitOfWork.CharacterRepository.GetById(entityToDelete.Id);

            deletedEntity.ShouldBeNull();
        }

        [Fact]
        public void GetAllShouldReturnAllCharactersFromDb()
        {
            var result = _characterSevices.GetAll().ToList();

            result.ShouldNotBeNull();
        }

        [Fact]
        public void EditMethodShouldChangeEntityNameIfSucceeded()
        {
            var character = _characterData[1];
            _characterSevices.Create(character);
            var newName = "Flying Dutchman";
            character.Name = newName;
            _characterSevices.Edit(character);

            var editedCharacterFromDb = _characterSevices.GetById(character.Id);

            character.Name.ShouldBeSameAs(editedCharacterFromDb.Name);
        }
        #region TestDataSeed
        public List<CharacterViewModel> CharacterDataSeed()
        {
            return new List<CharacterViewModel>
            {
                new CharacterViewModel
            {
                Id="1",
                Armour = 44,
                CharacterType = "Supervillain",
                Damage = 101,
                HitPoints = 121,
                Team = new Team { TeamName = "Lelq na Baba Yaga" },
                SecretIdentity = new SecretIdentityViewModel { FirstName = "Choveka", LastName = "S dve toqgi" }
            },
                new CharacterViewModel
            {
                Id="2",
                Armour = 99,
                CharacterType = "Superhero",
                Damage = 111,
                HitPoints = 111,
                Team = new Team { TeamName = "Baba Yaga" },
                SecretIdentity = new SecretIdentityViewModel { FirstName = "Sasho", LastName = "Bombeto" }
            },
                new CharacterViewModel
                {
                Id="3",
                Armour = 56,
                CharacterType = "Superhero",
                Damage = 133,
                HitPoints = 122,
                Team = new Team { TeamName = "Super typoto ime za otbor si imame" },
                SecretIdentity = new SecretIdentityViewModel { FirstName = "Bobo", LastName = "Kucheto" }
            },
            new CharacterViewModel
            {
                Id="4",
                Armour=13,
                CharacterType = "Superhero",
                Damage=144,
                HitPoints =145,
                Team = new Team{TeamName = "Otbor Trendafil"},
                SecretIdentity = new SecretIdentityViewModel { FirstName = "Ahmed", LastName = "DeadTerrorist" },
                SuperPowerId = new List<string>{"123"}
            }

            };
        }

        public List<SuperPowersListingViewModel> SuperpowerDataSeed()
        {
            var superpowers = new List<SuperPowersListingViewModel>
            {
                new SuperPowersListingViewModel
                {
                    Id = "123",
                    SuperPowerName = "Flying Dutchman",
                    Type = "Damage",
                    Value = 133
                }
            };

            return superpowers;
        }
        #endregion
    }
}