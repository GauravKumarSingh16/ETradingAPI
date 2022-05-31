using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ETradingAPI.models
{
    public class BusinessOwner
    {
        [Key]
        public int BusinessOwnerId { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string BusinessOwnerName { get; set; }
        [Required]
        public string BusinessOwnerType { get; set; }
        [Required]
        public string BusinessOwnerEmail { get; set; }

    }
}
