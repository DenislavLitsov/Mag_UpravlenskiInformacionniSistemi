namespace UpravlenskiInformacionniSistemi.Web.ViewModels.Store
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using AutoMapper;

    using UpravlenskiInformacionniSistemi.Data.Models;
    using UpravlenskiInformacionniSistemi.Services.Mapping;
    using UpravlenskiInformacionniSistemi.Web.ViewModels.Common.Abstractions;

    public class ProductionViewModel : BaseDeletableViewModel<int>, IMapFrom<Production>, IHaveCustomMappings
    {
        public ProductionViewModel()
        {
        }

        public DateTime ProductionDate{ get; set; }

		public ICollection<ItemViewModel> ProducedItems{ get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Production, ProductionViewModel>();
        }
    }
}
