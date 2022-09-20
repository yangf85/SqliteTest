using FreeSql.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqliteTest.Models
{
    public class Grade
    {
        [Column(IsIdentity = true, IsPrimary = true)]
        public int Id { get; set; }

        public int Index { get; set; }
        public List<Team> Teams { get; set; }
    }

    public class Student
    {
        public string Age { get; set; }

        public int GradeId { get; set; }

        [Column(IsIdentity = true, IsPrimary = true)]
        public int Id { get; set; }

        public string Name { get; set; }
        public int TeamId { get; set; }
    }

    public class Teacher
    {
        public string Age { get; set; }

        public int GradeId { get; set; }

        [Column(IsIdentity = true, IsPrimary = true)]
        public int Id { get; set; }

        public string Name { get; set; }
        public int TeamId { get; set; }
    }

    public class Team
    {
        [Column(IsIdentity = true, IsPrimary = true)]
        public int Id { get; set; }

        public int Number { get; set; }

        public List<Student> Students { get; set; }
        public int TeacherId { get; set; }
    }
}