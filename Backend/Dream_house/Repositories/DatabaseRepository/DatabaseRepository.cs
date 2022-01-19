using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dream_house.Data;
using Dream_house.Models;
using Dream_house.Repositories.GenericRepository;
using Microsoft.EntityFrameworkCore;

namespace Dream_house.Repositories.DatabaseRepository
{
    public class DatabaseRepository : GenericRepository<Home>, IDatabaseRepository
    {
        public DatabaseRepository(DreamHouseContext context) : base(context)
        {

        }
        public Home GetByName(string name)
        {
            return _table.FirstOrDefault(x => x.Name.ToLower().Equals(name.ToLower()));
        }

        public Home GetByNameIncludingRoom(string name)
        {
            return _table.Include(x => x.Rooms).FirstOrDefault(x => x.Name.ToLower().Equals(name.ToLower()));
        }

        public async Task<Home> GetByNameAsync(string name)
        {
            return await _table.FirstOrDefaultAsync(x => x.Name.ToLower().Equals(name.ToLower()));
        }

        public List<Home> GetAllWithInclude()
        {
            return _table.Include(x => x.Rooms).ToList();
        }

        public async Task<List<Home>> GetAllWithIncludeAsync()
        {
            return await _table.Include(x => x.Rooms).ToListAsync();
        }

        // TODO in loc de home un model pt join
        public List<Home> GetAllWithJoin()
        {
            var result = _table.Join(_context.Room, home => home.Id, room => room.Home_id, 
                (home, room) => new { home, room }).Select(obj => obj.home);

            return result.ToList();
        }

        public async Task<List<Home>> GetAllWithJoinAsync()
        {
            var result = _table.Join(_context.Room, home => home.Id, room => room.Home_id,
                (home, room) => new { home, room }).Select(obj => obj.home);

            return await result.ToListAsync();
        }
    }
}
