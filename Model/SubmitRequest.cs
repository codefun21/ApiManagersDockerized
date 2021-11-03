using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiManagers.Model
{
    public class SubmitRequest
    {
        [Required]
        public string firstName { get; set; }

        [Required]
        public string lastName { get; set; }

        public string email { get; set; }

        public string phoneNumber { get; set; }

        [Required]
        public string supervisor { get; set; }

    }
}
