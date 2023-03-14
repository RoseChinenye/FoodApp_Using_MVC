using FoodApp.BLL.Models;
using FoodApp.DAL.Entities;
using System.Threading.Tasks;

namespace FoodApp.BLL.Interface
{
    public interface IMenuOperations
    {
        Task<(bool IsSuccessful, string message)> AddFoodItemAsync(AddFoodItemVM VisualModel);
        Task<Menu> DeleteFoodItem(int id);
        Task<(bool IsSuccessful, string message)> EditFoodItemAsync(Menu model);
        Task<AddFoodItemVM> ViewFoodItemAsync(int? id);
        Task<ViewMenuVM> ViewMenuAsync(string menuTypes, string searchString);

    }
}
