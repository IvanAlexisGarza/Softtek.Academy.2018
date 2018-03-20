using Softte.Academy2018.ToDoListApp.Client.Contracts;
using Softte.Academy2018.ToDoListApp.Client.Implementations;
using Softtek.Academia2018.ToDoListApp.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Softtek.Academy2018.ToDoListApp.Web.Controllers
{
    public class ItemController : Controller
    {
        private readonly IItemClient itemClient = new ItemClient();

        [Route("")]
        public async Task<ActionResult> ItemManager()
        {
            ICollection<ItemDTO> items = await itemClient.GetAllItems();

            return View(items);
        }

        [Route("")]
        public ActionResult AddItem()
        {
            return View();
        }

        [Route("{id}")]
        public async Task<ActionResult> EditItem(int id)
        {
            ItemDTO item = await itemClient.GetItembyId(id);

            return View(item);
        }

        [HttpPost]
        public async Task<ActionResult> EditItem(ItemDTO itemDTO)
        {
            if (!ModelState.IsValid)
            {
                return View("EditItem");
            }

            bool updated = await itemClient.UpdateItem(itemDTO);

            if (!updated) TempData["message"] = "Ops! There has been an error trying to update this item";

            else TempData["message"] = "Item updated succesfully!";

            return RedirectToAction("ItemManager", "Item");
        }

        [HttpPost]
        public async Task<ActionResult> AddItem(ItemDTO itemDTO)
        {
            if (!ModelState.IsValid)
            {
                return View("AddItem");
            }

            bool added = await itemClient.AddItem(itemDTO);

            if (!added) TempData["message"] = "Ops! There has been an error trying to create this item";

            else TempData["message"] = "Item created succesfully!";

            return RedirectToAction("ItemManager", "Item");
        }

        //[Route("Items/{id}")]
        //public async Task<ActionResult> EditItem(int id)
        //{
        //    ItemDTO item = await itemClient.GetItembyId(id);

        //    return View(item);
        //}
    }
}