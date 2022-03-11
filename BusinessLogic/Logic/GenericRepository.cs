using BusinessLogic.Data;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Logic
{
    public class GenericRepository<T> : IGenericRepository<T> where T : ClaseBase
    {
        private readonly MarketDbContext _contex;

        public GenericRepository(MarketDbContext context)
        {
            _contex = context;
        }
        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _contex.Set<T>().ToListAsync();
            
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _contex.Set<T>().FindAsync(id);
        }

        public async Task<T> GetByIdWithSpec(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).FirstOrDefaultAsync();
        }

        public async Task<IReadOnlyList<T>> GetAllWithSpec(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).ToListAsync();
        }

        private IQueryable<T> ApplySpecification(ISpecification<T> spec)
        {
            return SpecificationEvaluator<T>.GetQuery(_contex.Set<T>().AsQueryable(), spec);
        }

        public async Task<int> CountAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).CountAsync();
        }

        public async Task<int> Add(T entity)
        {
            _contex.Set<T>().Add(entity);
            return await _contex.SaveChangesAsync();
        }

        public async Task<int> Update(T entity)
        {
            _contex.Set<T>().Attach(entity);
            _contex.Entry(entity).State = EntityState.Modified;
            return await _contex.SaveChangesAsync();
        }
    }
}
