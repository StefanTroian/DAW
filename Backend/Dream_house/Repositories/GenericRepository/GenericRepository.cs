using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dream_house.Data;
using Dream_house.Models.Base;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Dream_house.Repositories.GenericRepository
{
    public class GenericRepository<TEntity>: IGenericRepository<TEntity> where TEntity: BaseEntity
    {
        protected readonly DreamHouseContext _context;
        protected readonly DbSet<TEntity> _table;

        public GenericRepository(DreamHouseContext context)
        {
            _context = context;
            _table = _context.Set<TEntity>();
        }


        // Get All
        public async Task<List<TEntity>> GetAll()
        {
            return await _table.AsNoTracking().ToListAsync();
        } 
        public IQueryable<TEntity> GetAllAsQueryable()
        {
            return _table.AsNoTracking();
        }



        // Create
        public void Create(TEntity entity)
        {
            _table.Add(entity);
        }
        public async Task CreateAsync(TEntity entity)
        {
            await _table.AddAsync(entity);
        }

        public void CreateRange(IEnumerable<TEntity> entities)
        {
            _table.AddRange(entities);
        }
        public async Task CreateRangeAsync(IEnumerable<TEntity> entities)
        {
            await _table.AddRangeAsync(entities);
        }



        // Update
        public void Update(TEntity entity)
        {
            _table.Update(entity);
        }
        public void UpdateRange(IEnumerable<TEntity> entities)
        {
            _table.UpdateRange(entities);
        }



        // Delete
        public void Delete(TEntity entity)
        {
            _table.Remove(entity);
        }
        public void DeleteRange(IEnumerable<TEntity> entities)
        {
            _table.RemoveRange(entities);
        }



        //Find
        public TEntity FindById(object id)
        {
            return _table.Find(id);
        }
        public async Task<TEntity> FindByIdAsync(object id)
        {
            return await _table.FindAsync(id);
        }



        // Save
        public bool Save()
        {
            try
            {
                return _context.SaveChanges() > 0;
            } 
            catch(SqlException ex)
            {
                Console.WriteLine(ex);
            }
            return false;
        }
        public async Task<bool> SaveAsync()
        {
            try
            {
                return await _context.SaveChangesAsync() > 0;
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex);
            }
            return false;
        }

    }
}
