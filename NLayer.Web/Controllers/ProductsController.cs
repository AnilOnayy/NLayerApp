using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NLayer.Core.DTOs.ProductDTOs;
using NLayer.Core.Entities;
using NLayer.Core.Services;
using NLayer.Service.Filters;

namespace NLayer.Web.Controllers
{
    public class ProductsController : Controller
    {

        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;


        public ProductsController(IProductService productService, ICategoryService categoryService, IMapper mapper)
        {
            _productService = productService;
            _categoryService = categoryService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _productService.GetWithCategoryAsync());
        }

        public async Task<IActionResult> Save()
        {
            var categories = _categoryService.GetCategoryDtos();
            ViewBag.CategoryDropdown = new SelectList(categories, "Id", "Name");
            return View();

        }

        [HttpPost]
        public async Task<IActionResult> Save(ProductDto dto)
        {
            if (!ModelState.IsValid)
            {
                var categories = _categoryService.GetCategoryDtos();
                ViewBag.CategoryDropdown = new SelectList(categories, "Id", "Name", dto.CategoryId);
                return View(dto);
            }

            await _productService.AddAsync(_mapper.Map<Product>(dto));

            return RedirectToAction(nameof(Index));
        }

        [ServiceFilter(typeof(NotFoundFilter<Product>))]
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {

            var categories = _categoryService.GetCategoryDtos();
            ViewBag.CategoryDropdown = new SelectList(categories, "Id", "Name", id);

            var product = await _productService.GetByIdAsync(id);


            var productDto = _mapper.Map<ProductDto>(product);


            return View(productDto);

        }

        [HttpPost]
        public async Task<IActionResult> Update(ProductDto dto)
        {
            if (!ModelState.IsValid)
            {
                var categories = _categoryService.GetCategoryDtos();
                ViewBag.CategoryDropdown = new SelectList(categories, "Id", "Name", dto.CategoryId);
                return View(dto);
            }

            var product = _mapper.Map<Product>(dto);
            await _productService.UpdateAsync(product);



            return RedirectToAction(nameof(Index));

        }

        [ServiceFilter(typeof(NotFoundFilter<Product>))]
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await _productService.RemoveAsync(await _productService.GetByIdAsync(id));

            return RedirectToAction(nameof(Index));
        }
    }
}
