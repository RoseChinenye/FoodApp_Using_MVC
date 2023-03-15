using AutoMapper;
using FoodApp.BLL.Interface;
using FoodApp.BLL.Models;
using Microsoft.AspNetCore.Mvc;


namespace FoodApp.MVC.Controllers
{

    [AutoValidateAntiforgeryToken]
    public class MenuController : Controller
    {
        private readonly IMenuOperations _menuOperations;
        private readonly IMapper _mapper;

        public MenuController(IMenuOperations menuOperations, IMapper mapper)
        {
            _menuOperations = menuOperations;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index(string MenuTypes, string searchString)
        {
            var viewMenuVM = await _menuOperations.ViewMenuAsync(MenuTypes, searchString);
            return View(viewMenuVM);
        }

        public IActionResult New()
        {
            ViewBag.SuccessMsg = TempData["SuccessMsg"];
            return View(new MenuVM());
        }


        [HttpPost]
        public async Task<IActionResult> Save(MenuVM model)
        {
            if (!ModelState.IsValid)
            {
                return View("New");
            }

            var (isSuccessful, message) = await _menuOperations.AddFoodItemAsync(model);

            if (isSuccessful)
            {
                TempData["SuccessMsg"] = message;
                return RedirectToAction("New");
            }

            ModelState.AddModelError(string.Empty, message);
            return View("New");
        }



        public async Task<IActionResult> LearnMore(int id)
        {
            var model = await _menuOperations.ViewFoodItemAsync(id);
            return View(model);
        }

        public async Task<IActionResult> EditFoodItem(int id)
        {
            var menu = await _menuOperations.GetFoodItemAsync(id);
            if (menu == null)
            {
                return NotFound();
            }

            var model = _mapper.Map<MenuVM>(menu);
            return View(model);
        }


        [HttpPost, ActionName("SaveEditedItem")]
        public async Task<IActionResult> SaveEditedItemPost(MenuVM model)
        {
            if (ModelState.IsValid)
            {
                var (isSuccessful, message) = await _menuOperations.EditFoodItemAsync(model);
                if (isSuccessful)
                {
                    TempData["SuccessMsg"] = message;
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", message);
                }
            }
            return View("EditFoodItem", model);
        }


        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var model = await _menuOperations.DeleteFoodItem(id);
            return View(model);
        }


        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (ModelState.IsValid)
            {
                await _menuOperations.DeleteFoodItem(id);
                return RedirectToAction("Index");
            }

            return View("Index");
        }

    }
}
