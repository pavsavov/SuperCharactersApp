namespace SuperCharactersApp.Repository
{
    using System;
    using SuperCharacters.Models;
    using SuperCharacters.DataAccess;
    using Contracts;

    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly SuperCharactersAppDbContext dbContext = new SuperCharactersAppDbContext();
        private RepositoryGeneric<Character> characterRepository;

        public RepositoryGeneric<Character> AccountRepository
        {
            get
            {
                if (this.characterRepository == null)
                {
                    this.characterRepository = new RepositoryGeneric<Character>(dbContext);
                }

                return characterRepository;
            }
        }

        public void Save()
        {
            dbContext.SaveChanges();
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    dbContext.Dispose();
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
