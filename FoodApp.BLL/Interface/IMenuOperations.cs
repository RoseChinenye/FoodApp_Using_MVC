using FoodApp.BLL.Models;
using System.Threading.Tasks;

namespace FoodApp.BLL.Interface
{
    public interface IMenuOperations
    {
        Task<(bool IsSuccessful, string message)> AddFoodItemAsync(MenuVM VisualModel);
        Task<MenuVM> DeleteFoodItem(int id);
        Task<(bool IsSuccessful, string message)> EditFoodItemAsync(MenuVM model);
        Task<MenuVM> GetFoodItemAsync(int id);
        Task<MenuVM> ViewFoodItemAsync(int? id);
        Task<ViewMenuVM> ViewMenuAsync(string menuTypes, string searchString);

    }
}
