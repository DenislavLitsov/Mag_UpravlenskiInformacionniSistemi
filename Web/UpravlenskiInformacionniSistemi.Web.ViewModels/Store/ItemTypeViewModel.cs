namespace UpravlenskiInformacionniSistemi.Web.ViewModels.Store
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using AutoMapper;

    using UpravlenskiInformacionniSistemi.Data.Models;
    using UpravlenskiInformacionniSistemi.Services.Mapping;
    using UpravlenskiInformacionniSistemi.Web.ViewModels.Common.Abstractions;

    public class ItemTypeViewModel : BaseDeletableViewModel<int>, IMapFrom<ItemType>, IHaveCustomMappings
    {
        public ItemTypeViewModel()
        {
        }

        public string Name { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public int Quantity { get; set; }

        public ICollection<ItemViewModel> Items { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<ItemType, ItemTypeViewModel>();
        }
    }
}
