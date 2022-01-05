namespace UpravlenskiInformacionniSistemi.Web.ViewModels.Common.Abstractions
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using AutoMapper;
    using UpravlenskiInformacionniSistemi.Data.Common.Models;

    public abstract class BaseViewModel<TKey>
    {
        [Key]
        public TKey Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap(typeof(BaseModel<TKey>), typeof(BaseViewModel<TKey>));
        }
    }
}
