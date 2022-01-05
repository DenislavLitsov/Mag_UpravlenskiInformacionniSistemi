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

        public ICollection<Sell> Sells { get; set; }
    }
}
