using AutoMapper;
using FoodApp.BLL.Interface;
using FoodApp.BLL.Models;
using FoodApp.DAL.Entities;
using FoodApp.DAL.Repository;
using System.Threading.Tasks;

namespace FoodApp.BLL.Implementation
{
    public class MenuOperations : IMenuOperations
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IRepository<Menu> _menuRepo;


        public MenuOperations(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _menuRepo = _unitOfWork.GetRepository<Menu>();
        }

        public async Task<(bool IsSuccessful, string message)> AddOrUpdateFoodItemAsync(AddOrUpdateFoodItemVM VisualModel)
        {
            Menu menu = await _menuRepo.GetSingleByAsync(a => a.Title == VisualModel.Title);

            if (menu == null)
            {
                var newMenu = _mapper.Map<AddOrUpdateFoodItemVM, Menu>(VisualModel);
                await _menuRepo.AddAsync(newMenu);

                var rowChanges = await _unitOfWork.SaveChangesAsync();
                return rowChanges > 0 ? (true, $"Item: {VisualModel.Title} was successfully added to the menu!") : (false, "Failed To save changes!");

            }

            _mapper.Map(VisualModel, menu);

            await _unitOfWork.SaveChangesAsync();
            return (true, "Update Successful!");

        }

        public void DeleteFoodItem()
        {
            throw new System.NotImplementedException();
        }

        public void ViewFoodItem()
        {
            throw new System.NotImplementedException();
        }

        public void ViewMenu()
        {
            throw new System.NotImplementedException();
        }
    }
}
