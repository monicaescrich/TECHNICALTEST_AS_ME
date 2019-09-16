using System.Linq;
using System.Threading.Tasks;
using TECHNICALTEST_AS_ME.Domains.Models;
using TECHNICALTEST_AS_ME.Domains.Repositories;
using TECHNICALTEST_AS_ME.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace TECHNICALTEST_AS_ME.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(User user, ERole[] userRoles)
        {
            var roles = await _context.Roles.Where(r => userRoles.Any(ur => ur.ToString() == r.Name))
                                            .ToListAsync();

            foreach (var role in roles)
            {
                user.UserRoles.Add(new UserRole { IdRole = role.IdRole });
            }

            _context.Users.Add(user);
        }

        public async Task<User> FindByEmailAsync(string email)
        {
            return await _context.Users.Include(u => u.UserRoles)
                                       .ThenInclude(ur => ur.Role)
                                       .SingleOrDefaultAsync(u => u.Email == email);
        }
    }

}
