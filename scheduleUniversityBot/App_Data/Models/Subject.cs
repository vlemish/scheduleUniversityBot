using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testDbMySql.Models
{
    [Table("Subjects")]
   public class Subject
    {
        public Subject() { }
        //primary
        [Key]
        public int SubjectId { get; set; }
        [StringLength(100)]
        public string SubjectName { get; set; }
        [StringLength(50)]
        public string TypeOfExam { get; set; } //[Exam][Zachet]

        public string CourseWork { get; set; } //Курсовая работа/проект, РГЗ
        //foreign
        public int TeacherId { get; set; }
        [ForeignKey(nameof(TeacherId))]
        public virtual Teacher Teacher { get; set; }
        public virtual ICollection<Monday> Mondays { get; set; } = new HashSet<Monday>();
        public virtual ICollection<Tuesday> Tuesdayds { get; set; } = new HashSet<Tuesday>();
        public virtual ICollection<Wednesday> Wednesdays { get; set; } = new HashSet<Wednesday>();
        public virtual ICollection<Thursday> Thursdays { get; set; } = new HashSet<Thursday>();
        public virtual ICollection<Friday> Fridays { get; set; } = new HashSet<Friday>();
        public override string ToString()
        {
            return $"{SubjectName}\n{Teacher.TeacherName}\n{TypeOfExam}\n{CourseWork}";
        }
    }
}
