using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AdvancedImobiliaria.Database.Common;
using AdvancedImobiliaria.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace AdvancedImobiliaria.Repositories
{
	public class Repository<T> : IRepository<T> where T : class
	{
        protected readonly ImobiliariaContext _context;

        public Repository(ImobiliariaContext context)
        {
            _context = context;
        }

		public async Task Add(T entity)
		{
			await _context.Set<T>().AddAsync(entity);
		}

		public async Task<IEnumerable<T>> Find(Expression<Func<T, bool>> expression)
		{
            await Task.Yield();
			return _context.Set<T>().Where(expression);
		}

		public async Task<IEnumerable<T>> GetAll()
		{
			return await _context.Set<T>().ToListAsync();
		}

		public async Task<T> GetById(object id)
		{
			return await _context.Set<T>().FindAsync(id);
		}

		public async Task Update(T entity)
		{
			await Task.Yield();
			_context.Set<T>().Update(entity);
		}

		public async Task Remove(T entity)
		{
            await Task.Yield();
			_context.Set<T>().Remove(entity);
		}
	}
}