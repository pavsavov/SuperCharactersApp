namespace SuperCharactersApp.Repository
{
    using System;
    using SuperCharacters.Models;
    using SuperCharacters.DataAccess;
    using Contracts;

    /// <summary>
    /// This UnitOfWork class,part of the same nammed pattern,
    /// is responsible for registering and accessing the main GenericRepository.
    /// This class wraps the repository as an additional level of
    /// an abstraction and stands in the middle between service and repository layers.
    /// Every property represents repository layer of its kind to the respective entity.
    /// </summary>
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly SuperCharactersAppDbContext _dbContext;
        private RepositoryGeneric<Character> _characterRepository;
        private RepositoryGeneric<Team> _teamRepository;
        private RepositoryGeneric<SuperPower> _superpowers;

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
        /// <summary>
        /// Directly calls .SaveChanges() and it is used when changes are made to the Db. 
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
