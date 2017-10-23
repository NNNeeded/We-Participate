using System.Collections.Generic;
using ProftaakASP.Models;

// Yorick

namespace ProftaakASP.App_DAL
{
    public interface ICategorySQLContext
    {
        List<Category> getAllCategories();
        void newCategory(Category C);
        void deleteCategory(Category C);
        void alterCategory(Category C);
    }
}