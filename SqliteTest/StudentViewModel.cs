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
    public class StudentViewModel : ObservableObject
    {
        private readonly Student _student;

        public StudentViewModel()
        {
            _student = new Student();
            Class = new ClassViewModel();
        }

        public StudentViewModel(Student student) : this()
        {
            _student = student;
        }

        public string Address { get => _student.Address; set => SetProperty(_student.Address, value, _student, (s, a) => s.Address = a); }
        public int Age { get => _student.Age; set => SetProperty(_student.Age, value, _student, (s, a) => s.Age = a); }

        public ClassViewModel Class { get; set; }

        public int Id { get => _student.Id; set => SetProperty(_student.Id, value, _student, (s, i) => s.Id = i); }

        public string Name { get => _student.Name; set => SetProperty(_student.Name, value, _student, (s, a) => s.Name = a); }
    }
}