using FreeSql.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public Class()
        {
        }

        [Column(IsIdentity = true, IsPrimary = true)]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Number { get; set; }

        [Navigate(nameof(Student.ClassId))]
        public List<Student> Students { get; set; }

        [Navigate(nameof(Teacher.ClassId))]
        public List<Teacher> Teachers { get; set; }
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
    public class Student
    {
        public string Address { get; set; }
        public int Age { get; set; }

        [Navigate(nameof(ClassId))]
        public Class Class { get; set; }

        public int ClassId { get; set; }

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
    public class Teacher
    {
        public int Age { get; set; }

        [Navigate(nameof(ClassId))]
        public Class Class { get; set; }

        public int ClassId { get; set; }

        [Column(IsIdentity = true, IsPrimary = true)]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}