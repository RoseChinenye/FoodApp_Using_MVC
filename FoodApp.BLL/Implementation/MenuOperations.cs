using AutoMapper;
using FoodApp.BLL.Interface;
using FoodApp.BLL.Models;
using FoodApp.DAL.Entities;
using FoodApp.DAL.Repository;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<(bool IsSuccessful, string message)> AddFoodItemAsync(AddFoodItemVM VisualModel)
        {
            Menu menu = await _menuRepo.GetSingleByAsync(a => a.Title == VisualModel.Title);

            if (menu == null)
            {
                var newMenu = _mapper.Map<AddFoodItemVM, Menu>(VisualModel);
                await _menuRepo.AddAsync(newMenu);

                var rowChanges = await _unitOfWork.SaveChangesAsync();
                return rowChanges > 0 ? (true, $"Item: {VisualModel.Title} was successfully added to the menu!") : (false, "Failed To save changes!");

            }

            _mapper.Map(VisualModel, menu);

            await _unitOfWork.SaveChangesAsync();
            return (true, "Update Successful!");

        }

        public async Task<Menu> DeleteFoodItem(int id)
        {
            var menu = await _menuRepo.GetByIdAsync(id);
            if (menu != null)
            {
                await _menuRepo.DeleteAsync(menu);
                await _unitOfWork.SaveChangesAsync();

                return menu;
            }
            
            throw new ArgumentNullException(nameof(_menuRepo), "Menu doesn't exist!");

        }

        public async Task<(bool IsSuccessful, string message)> EditFoodItemAsync(Menu model)
        {
            var menu = await _menuRepo.GetByIdAsync(model.Id);

            if (menu == null)
            {
                return (false, "Food Item not found!");
            }

            var newMenu = _mapper.Map(model, menu);

            await _menuRepo.UpdateAsync(newMenu);
            await _unitOfWork.SaveChangesAsync();

            return (true, "Update Sucessfull!");
        }

        public async Task<AddFoodItemVM> ViewFoodItemAsync(int? id)
        {
            var menu = await _menuRepo.GetByIdAsync(id);

            if (menu == null)
            {
                return null;
            }

            var foodItems = _mapper.Map<Menu>(menu); 

            return foodItems;
        }


        public async Task<ViewMenuVM> ViewMenuAsync(string menuTypes, string searchString)
        {
            if (_menuRepo == null)
            {
                throw new ArgumentNullException(nameof(_menuRepo), "Entity set 'Menu' is null");
            }

            var categoryQuery = (await _menuRepo.GetAllAsync()).OrderBy(m => m.Category.ToLower()).Select(m => m.Category.ToLower());


            var menuLists = _menuRepo.GetAll();
            if (!string.IsNullOrEmpty(searchString))
            {
                menuLists = menuLists.Where(s => s.Title.ToLower()!.Contains(searchString.ToLower()));
            }
            if (!string.IsNullOrEmpty(menuTypes))
            {
                menuLists = menuLists.Where(g => g.Category.ToLower() == menuTypes);
            }

            var viewMenuVM = new ViewMenuVM
            {
                Category = new SelectList(await Task.Run(() => categoryQuery.Distinct().ToList())),
                MenuList = await Task.Run(() => menuLists.ToList())
            };
            return viewMenuVM;
        }




    }
}
