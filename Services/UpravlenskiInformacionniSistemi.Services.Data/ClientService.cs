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

    public class ClientService
    {
        private readonly IDeletableEntityRepository<Client> clientsRepo;

        public ClientService(IDeletableEntityRepository<Client> clientsRepo)
        {
            this.clientsRepo = clientsRepo;
        }

        public ClientViewModel GetClient(int id)
        {
            var dbModel = this.clientsRepo.All()
                .FirstOrDefault(x => x.Id == id);
            if (dbModel != null)
            {
                var mappedModel = AutoMapperConfig.MapperInstance.Map<ClientViewModel>(dbModel);
                return mappedModel;
            }

            return null;
        }

        public IEnumerable<ClientViewModel> GetAllClients()
        {
            var dbModels = this.clientsRepo.All()
                .ToList();

            var mappedModel = AutoMapperConfig.MapperInstance.Map<IEnumerable<ClientViewModel>>(dbModels);
            return mappedModel;
        }

        public async Task CreateClient(ClientViewModel inputModel)
        {
            var newDbModel = new Client();
            this.UpdateProps(newDbModel, inputModel);

            await this.clientsRepo.AddAsync(newDbModel);
            await this.clientsRepo.SaveChangesAsync();
        }

        public async Task UpdateClient(int clientId, ClientViewModel inputModel)
        {
            var dbModel = this.clientsRepo.All().FirstOrDefault(x => x.Id == clientId);
            if (dbModel != null)
            {
                this.UpdateProps(dbModel, inputModel);
                this.clientsRepo.Update(dbModel);
                await this.clientsRepo.SaveChangesAsync();
            }
        }

        public async Task DeleteClient(int clientId)
        {
            var dbModel = this.clientsRepo.All()
                .FirstOrDefault(x => x.Id == clientId);
            if (dbModel != null)
            {
                this.clientsRepo.Delete(dbModel);
                await this.clientsRepo.SaveChangesAsync();
            }
        }

        private void UpdateProps(Client destination, ClientViewModel source)
        {
            destination.Name = source.Name;
            destination.DeliveryAddress = source.DeliveryAddress;
            destination.Telephone = source.Telephone;
        }
    }
}
