namespace UpravlenskiInformacionniSistemi.Web.ViewModels.Store
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using AutoMapper;

    using UpravlenskiInformacionniSistemi.Data.Models;
    using UpravlenskiInformacionniSistemi.Services.Mapping;
    using UpravlenskiInformacionniSistemi.Web.ViewModels.Common.Abstractions;

    public class ClientViewModel : BaseDeletableViewModel<int>, IMapFrom<Client>, IHaveCustomMappings
    {
        public ClientViewModel()
        {
        }

        public string Name { get; set; }

        public string DeliveryAddress { get; set; }

        public string Telephone { get; set; }

        public ICollection<SellViewModel> Sells { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Client, ClientViewModel>();
        }
    }
}
