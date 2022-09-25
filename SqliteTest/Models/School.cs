using FreeSql.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqliteTest.Models
{
    public interface ITeacher
    {
        int Age { get; set; }

        string Name { get; set; }
    }

    public interface IClass
    {
        int Number { get; set; }

        string Alias { get; set; }

        IEnumerable<IStudent> Students { get; set; }

        IEnumerable<ITeacher> Teachers { get; set; }
    }

    public interface IStudent
    {
        int Age { get; set; }

        string Name { get; set; }

        string Address { get; set; }

        IClass Class { get; set; }
    }

    [Table(Name = nameof(Student), OldName = nameof(Student))]
    public class Student : IStudent
    {
        public int Age { get; set; }

        [Column(IsIdentity = true, IsPrimary = true)]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public IClass Class { get; set; }
    }

    /// <summary>
    /// 班级
    /// </summary>
    [Table(Name = nameof(Class))]
    public class Class : IClass
    {
        [Column(IsIdentity = true, IsPrimary = true)]
        public int Id { get; set; }

        public int Number { get; set; }

        public IEnumerable<IStudent> Students { get; set; }

        public IEnumerable<ITeacher> Teachers { get; set; }

        public string Alias { get; set; }

        public Class()
        {
            Students = new List<Student>();
            Teachers = new List<Teacher>();
        }
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
    public class Teacher : ITeacher
    {
        public int Age { get; set; }

        [Column(IsIdentity = true, IsPrimary = true)]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}