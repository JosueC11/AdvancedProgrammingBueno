using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedProgramming.Data
{
    public interface IEntity
    {
        string UniqueId { get; set; }
    }

    public class Entity : IEntity
    {
        [NotMapped]
        public string UniqueId { get; set; }
    }
}
