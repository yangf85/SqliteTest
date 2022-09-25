using CommunityToolkit.Mvvm.ComponentModel;
using SqliteTest.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqliteTest
{
    public class ClassViewModel : ObservableObject, IClass
    {
        private readonly Class _class;

        public int Number { get => _class.Number; set => SetProperty(_class.Number, value, _class, (c, n) => c.Number = n); }

        public IEnumerable<IStudent> Students { get; set; }

        public IEnumerable<ITeacher> Teachers { get; set; }

        public string Alias { get => _class.Alias; set => SetProperty(_class.Alias, value, _class, (c, n) => c.Alias = n); }

        public ClassViewModel()
        {
            _class = new Class();
            Students = new ObservableCollection<StudentViewModel>() as ICollection<IStudent>;
            Teachers = new ObservableCollection<TeacherViewModel>() as ICollection<ITeacher>;
        }

        public ClassViewModel(Class @class) : base()
        {
            _class = @class;
        }

        public Class Build() => _class;
    }
}