namespace UpravlenskiInformacionniSistemi.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using UpravlenskiInformacionniSistemi.Data.Common.Models;

    public class Client : BaseDeletableModel<int>
    {
        public Client()
        {
            this.Sells = new HashSet<Sell>();
        }

        [Required]
        [Range(0, 100)]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [Required]
        [Range(0, 500)]
        [DataType(DataType.Text)]
        public string DeliveryAddress { get; set; }

        [Required]
        [Range(10, 20)]
        [DataType(DataType.PhoneNumber)]
        public string Telephone { get; set; }

        public ICollection<Sell> Sells { get; set; }
    }
}
