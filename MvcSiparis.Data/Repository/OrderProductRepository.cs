using MvcSiparis.Data.Repository.IRepository;
using MvcSiparis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcSiparis.Data.Repository
{
    public class OrderProductRepository : Repository<OrderProduct>, IOrderProductRepository
    {
        private readonly ApplicationDbContext _context;
        public OrderProductRepository(ApplicationDbContext context) : base(context)
        {
            _context = context; 
        }
    }
}
