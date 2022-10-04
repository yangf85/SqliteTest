using CommunityToolkit.Mvvm.ComponentModel;
using SqliteTest.Models;

namespace SqliteTest
{
    public class TeacherViewModel : ObservableObject
    {
        private readonly Teacher _teacher;

        public TeacherViewModel()
        {
            _teacher = new Teacher();
            Class = new ClassViewModel();
        }

        public TeacherViewModel(Teacher teacher) : this()
        {
            _teacher = teacher;
        }

        public int Age { get => _teacher.Age; set => SetProperty(_teacher.Age, value, _teacher, (t, a) => t.Age = a); }

        public ClassViewModel Class { get; set; }
        public int Id { get => _teacher.Id; set => SetProperty(_teacher.Id, value, _teacher, (t, i) => t.Id = i); }
        public string Name { get => _teacher.Name; set => SetProperty(_teacher.Name, value, _teacher, (t, a) => t.Name = a); }
    }
}