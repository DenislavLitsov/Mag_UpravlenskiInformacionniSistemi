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

    public class ItemSellService
    {
        private readonly IDeletableEntityRepository<ItemSell> itemSellsRepo;

        public ItemSellService(IDeletableEntityRepository<ItemSell> itemSellsRepo)
        {
            this.itemSellsRepo = itemSellsRepo;
        }

        public ItemSellViewModel GetItemSell(int id)
        {
            var dbModel = this.itemSellsRepo.All()
                .FirstOrDefault(x => x.Id == id);
            if (dbModel != null)
            {
                var mappedModel = AutoMapperConfig.MapperInstance.Map<ItemSellViewModel>(dbModel);
                return mappedModel;
            }

            return null;
        }

        public IEnumerable<ItemSellViewModel> GetAllItemSells()
        {
            var dbModels = this.itemSellsRepo.All()
                .ToList();

            var mappedModel = AutoMapperConfig.MapperInstance.Map<IEnumerable<ItemSellViewModel>>(dbModels);
            return mappedModel;
        }

        public async Task CreateItemSell(ItemSellViewModel inputModel)
        {
            var newDbModel = new ItemSell();
            this.UpdateProps(newDbModel, inputModel);

            await this.itemSellsRepo.AddAsync(newDbModel);
            await this.itemSellsRepo.SaveChangesAsync();
        }

        public async Task UpdateItemSell(int itemSellId, ItemSellViewModel inputModel)
        {
            var dbModel = this.itemSellsRepo.All().FirstOrDefault(x => x.Id == itemSellId);
            if (dbModel != null)
            {
                this.UpdateProps(dbModel, inputModel);
                this.itemSellsRepo.Update(dbModel);
                await this.itemSellsRepo.SaveChangesAsync();
            }
        }

        public async Task DeleteItemSell(int itemSellId)
        {
            var dbModel = this.itemSellsRepo.All()
                .FirstOrDefault(x => x.Id == itemSellId);
            if (dbModel != null)
            {
                this.itemSellsRepo.Delete(dbModel);
                await this.itemSellsRepo.SaveChangesAsync();
            }
        }

        private void UpdateProps(ItemSell destination, ItemSellViewModel source)
        {
            destination.SellPrice = source.SellPrice;
            destination.SellId = source.SellId;
            destination.ItemId = source.ItemId;
        }
    }
}
