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
    using UpravlenskiInformacionniSistemi.Web.ViewModels.Store;

    public class ItemTypeService
    {
        private readonly IDeletableEntityRepository<ItemType> itemTypesRepo;

        public ItemTypeService(IDeletableEntityRepository<ItemType> itemTypesRepo)
        {
            this.itemTypesRepo = itemTypesRepo;
        }

        public ItemTypeViewModel GetItemType(Guid id)
        {
            var dbModel = this.itemTypesRepo.All()
                .FirstOrDefault(x => x.Id == id);
            if (dbModel != null)
            {
                var mappedModel = AutoMapperConfig.MapperInstance.Map<ItemTypeViewModel>(dbModel);
                return mappedModel;
            }

            return null;
        }

        public IEnumerable<ItemTypeViewModel> GetAllItemTypes()
        {
            var dbModels = this.itemTypesRepo.All()
                .ToList();

            var mappedModel = AutoMapperConfig.MapperInstance.Map<IEnumerable<ItemTypeViewModel>>(dbModels);
            return mappedModel;
        }

        public async Task CreateItemType(ItemTypeViewModel inputModel)
        {
            var newDbModel = new ItemType();
            this.UpdateProps(newDbModel, inputModel);

            await this.itemTypesRepo.AddAsync(newDbModel);
            await this.itemTypesRepo.SaveChangesAsync();
        }

        public async Task UpdateItemType(Guid itemTypeId, ItemTypeViewModel inputModel)
        {
            var dbModel = this.itemTypesRepo.All().FirstOrDefault(x => x.Id == itemTypeId);
            if (dbModel != null)
            {
                this.UpdateProps(dbModel, inputModel);
                this.itemTypesRepo.Update(dbModel);
                await this.itemTypesRepo.SaveChangesAsync();
            }
        }

        public async Task DeleteItemType(Guid itemTypeId)
        {
            var dbModel = this.itemTypesRepo.All()
                .FirstOrDefault(x => x.Id == itemTypeId);
            if (dbModel != null)
            {
                this.itemTypesRepo.Delete(dbModel);
                await this.itemTypesRepo.SaveChangesAsync();
            }
        }

        private void UpdateProps(ItemType destination, ItemTypeViewModel source)
        {
            destination.Name = source.Name;
            destination.Description = source.Description;
            destination.Price = source.Price;
        }
    }
}
