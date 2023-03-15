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

        public async Task<(bool IsSuccessful, string message)> AddFoodItemAsync(MenuVM VisualModel)
        {
            var existingMenu = await _menuRepo.GetSingleByAsync(a => a.Title == VisualModel.Title);

            if (existingMenu != null)
            {
                return (false, $"Failed to add item: {VisualModel.Title}. Item already exists in the menu!");
            }

            var newMenu = _mapper.Map<MenuVM, Menu>(VisualModel);
            await _menuRepo.AddAsync(newMenu);

            await _unitOfWork.SaveChangesAsync();
            return (true, $"Item: {VisualModel.Title} was successfully added to the menu!");
        }


        public async Task<MenuVM> DeleteFoodItem(int id)
        {
            var menu = await _menuRepo.GetByIdAsync(id);
            if (menu != null)
            {
                await _menuRepo.DeleteAsync(menu);
                await _unitOfWork.SaveChangesAsync();

                var model = _mapper.Map<MenuVM>(menu);
                return model;

            }
            return null;
        }

        public async Task<MenuVM> GetFoodItemAsync(int id)
        {
            var menu = await _menuRepo.GetByIdAsync(id);
            return _mapper.Map<MenuVM>(menu);
        }

        public async Task<(bool IsSuccessful, string message)> EditFoodItemAsync(MenuVM model)
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

        public async Task<MenuVM> ViewFoodItemAsync(int? id)
        {
            var menu = await _menuRepo.GetByIdAsync(id);

            if (menu == null)
            {
                return null;
            }

            var foodItems = _mapper.Map<MenuVM>(menu);

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
