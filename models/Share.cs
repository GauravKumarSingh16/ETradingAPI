using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ETradingAPI.models
{
    public class Share
    {
        [Key]
        public int ShareId { get; set; }
        public string ShareName { get; set; }
        [Required]
        public double ShareQuantity { get; set; }
        [Required]
        public double SharePrice { get; set; }
    }
}
