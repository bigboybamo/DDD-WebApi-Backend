using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perfume.ApplicationCore.DTOs
{
    public class CreatePerfumeRequest
    {
        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string? Name { get; set; }

        [Required]
        public string? Brand { get; set; }

    }

    public class PerfumeResponse
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Brand { get; set; }
    }

}
