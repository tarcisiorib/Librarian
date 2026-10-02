using Librarian.Application.Contracts.Persistence;
using Librarian.Domain;
using Librarian.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Librarian.Persistence.Repositoreis;

public class MemberRepository : GenericRepository<Member>, IMemberRepository
{
    public MemberRepository(LibrarianDbContext context) : base(context) { }

    public async Task<bool> IsUniqueMemberAsync(Member entity)
    {
        return await _dbSet.AnyAsync(m => m.FirstName == entity.FirstName &&
                                    m.LastName == entity.LastName &&
                                    m.Email == entity.Email &&
                                    m.DateOfBirth == entity.DateOfBirth) == false;
    }
}
