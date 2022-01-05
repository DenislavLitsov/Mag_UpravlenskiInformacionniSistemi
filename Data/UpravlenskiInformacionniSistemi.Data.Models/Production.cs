namespace UpravlenskiInformacionniSistemi.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using UpravlenskiInformacionniSistemi.Data.Common.Models;

    public class Production : BaseDeletableModel<int>
    {
        public Production()
        {
            this.ProducedItems = new HashSet<Item>();
            this.ProductionDate = DateTime.Now;
        }

        [Required]
        public DateTime ProductionDate { get; set; }

        public ICollection<Item> ProducedItems { get; set; }
    }
}
