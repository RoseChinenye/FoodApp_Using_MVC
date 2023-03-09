using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodApp.BLL.Interface
{
    public interface IMenuOperations
    {
        void AddFoodItem();
        void UpdateFoodItem();
        void DeleteFoodItem();
        void ViewMenu();
        
    }
}
