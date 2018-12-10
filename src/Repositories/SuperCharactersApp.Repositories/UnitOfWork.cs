namespace SuperCharactersApp.Repository
{
    using System;
    using SuperCharacters.Models;
    using SuperCharacters.DataAccess;
    using Contracts;

    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly SuperCharactersAppDbContext _dbContext;
        private RepositoryGeneric<Character> _characterRepository;
        private RepositoryGeneric<Team> _teamRepository;
        // private RepositoryGeneric<SuperPower> _superpowers;

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

        public void Save()
        {
            _dbContext.SaveChanges();
        }

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
