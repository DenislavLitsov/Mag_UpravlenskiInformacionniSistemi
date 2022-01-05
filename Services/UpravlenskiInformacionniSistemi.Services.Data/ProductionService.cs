namespace UpravlenskiInformacionniSistemi.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    using UpravlenskiInformacionniSistemi.Data.Common.Repositories;
    using UpravlenskiInformacionniSistemi.Data.Models;
    using UpravlenskiInformacionniSistemi.Services.Mapping;
    using UpravlenskiInformacionniSistemi.Web.ViewModels.Common;
    using UpravlenskiInformacionniSistemi.Web.ViewModels.Complex;
    using UpravlenskiInformacionniSistemi.Web.ViewModels.Store;

    public class ProductionService
    {
        private readonly IDeletableEntityRepository<Production> productionsRepo;

        public ProductionService(IDeletableEntityRepository<Production> productionsRepo)
        {
            this.productionsRepo = productionsRepo;
        }

        public ProductionViewModel GetProduction(int id)
        {
            var dbModel = this.productionsRepo.All()
                .FirstOrDefault(x => x.Id == id);
            if (dbModel != null)
            {
                var mappedModel = AutoMapperConfig.MapperInstance.Map<ProductionViewModel>(dbModel);
                return mappedModel;
            }

            return null;
        }

        public IEnumerable<ProductionViewModel> GetAllProductions()
        {
            var dbModels = this.productionsRepo.All()
                .Include(x=>x.ProducedItems)
                    .ThenInclude(x=>x.ItemType)
                .ToList();

            var mappedModel = AutoMapperConfig.MapperInstance.Map<IEnumerable<ProductionViewModel>>(dbModels);
            return mappedModel;
        }

        public async Task CreateProduction(ProductionViewModel inputModel)
        {
            var newDbModel = new Production();
            this.UpdateProps(newDbModel, inputModel);

            await this.productionsRepo.AddAsync(newDbModel);
            await this.productionsRepo.SaveChangesAsync();
        }

        public async Task CreateProduction(ProductionComplexViewModel productionComplexViewModel)
        {
            var productionDate = DateTime.Now;
            Production production = new Production();
            production.ProductionDate = productionDate;

            List<Item> items = new List<Item>();
            for (int i = 0; i < productionComplexViewModel.Quantity; i++)
            {
                var newItem = new Item()
                {
                    ItemTypeId = Guid.Parse(productionComplexViewModel.ItemTypeId),
                    ExpiryDate = productionDate.AddYears(productionComplexViewModel.YearsToExpiration).AddMonths(productionComplexViewModel.MonthsToExpiration),
                };

                items.Add(newItem);
            }

            production.ProducedItems = items;
            await this.productionsRepo.AddAsync(production);
            await this.productionsRepo.SaveChangesAsync();
        }

        public async Task UpdateProduction(int productionId, ProductionViewModel inputModel)
        {
            var dbModel = this.productionsRepo.All().FirstOrDefault(x => x.Id == productionId);
            if (dbModel != null)
            {
                this.UpdateProps(dbModel, inputModel);
                this.productionsRepo.Update(dbModel);
                await this.productionsRepo.SaveChangesAsync();
            }
        }

        public async Task DeleteProduction(int productionId)
        {
            var dbModel = this.productionsRepo.All()
                .FirstOrDefault(x => x.Id == productionId);
            if (dbModel != null)
            {
                this.productionsRepo.Delete(dbModel);
                await this.productionsRepo.SaveChangesAsync();
            }
        }

        private void UpdateProps(Production destination, ProductionViewModel source)
        {
            destination.ProductionDate = source.ProductionDate;
        }
    }
}
