using System;
using System.Collections.Generic;
using System.Text;

namespace SuperCharacters.Models.Contracts
{
    public interface ICharacter<T>
    {
        //int ScoreId { get; set; }
        //Score Score { get; set; }
        T HitPoints { get; set; }
    }
}
