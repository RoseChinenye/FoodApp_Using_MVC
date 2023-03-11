using FoodApp.BLL.Models;
using System.Threading.Tasks;

namespace FoodApp.BLL.Interface
{
    public interface IMenuOperations
    {
        Task<(bool IsSuccessful, string message)> AddOrUpdateFoodItemAsync(AddOrUpdateFoodItemVM VisualModel);
        void DeleteFoodItem();
        void ViewFoodItem();
        void ViewMenu();

    }
}
