namespace UpravlenskiInformacionniSistemi.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using UpravlenskiInformacionniSistemi.Services.Data;
    using UpravlenskiInformacionniSistemi.Web.ViewModels.Store;

    public class ItemTypesController : Controller
    {
        private readonly ItemTypeService itemTypeService;

        public ItemTypesController(ItemTypeService itemTypeService)
        {
            this.itemTypeService = itemTypeService;
        }

        // GET: ItemTypes
        public ActionResult Index()
        {
            var result = this.itemTypeService.GetAllItemTypes().ToList();
            return View(result);
        }

        // GET: ItemTypes/Details/5
        public ActionResult Details(Guid id)
        {
            var item = this.itemTypeService.GetItemType(id);
            return View(item);
        }

        // GET: ItemTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ItemTypes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ItemTypeViewModel itemType)
        {
            try
            {
                await this.itemTypeService.CreateItemType(itemType);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ItemTypes/Edit/5
        public ActionResult Edit(Guid id)
        {
            var item = this.itemTypeService.GetItemType(id);
            return View(item);
        }

        // POST: ItemTypes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Guid id, ItemTypeViewModel itemType)
        {
            try
            {
                await this.itemTypeService.UpdateItemType(id, itemType);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ItemTypes/Delete/5
        public async Task<ActionResult> Delete(Guid id)
        {
            await this.itemTypeService.DeleteItemType(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
