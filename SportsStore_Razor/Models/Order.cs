using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore_Razor.Models
{
    public class Order
    {
        [BindNever]
        public int OrderId { get; set; }
        [BindNever]
        public ICollection<CartLine> Lines { get; set; }
        [Required(ErrorMessage = "Proszę podać imięc i nazwisko")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Proszę podać pierwszy wiersz adresu")]
        public string AdressLine1 { get; set; }
        public string AdressLine2 { get; set; }
        public string AdressLine3 { get; set; }
        [Required(ErrorMessage = "Proszę podac nazwę miasta")]
        public string City { get; set; }
        [Required(ErrorMessage = "Proszę podac nazwę województwa")]
        public string State { get; set; }
        public string Zip { get; set; }
        [Required(ErrorMessage = "Proszę podać nazwę kraju")]
        public string Country { get; set; }
        public bool GiftWrap { get; set; }
    }
}
