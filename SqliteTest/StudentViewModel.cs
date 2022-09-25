using CommunityToolkit.Mvvm.ComponentModel;
using SqliteTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace SqliteTest
{
    internal class StudentViewModel : ObservableObject, IStudent
    {
        private Student _student;

        private IClass _class;

        public int Age { get => _student.Age; set => SetProperty(_student.Age, value, _student, (s, a) => s.Age = a); }

        public string Name { get => _student.Name; set => SetProperty(_student.Name, value, _student, (s, a) => s.Name = a); }

        public string Address { get => _student.Address; set => SetProperty(_student.Address, value, _student, (s, a) => s.Address = a); }

        public IClass Class { get => _class; set => SetProperty(ref _class, value); }

        public StudentViewModel()
        {
            _student = new Student();
        }

        public StudentViewModel(Student student)
        {
            _student = student;
        }

        public Student Build() => _student;
    }
}