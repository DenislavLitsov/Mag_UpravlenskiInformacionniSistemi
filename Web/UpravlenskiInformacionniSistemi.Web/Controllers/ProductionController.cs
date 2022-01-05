namespace UpravlenskiInformacionniSistemi.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using UpravlenskiInformacionniSistemi.Services.Data;
    using UpravlenskiInformacionniSistemi.Web.ViewModels.Common;
    using UpravlenskiInformacionniSistemi.Web.ViewModels.Complex;
    using UpravlenskiInformacionniSistemi.Web.ViewModels.Store;

    public class ProductionController : Controller
    {
        private readonly ProductionService productionService;
        private readonly ItemService itemService;
        private readonly ItemTypeService itemTypeService;

        public ProductionController(
            ProductionService productionService,
            ItemService itemService,
            ItemTypeService itemTypeService)
        {
            this.productionService = productionService;
            this.itemService = itemService;
            this.itemTypeService = itemTypeService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var production = this.productionService.GetAllProductions();
            return View(production);
        }

        [HttpGet]
        public ActionResult Produce()
        {
            ProductionComplexViewModel productionComplexViewModel = new ProductionComplexViewModel();
            var typesIds = this.itemTypeService.GetAllItemTypes()
                .Select(x => new StringStringWrapper(x.Name, x.Id.ToString()))
                .ToList();
            productionComplexViewModel.ItemTypesIds = typesIds;
            return View(productionComplexViewModel);
        }


        [HttpPost]
        public async Task<ActionResult> Produce(ProductionComplexViewModel productionComplexViewModel)
        {
            await this.productionService.CreateProduction(productionComplexViewModel);
            return RedirectToAction(nameof(Index));
        }
    }
}
