using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SqliteTest.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SqliteTest
{
    public class ClassViewModel : ObservableObject
    {
        private readonly Class _class;

        public ClassViewModel()
        {
            _class = new Class();
            Students = new ObservableCollection<StudentViewModel>();
            Teachers = new ObservableCollection<TeacherViewModel>();
            AddCmd = new RelayCommand(AddStudents);
            DeleteCmd = new RelayCommand<IEnumerable>(DeleteStudents);
        }

        public ClassViewModel(Class @class) : this()
        {
            _class = @class;
            //Read();
        }

        public ICommand AddCmd { get; set; }

        public ICommand DeleteCmd { get; set; }

        public int Id { get => _class.Id; set => SetProperty(_class.Id, value, _class, (c, i) => c.Id = i); }

        public string Name { get => _class.Name; set => SetProperty(_class.Name, value, _class, (c, n) => c.Name = n); }

        public string Number { get => _class.Number; set => SetProperty(_class.Number, value, _class, (c, n) => c.Number = n); }

        public ObservableCollection<StudentViewModel> Students { get; set; }

        public ObservableCollection<TeacherViewModel> Teachers { get; set; }

        private void AddStudents()
        {
            Students.Add(new StudentViewModel());
        }

        private void DeleteStudents(IEnumerable objects)
        {
        }
    }
}