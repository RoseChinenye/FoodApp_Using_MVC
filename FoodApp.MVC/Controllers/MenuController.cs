using FoodApp.BLL.Interface;
using FoodApp.BLL.Models;
using FoodApp.DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace FoodApp.MVC.Controllers
{
    [AutoValidateAntiforgeryToken]
    public class MenuController : Controller
    {
        private readonly IMenuOperations _menuOperations;

        public MenuController(IMenuOperations menuOperations)
        {
            _menuOperations = menuOperations;
        }

        public async Task<IActionResult> Index(string MenuTypes, string searchString)
        {
            var viewMenuVM = await _menuOperations.ViewMenuAsync(MenuTypes, searchString);
            return View(viewMenuVM);
        }

        public IActionResult New()
        {
            return View(new AddFoodItemVM());
        }


        [HttpPost]
        public async Task<IActionResult> Save(AddFoodItemVM model)
        {

            if (ModelState.IsValid)
            {

                var (IsSuccessful, message)  = await _menuOperations.AddFoodItemAsync(model);

                if (IsSuccessful)
                {

                    TempData["SuccessMsg"] = message;

                    return RedirectToAction("Index");
                }

                //ViewBag.ErrMsg = message;


                return View("New");

            }

            return View("New");

        }

        public async Task<IActionResult> LearnMore(int id)
        {
            var model = await _menuOperations.ViewFoodItemAsync(id);
            return View(model);
        }


        public IActionResult EditFoodItem()
        {
            return View(new Menu());
        }

        [HttpPost]
        public async Task<IActionResult> SaveEditedItem(Menu model)
        {
            if (ModelState.IsValid)
            {

            var (IsSuccessful, message)  = await _menuOperations.EditFoodItemAsync(model);

            if (IsSuccessful)
            {

                TempData["SuccessMsg"] = message;

                
            }
                return RedirectToAction("Index");
                //ViewBag.ErrMsg = message;


                //return View("EditFoodItem");

            }
            
            return View("EditFoodItem");

        }
        
        public  async Task<IActionResult> Delete(int id)
        {
            var response = _menuOperations.DeleteFoodItem(id);
            return View(response);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (ModelState.IsValid)
            {

                var model = await _menuOperations.DeleteFoodItem(id);

                //return RedirectToAction("Index");
                return View(model);
            }

            return View("Index");

        }

        /*[HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(DeleteVM model)
        {
            await _menuOperations.DeleteFoodItem(model);
           
            return RedirectToAction(nameof(Index));
        }*/
    }
}
