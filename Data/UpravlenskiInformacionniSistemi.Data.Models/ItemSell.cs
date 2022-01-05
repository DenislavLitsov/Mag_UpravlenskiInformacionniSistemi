namespace UpravlenskiInformacionniSistemi.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Text;

    using UpravlenskiInformacionniSistemi.Data.Common.Models;

    public class ItemSell : BaseDeletableModel<int>
    {
        public ItemSell()
        {
        }

        [Required]
        [Range(0, double.MaxValue)]
        public double SellPrice { get; set; }

        [Required]
        public int SellId { get; set; }

        public Sell Sell { get; set; }

        [Required]
        [ForeignKey("Item")]
        public int ItemId { get; set; }

        public Item Item { get; set; }
    }
}
