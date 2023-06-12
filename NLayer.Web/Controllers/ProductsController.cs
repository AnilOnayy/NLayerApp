using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NLayer.Core.DTOs.ProductDTOs;
using NLayer.Core.Entities;
using NLayer.Core.Services;
using NLayer.Service.Filters;
using NLayer.Web.Services;

namespace NLayer.Web.Controllers
{
    public class ProductsController : Controller
    {

        private readonly ProductApiServices _productApiServices;
        private readonly CategoryApiService _categoryApiService;

        public ProductsController(ProductApiServices productApiServices, CategoryApiService categoryApiService)
        {
            _productApiServices = productApiServices;
            _categoryApiService = categoryApiService;
        }

        public async Task<IActionResult> Index()
        {
            return View((await _productApiServices.GetProductWithCategoryAsync()));
        }

        public async Task<IActionResult> Save()
        {
            var categories = await _categoryApiService.GetAllAsync();
            ViewBag.CategoryDropdown = new SelectList(categories, "Id", "Name");
            return View();

        }

        [HttpPost]
        public async Task<IActionResult> Save(ProductDto dto)
        {
            if (!ModelState.IsValid)
            {
                var categories = await _categoryApiService.GetAllAsync();
                ViewBag.CategoryDropdown = new SelectList(categories, "Id", "Name", dto.CategoryId);
                return View(dto);
            }

            await _productApiServices.SaveAsync(dto);

            return RedirectToAction(nameof(Index));
        }

        [ServiceFilter(typeof(NotFoundFilter<Product>))]
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var product = await _productApiServices.GetByIdAsync(id);


            var categories = await _categoryApiService.GetAllAsync();
            ViewBag.CategoryDropdown = new SelectList(categories, "Id", "Name", product.CategoryId);

            return View(product);

        }

        [HttpPost]
        public async Task<IActionResult> Update(ProductDto dto)
        {
            if (!ModelState.IsValid)
            {
                var categories = await _categoryApiService.GetAllAsync();
                ViewBag.CategoryDropdown = new SelectList(categories, "Id", "Name", dto.CategoryId);
                return View(dto);
            }

            await _productApiServices.UpdateAsync(dto);
            return RedirectToAction(nameof(Index));

        }

        [ServiceFilter(typeof(NotFoundFilter<Product>))]
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await _productApiServices.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
