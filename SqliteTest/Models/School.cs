using FreeSql.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqliteTest.Models
{
    /// <summary>
    /// 班级
    /// </summary>
    [Table(Name = nameof(Class))]
    public class Class
    {
        [Column(IsIdentity = true, IsPrimary = true)]
        public int Id { get; set; }

        public int Number { get; set; }

        public List<Student> Students { get; set; }

        public int TeacherId { get; set; }
    }

    /// <summary>
    /// 课程
    /// </summary>
    [Table(Name = nameof(Course))]
    public class Course
    {
        [Column(IsIdentity = true, IsPrimary = true)]
        public int Id { get; set; }

        public string Name { get; set; }
    }

    [Table(Name = nameof(Deparment))]
    public class Deparment
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }

    [Table(Name = nameof(Grade))]
    public class Grade
    {
        public List<Class> Classes { get; set; }

        [Column(IsIdentity = true, IsPrimary = true)]
        public int Id { get; set; }

        public int Index { get; set; }
    }

    /// <summary>
    /// 学生
    /// </summary>
    [Table(Name = nameof(Student))]
    public class Student
    {
        public int Age { get; set; }

        [Column(IsIdentity = true, IsPrimary = true)]
        public int Id { get; set; }

        public string Name { get; set; }

        public int TeamId { get; set; }
    }

    public class StudentGrade
    {
        public int ClassId { get; set; }

        public int CourseId { get; set; }

        public int TeacherId { get; set; }
    }

    /// <summary>
    /// 老师
    /// </summary>
    [Table(Name = nameof(Teacher))]
    public class Teacher
    {
        public string Age { get; set; }

        public int DeparmentId { get; set; }

        public int GradeId { get; set; }

        [Column(IsIdentity = true, IsPrimary = true)]
        public int Id { get; set; }

        public string Name { get; set; }

        public int TeamId { get; set; }
    }
}