using System.Collections.Generic;
using Commander.Models;

namespace Commander.Data
{
    public interface IAbcisRepo
    {
        bool SaveChanges();
        IEnumerable<AbcisCommand> GetAllCommands();
        AbcisCommand GetCommandById(int id);
        void CreateCommand(AbcisCommand cmd);
        void UpdateCommand(AbcisCommand cmd);
        void DeleteCommand(AbcisCommand cmd);
    }
}