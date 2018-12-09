using System;
using System.Collections.Generic;
using System.Text;

namespace SuperCharactersApp.Repository.Contracts
{
   public interface IUnitOfWork
    {
        void Save();
    }
}
