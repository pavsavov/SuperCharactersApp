using SuperCharacters.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperCharactersApp.Repository.Contracts
{
    public interface IUnitOfWork    
    {
        RepositoryGeneric<Character> CharacterRepository { get; }
        RepositoryGeneric<Team> TeamRepository { get; }
        void Save();
    }
}
