using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedProgramming.Data
{
    public partial class Category : Entity
    {
        [NotMapped]
        public DateTime ReleaseDate { get; set; }
    }
}


