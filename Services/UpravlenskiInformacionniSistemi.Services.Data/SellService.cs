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

    public class SellService
    {
        private readonly IDeletableEntityRepository<Sell> sellsRepo;

        public SellService(IDeletableEntityRepository<Sell> sellsRepo)
        {
            this.sellsRepo = sellsRepo;
        }

        public SellViewModel GetSell(int id)
        {
            var dbModel = this.sellsRepo.All()
                .FirstOrDefault(x => x.Id == id);
            if (dbModel != null)
            {
                var mappedModel = AutoMapperConfig.MapperInstance.Map<SellViewModel>(dbModel);
                return mappedModel;
            }

            return null;
        }

        public IEnumerable<SellViewModel> GetAllSells()
        {
            var dbModels = this.sellsRepo.All()
                .ToList();

            var mappedModel = AutoMapperConfig.MapperInstance.Map<IEnumerable<SellViewModel>>(dbModels);
            return mappedModel;
        }

        public async Task CreateSell(SellViewModel inputModel)
        {
            var newDbModel = new Sell();
            this.UpdateProps(newDbModel, inputModel);

            await this.sellsRepo.AddAsync(newDbModel);
            await this.sellsRepo.SaveChangesAsync();
        }

        public async Task UpdateSell(int sellId, SellViewModel inputModel)
        {
            var dbModel = this.sellsRepo.All().FirstOrDefault(x => x.Id == sellId);
            if (dbModel != null)
            {
                this.UpdateProps(dbModel, inputModel);
                this.sellsRepo.Update(dbModel);
                await this.sellsRepo.SaveChangesAsync();
            }
        }

        public async Task DeleteSell(int sellId)
        {
            var dbModel = this.sellsRepo.All()
                .FirstOrDefault(x => x.Id == sellId);
            if (dbModel != null)
            {
                this.sellsRepo.Delete(dbModel);
                await this.sellsRepo.SaveChangesAsync();
            }
        }

        private void UpdateProps(Sell destination, SellViewModel source)
        {
            destination.SellDate = source.SellDate;
			destination.ClientId = source.ClientId;
        }
    }
}
