using Microsoft.EntityFrameworkCore;
using Onion.JWTApp.Application.Interfaces;
using Onion.JWTApp.Persistence.Context;
using System.Linq.Expressions;

namespace Onion.JWTApp.Persistence.Repositories
{
    public class Repository<T> : IRepository<T> where T : class, new()
    {
        private readonly JwtContext _context;

        public Repository(JwtContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<T>> GetAllAsync()
        {
            var tList = await _context.Set<T>().AsNoTracking().ToListAsync();
            return tList;
        }

        public async Task<T?> GetByFilterAsync(Expression<Func<T, bool>> filter)
        {
            var T = await _context.Set<T>().AsNoTracking().SingleOrDefaultAsync(filter);
            return T;
        }


        //Üstte yazdığım GetByFilterAsync methodundan farkı bir update ya da remove işlemi için bunu kullanacam. Yani asnotracking işlemi false olacak. Entity Framework tarafından izlenme olayını devre dışı bırakmadım.
        public async Task<T?> GetByIdAsync(object id)
        {
            var T = await _context.Set<T>().FindAsync(id);
            return T;
        }

        public async Task Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
