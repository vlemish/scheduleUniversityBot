using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testDbMySql.Models
{
    [Table("Teachers")]
    public class Teacher
    {
        public Teacher() { }
        [Key]
        public int TeacherId { get; set; }
        public string TeacherName { get; set; }

        public virtual ICollection<Subject> Subjects { get; set; } = new HashSet<Subject>();
        public virtual ICollection<Monday> Mondays { get; set; } = new HashSet<Monday>();
        public override string ToString()
        {
            return $"{TeacherId} {TeacherName}";

        }
    }
}