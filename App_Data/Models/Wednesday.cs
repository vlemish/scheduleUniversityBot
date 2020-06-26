using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testDbMySql.Models
{
    [Table("Wednesdays")]
    public partial class Wednesday
    {
        [Key]
        public int Id { get; set; }
        public int EvenOrOdd { get; set; }
        public TimeSpan lectureTime { get; set; }
        [Required]
        [StringLength(9)]
        public string TypeOfLecture { get; set; }
        public int LectureId { get; set; }
        public int TeacherId { get; set; }
        [ForeignKey(nameof(LectureId))]
        public virtual Subject Subjects { get; set; }
        [ForeignKey(nameof(TeacherId))]
        public virtual Teacher Teachers { get; set; }

        public override string ToString()
        {
            return $"{lectureTime}\n{Subjects.SubjectName}\n{Teachers.TeacherName}\n{TypeOfLecture}\n";
        }
    }
}
