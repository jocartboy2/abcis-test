using System;
using System.Collections.Generic;
using System.Linq;
using Commander.Models;

namespace Commander.Data
{
    public class SqlCommanderRepo : IAbcisRepo
    {
        private readonly AbcisContext _context;

        public SqlCommanderRepo(AbcisContext context)
        {
            _context = context;
        }

        public void CreateCommand(AbcisCommand cmd)
        {
            if (cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }
            _context.Commands.Add(cmd);
        }

        public void DeleteCommand(AbcisCommand cmd)
        {
            if (cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }
            _context.Commands.Remove(cmd);
        }

        public IEnumerable<AbcisCommand> GetAllCommands()
        {
            return _context.Commands.ToList();
        }

        public AbcisCommand GetCommandById(int id)
        {
            return _context.Commands.FirstOrDefault(p => p.Id == id);
        }

        public bool SaveChanges()
        {
            if (_context.SaveChanges() == 0)
            {
                return true;
            }
            return false;
        }

        public void UpdateCommand(AbcisCommand cmd)
        {
            //Nothing
        }
    }
}