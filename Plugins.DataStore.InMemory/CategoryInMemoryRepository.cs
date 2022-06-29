﻿using DataAccessLibrary;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.InMemory
{
    public class CategoryInMemoryRepository : ICategoryRepository
    {
        private List<Category> categories = new List<Category>();
        public CategoryInMemoryRepository()
        {
            categories = new List<Category>()
            {
                new Category { CategoryId = 1, Name = "Beverage", Description = "Beverage" },
                new Category { CategoryId = 2, Name = "Bakery", Description = "Bakery" },
                new Category { CategoryId = 3, Name = "Meat", Description = "Meat" },
            };
        }

        public void AddCategory(Category category)
        {
            if (categories.Any(x => x.Name.Equals(category.Name, StringComparison.OrdinalIgnoreCase))) return;
            var maxId = categories.Max(x => x.CategoryId);
            category.CategoryId = maxId + 1;

            categories.Add(category);
        }

        public void UpdateCategory(Category category)
        {
            var categoryToUpdate = GetCategoryById(category.CategoryId);
            if (categoryToUpdate != null) categoryToUpdate = category;
        }

        public IEnumerable<Category> GetCategories()
        {
            return categories;
        }

        public Category GetCategoryById(int categoryId)
        {
            return categories.FirstOrDefault(x => x.CategoryId == categoryId);
        }
    }
}