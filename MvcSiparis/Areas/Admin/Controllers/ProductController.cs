using Microsoft.AspNetCore.Mvc;
using MvcSiparis.Data.Repository.IRepository;

namespace MvcSiparis.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
           var productList = _unitOfWork.Product.GetAll();
            return View(productList);
            
        }
    }
}
