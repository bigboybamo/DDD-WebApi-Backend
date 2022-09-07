using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perfume.ApplicationCore.Entities
{
    public class PerfumeModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(30)]
        public string? Name { get; set; }

        public string? Brand { get; set; }
        public DateTime CreatedOn { get; set; }

        public bool isDiscontinued { get; set; }
        
    }
}
