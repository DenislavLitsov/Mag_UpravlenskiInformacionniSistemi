namespace UpravlenskiInformacionniSistemi.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using UpravlenskiInformacionniSistemi.Data.Common.Models;

    public class Sell : BaseDeletableModel<int>
    {
        public Sell()
        {
            this.SoldItems = new HashSet<ItemSell>();
        }

        [Required]
        public DateTime SellDate { get; set; }

        [Required]
        public int ClientId { get; set; }

        public Client Client { get; set; }

        public ICollection<ItemSell> SoldItems { get; set; }
    }
}
