using CommunityToolkit.Mvvm.ComponentModel;
using SqliteTest.Models;

namespace SqliteTest
{
    public class TeacherViewModel : ObservableObject, ITeacher
    {
        private readonly Teacher _teacher;

        public int Age { get => _teacher.Age; set => SetProperty(_teacher.Age, value, _teacher, (t, a) => t.Age = a); }

        public string Name { get => _teacher.Name; set => SetProperty(_teacher.Name, value, _teacher, (t, a) => t.Name = a); }

        public TeacherViewModel()
        {
            _teacher = new Teacher();
        }

        public TeacherViewModel(Teacher teacher)
        {
            _teacher = teacher;
        }

        public Teacher Build() => _teacher;
    }
}