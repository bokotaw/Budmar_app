using Budmar_app.Data;
using Budmar_app.Repository.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace Budmar_app.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AppDbContext _context;

        public Repository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<T> CreateAsync(T _entity)
        {
            try
            {
                var obj = _context.Add<T>(_entity);
                await _context.SaveChangesAsync();
                return obj.Entity;
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Error saving changes to database. Please try again later.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("An erro occured while creating the object. Please try again later.", ex);
            }
        }

        public async Task DeleteAsync(T _entity)
        {
            try
            {
                _context.Remove(_entity);
                
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Error deleting object", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occured while deleting object", ex);
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            try
            {
                List<T> objs = await _context.Set<T>().ToListAsync();
                return objs;
            }
            catch (DbException ex)
            {
                throw new Exception("Failed to retrieve objects.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("An Error occured while retrieving objects", ex);
            }
        }

        public async Task<T> GetAsync(int _id)
        {
            try
            {
                var obj = await _context.Set<T>().FindAsync(_id);
                if(obj != null)
                    return obj;
                else
                    throw new Exception("Object with the specified id was not found.");
            }
            catch (ArgumentNullException ex)
            {
                throw new ArgumentException("Id is null.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while getting the object by id.", ex);
            }
        }       

        public async Task UpdateAsync(T _entity)
        {
            try
            {
                //_context.Entry(_entity).CurrentValues.SetValues(_entity);
                var obj = _context.Update(_entity);
                if (obj != null)
                    await _context.SaveChangesAsync();
                else
                    throw new ArgumentNullException(nameof(obj));
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Failed to update the object.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occured while updating object", ex);
            }
        }
       

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
