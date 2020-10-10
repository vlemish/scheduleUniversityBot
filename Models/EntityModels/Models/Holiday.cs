using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testDbMySql.Models
{
    [Table("Holidays")]
    public partial class Holiday
    {

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime From { get; set; }

        public DateTime To { get; set; }

        public override string ToString()
        {
            return $"{Id}\n{Name}\n{From.Date}\n{To.Date}";
        }
    }
}
