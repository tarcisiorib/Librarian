using Librarian.Application.Contracts.Persistence;
using Librarian.Domain.Common;
using Librarian.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Librarian.Persistence.Repositoreis;

public class GenericRepository<T> : IGenericRepository<T> where T : Entity
{
    protected readonly LibrarianDbContext _context;
    protected readonly DbSet<T> _dbSet;

    public GenericRepository(LibrarianDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    public async Task<IReadOnlyList<T>> GetAllAsync()
    {
        return await _dbSet
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<T?> GetByIdAsync(int id)
    {
        return await _dbSet
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task CreateAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(T entity)
    {
        _dbSet.Update(entity);
        await _context.SaveChangesAsync();
    }
    
    public async Task DeleteAsync(T entity)
    {
        _dbSet.Remove(entity);
        await _context.SaveChangesAsync();
    }
}
