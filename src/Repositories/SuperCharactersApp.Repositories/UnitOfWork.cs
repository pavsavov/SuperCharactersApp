namespace SuperCharactersApp.Repository
{
    using System;
    using SuperCharacters.Models;
    using SuperCharacters.Web.Data;
    using SuperCharactersApp.Repository.Contracts;

    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly SuperCharactersAppDbContext dbContext = new SuperCharactersAppDbContext();
        private RepositoryGeneric<SuperCharactersUser> accountRepository;

        public RepositoryGeneric<SuperCharactersUser> AccountRepository
        {
            get
            {
                if (this.accountRepository == null)
                {
                    this.accountRepository = new RepositoryGeneric<SuperCharactersUser>(dbContext);
                }

                return accountRepository;
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
