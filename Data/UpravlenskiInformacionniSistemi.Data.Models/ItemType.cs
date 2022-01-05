namespace UpravlenskiInformacionniSistemi.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using UpravlenskiInformacionniSistemi.Data.Common.Models;

    public class ItemType : BaseDeletableModel<Guid>
    {
        public ItemType()
        {
            this.Items = new HashSet<Item>();
        }

        [Required]
        [Range(0, 120)]
        public string Name { get; set; }

        [Required]
        [Range(0, 500)]
        public string Description { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public double Price { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int Quantity { get; set; }

        public ICollection<Item> Items { get; set; }
    }
}
