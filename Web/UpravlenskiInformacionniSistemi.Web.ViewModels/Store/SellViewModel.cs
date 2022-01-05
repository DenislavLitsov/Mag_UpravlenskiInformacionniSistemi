namespace UpravlenskiInformacionniSistemi.Web.ViewModels.Store
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using AutoMapper;

    using UpravlenskiInformacionniSistemi.Data.Models;
    using UpravlenskiInformacionniSistemi.Services.Mapping;
    using UpravlenskiInformacionniSistemi.Web.ViewModels.Common.Abstractions;

    public class SellViewModel : BaseDeletableViewModel<int>, IMapFrom<Sell>, IHaveCustomMappings
    {
        public SellViewModel()
        {
        }

        [Required]
        public DateTime SellDate { get; set; }

        public int ClientId { get; set; }

        public ClientViewModel Client { get; set; }

        public ICollection<ItemSellViewModel> SoldItems { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Sell, SellViewModel>();
        }
    }
}
