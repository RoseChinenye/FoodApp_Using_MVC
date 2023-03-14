using FoodApp.DAL.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace FoodApp.BLL.Models
{
    public class ViewMenuVM
    {
        public List<Menu>? MenuList { get; set; }
        public SelectList? Category { get; set; }
        public string? MenuTypes { get; set; }
        public string? SearchString { get; set; }
    }
}
