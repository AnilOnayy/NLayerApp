﻿using Microsoft.EntityFrameworkCore;
using NLayer.Core.Entities;
using NLayer.Core.Repositories;

namespace NLayer.Repository.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<Category>> GetCategoriesWithProductsAsync()
        {
            var data = await _context.Categories.ToListAsync();
            return data;
        }

        public async Task<Category> GetCategoryByIdWithProductsAsync(int id)
        {
            return await _context
                .Categories
                .Include(x => x.Products)
                .Where(x => x.Id == id)
                .SingleOrDefaultAsync();
        }
    }
}
