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

        [Required]
        [MinLength(3)]
        [MaxLength(75)]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [Required]
        [MinLength(20)]
        [MaxLength(500)]
        [DataType(DataType.Text)]
        public string DeliveryAddress { get; set; }

        [Required]
        [MinLength(10)]
        [MaxLength(20)]
        [DataType(DataType.PhoneNumber)]
        public string Telephone { get; set; }

        public ICollection<SellViewModel> Sells { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Client, ClientViewModel>();
        }
    }
}
