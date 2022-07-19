using MvcSiparis.Data.Repository.IRepository;
using MvcSiparis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcSiparis.Data.Repository
{
    public class AppUserRepository : Repository<AppUser>, IAppUserRepository
    {
        private readonly ApplicationDbContext _context;
        public AppUserRepository(ApplicationDbContext context) : base(context)
        {
            _context = context; 
        }
    }
}
