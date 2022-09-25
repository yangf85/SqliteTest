using FreeSql.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqliteTest.Models
{
    public interface IClass
    {
        string Alias { get; set; }
        int Number { get; set; }
    }

    public interface IStudent
    {
        string Address { get; set; }
        int Age { get; set; }

        string Name { get; set; }
    }

    public interface ITeacher
    {
        int Age { get; set; }

        string Name { get; set; }
    }

    /// <summary>
    /// 班级
    /// </summary>
    [Table(Name = nameof(Class))]
    public class Class : IClass
    {
        public Class()
        {
        }

        public string Alias { get; set; }

        [Column(IsIdentity = true, IsPrimary = true)]
        public int Id { get; set; }

        public int Number { get; set; }
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

    [Table(Name = nameof(Student), OldName = nameof(Student))]
    public class Student : IStudent
    {
        public string Address { get; set; }
        public int Age { get; set; }

        [Column(IsIdentity = true, IsPrimary = true)]
        public int Id { get; set; }

        public string Name { get; set; }
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

        public Class Class { get; set; }

        [Column(IsIdentity = true, IsPrimary = true)]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}