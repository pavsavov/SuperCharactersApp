namespace SuperCharactersApp.Repository
{
    using System;
    using SuperCharacters.Models;
    using SuperCharacters.DataAccess;
    using Contracts;

    /// <summary>
    /// Although EntityFramework itself implements unit of work pattern, this class provide centralized approach 
    /// on CRUD operations. The level of abstraction that comes from it, guarantees better code maintenance, readability
    /// and control over application data flow.
    /// ================================================================================================================
    /// This UnitOfWork class, following unit of work pattern,
    /// is responsible for registering and accessing the main GenericRepository.
    /// The class wraps the GenericRepository as an additional level of
    /// an abstraction and stands in the middle between service and repository layers.
    /// Every property represents repository layer of its kind to the respective entity.
    /// </summary>
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly SuperCharactersAppDbContext _dbContext;
        private RepositoryGeneric<Character> _characterRepository;
        private RepositoryGeneric<Team> _teamRepository;
        private RepositoryGeneric<SuperPower> _superpowers;
        private RepositoryGeneric<SecretIdentity> _secretIdentity;

        public UnitOfWork(SuperCharactersAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public RepositoryGeneric<Character> CharacterRepository
        {
            get
            {
                if (_characterRepository == null)
                {
                    _characterRepository = new RepositoryGeneric<Character>(_dbContext);
                }

                return _characterRepository;
            }
        }

        public RepositoryGeneric<Team> TeamRepository
        {
            get
            {
                if (_teamRepository == null)
                {
                    _teamRepository = new RepositoryGeneric<Team>(_dbContext);
                }

                return _teamRepository;
            }
        }

        public RepositoryGeneric<SuperPower> SuperPowerRepository
        {
            get
            {
                if (_superpowers == null)
                {
                    _superpowers = new RepositoryGeneric<SuperPower>(_dbContext);
                }

                return _superpowers;
            }
        }

        public RepositoryGeneric<SecretIdentity> SecretIdentityRepository
        {
            get
            {
                if (_secretIdentity == null)
                {
                    _secretIdentity = new RepositoryGeneric<SecretIdentity>(_dbContext);
                }

                return _secretIdentity;
            }
        }
        
        /// <summary>
        /// Calling .SaveChanges() from dbContext.
        /// </summary>
        public void Save()
        {
            _dbContext.SaveChanges();
        }

        /// <summary>
        /// Ensures that the dbContext in use is being disposed by the
        /// garbage collector when needed.
        /// </summary>
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
