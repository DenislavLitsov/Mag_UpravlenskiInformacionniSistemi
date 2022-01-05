namespace UpravlenskiInformacionniSistemi.Services.Data.Managers
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
    using UpravlenskiInformacionniSistemi.Web.ViewModels.Store;

    public class ItemService
    {
        private readonly IDeletableEntityRepository<Item> itemsRepo;

        public ItemService(IDeletableEntityRepository<Item> itemsRepo)
        {
            this.itemsRepo = itemsRepo;
        }

        public ItemViewModel GetItem(int id)
        {
            var dbModel = this.itemsRepo.All()
                .FirstOrDefault(x => x.Id == id);
            if (dbModel != null)
            {
                var mappedModel = AutoMapperConfig.MapperInstance.Map<ItemViewModel>(dbModel);
                return mappedModel;
            }

            return null;
        }

        public IEnumerable<ItemViewModel> GetAllItems()
        {
            var dbModels = this.itemsRepo.All()
                .ToList();

            var mappedModel = AutoMapperConfig.MapperInstance.Map<IEnumerable<ItemViewModel>>(dbModels);
            return mappedModel;
        }

        public async Task CreateItem(ItemViewModel inputModel)
        {
            var newDbModel = new Item();
            this.UpdateProps(newDbModel, inputModel);

            await this.itemsRepo.AddAsync(newDbModel);
            await this.itemsRepo.SaveChangesAsync();
        }

        public async Task UpdateItem(int itemId, ItemViewModel inputModel)
        {
            var dbModel = this.itemsRepo.All().FirstOrDefault(x => x.Id == itemId);
            if (dbModel != null)
            {
                this.UpdateProps(dbModel, inputModel);
                this.itemsRepo.Update(dbModel);
                await this.itemsRepo.SaveChangesAsync();
            }
        }

        public async Task DeleteItem(int itemId)
        {
            var dbModel = this.itemsRepo.All()
                .FirstOrDefault(x => x.Id == itemId);
            if (dbModel != null)
            {
                this.itemsRepo.Delete(dbModel);
                await this.itemsRepo.SaveChangesAsync();
            }
        }

        private void UpdateProps(Item destination, ItemViewModel source)
        {
            destination.ProductionDate = source.ProductionDate;
            destination.ExpiryDate = source.ExpiryDate;
            destination.ItemTypeId = source.ItemTypeId;
            destination.ItemSellId = source.ItemSellId;
        }
    }
}
