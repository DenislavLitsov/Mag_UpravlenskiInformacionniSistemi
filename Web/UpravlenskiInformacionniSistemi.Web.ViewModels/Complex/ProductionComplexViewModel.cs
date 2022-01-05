namespace UpravlenskiInformacionniSistemi.Web.ViewModels.Complex
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using Common;
    using Store;

    public class ProductionComplexViewModel
    {
        public ProductionComplexViewModel()
        {
        }

        [Required]
        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }

        [Required]
        [Range(0, 100)]
        [DisplayName("Years to expiration")]
        public int YearsToExpiration { get; set; }

        [Required]
        [Range(0, 12)]
        [DisplayName("Months more")]
        public int MonthsToExpiration { get; set; }

        [Required]
        public string ItemTypeId { get; set; }

        public IEnumerable<StringStringWrapper> ItemTypesIds { get; set; }
    }
}
