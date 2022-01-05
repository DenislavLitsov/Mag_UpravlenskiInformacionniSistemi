namespace UpravlenskiInformacionniSistemi.Web.ViewModels.Store
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using AutoMapper;

    using UpravlenskiInformacionniSistemi.Data.Models;
    using UpravlenskiInformacionniSistemi.Services.Mapping;
    using UpravlenskiInformacionniSistemi.Web.ViewModels.Common.Abstractions;

    public class ItemTypeViewModel : BaseDeletableViewModel<Guid>, IMapFrom<ItemType>, IHaveCustomMappings
    {
        public ItemTypeViewModel()
        {
        }

        [Required]
        [MinLength(3)]
        [MaxLength(75)]
        public string Name { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(500)]
        public string Description { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public double Price { get; set; }

        public ICollection<ItemViewModel> Items { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<ItemType, ItemTypeViewModel>();
        }
    }
}
