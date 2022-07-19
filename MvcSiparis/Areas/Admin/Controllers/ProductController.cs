using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MvcSiparis.Data.Repository.IRepository;
using MvcSiparis.Models;
using MvcSiparis.Models.ViewModels;

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
       
        public IActionResult Crup(int? id)
        {
            ProductVM productVM = new()
            {
                Product = new(),
                CategoryList = _unitOfWork.Category.GetAll().Select(l => new SelectListItem

                {
                    Text = l.Name,
                    Value = l.Id.ToString()
                }
                )
            };


            if (id == null || id <= 0)
            {
                return View(productVM);
            }
             productVM.Product = _unitOfWork.Product.GetFirtsOrDefault(x => x.Id == id);
            if (productVM.Product == null)
            {
                return View(productVM);
            }
            return View(productVM);
        }
        [HttpPost]
        public IActionResult Crup(ProductVM productVM)
        {
            if (productVM.Product.Id <= 0)
            {
                _unitOfWork.Product.Add(productVM.Product);
            }
            else
            {
                _unitOfWork.Product.Update(productVM.Product);
            }
              
                _unitOfWork.Save();
                return RedirectToAction("Index");
          
        }
        public IActionResult Delete(int id)
        {
            if (id == null || id <= 0)
            {
                return NotFound();
            }
            var product = _unitOfWork.Product.GetFirtsOrDefault(x => x.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            _unitOfWork.Product.Remove(product);
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }


    }
}
