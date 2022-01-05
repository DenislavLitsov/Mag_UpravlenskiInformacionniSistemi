namespace UpravlenskiInformacionniSistemi.Web.ViewModels.Store
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using AutoMapper;

    using UpravlenskiInformacionniSistemi.Data.Models;
    using UpravlenskiInformacionniSistemi.Services.Mapping;
    using UpravlenskiInformacionniSistemi.Web.ViewModels.Common.Abstractions;

    public class ItemViewModel : BaseDeletableViewModel<int>, IMapFrom<Item>, IHaveCustomMappings
    {
        public ItemViewModel()
        {
        }

        public DateTime ProductionDate { get; set; }

        public DateTime ExpiryDate { get; set; }

        public Guid ItemTypeId { get; set; }

        public ItemTypeViewModel ItemType { get; set; }

        public int ItemSellId { get; set; }

        public ItemSellViewModel ItemSell { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Item, ItemViewModel>();
        }
    }
}
