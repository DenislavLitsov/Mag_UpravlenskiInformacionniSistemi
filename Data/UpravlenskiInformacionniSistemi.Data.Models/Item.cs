namespace UpravlenskiInformacionniSistemi.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using UpravlenskiInformacionniSistemi.Data.Common.Models;

    public class Item : BaseDeletableModel<int>
    {
        public Item()
        {
        }

        [Required]
        public DateTime ExpiryDate { get; set; }

        [Required]
        public Guid ItemTypeId { get; set; }

        public ItemType ItemType { get; set; }

        [Required]
        public int ItemSellId { get; set; }

        public ItemSell ItemSell { get; set; }

        [Required]
        public int ProductionId { get; set; }

        public Production Production { get; set; }
    }
}
