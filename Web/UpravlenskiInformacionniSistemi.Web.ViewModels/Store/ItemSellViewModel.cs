namespace UpravlenskiInformacionniSistemi.Web.ViewModels.Store
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using AutoMapper;

    using UpravlenskiInformacionniSistemi.Data.Models;
    using UpravlenskiInformacionniSistemi.Services.Mapping;
    using UpravlenskiInformacionniSistemi.Web.ViewModels.Common.Abstractions;

    public class ItemSellViewModel : BaseDeletableViewModel<int>, IMapFrom<ItemSell>, IHaveCustomMappings
    {
        public ItemSellViewModel()
        {
        }

        public double SellPrice { get; set; }

        public int SellId { get; set; }

        public SellViewModel Sell { get; set; }

        public int ItemId { get; set; }

        public ItemViewModel Item { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<ItemSell, ItemSellViewModel>();
        }
    }
}
