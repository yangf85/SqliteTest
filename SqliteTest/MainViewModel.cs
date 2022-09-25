using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SqliteTest.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SqliteTest
{
    internal class MainViewModel : ObservableObject
    {
        private string queryString;

        public IAsyncRelayCommand ReadStudentsCmd { get; private set; }

        public IAsyncRelayCommand QueryStudentsCmd { get; private set; }

        public IAsyncRelayCommand ReadClassesCmd { get; private set; }

        public IAsyncRelayCommand UpdateClassesCmd { get; private set; }

        public IAsyncRelayCommand UpdateTeachersCmd { get; private set; }

        public IAsyncRelayCommand DeleteClassesCmd { get; private set; }

        public IAsyncRelayCommand DeleteTeachersCmd { get; private set; }

        public IAsyncRelayCommand QueryClassesCmd { get; private set; }

        public IAsyncRelayCommand ReadTeachersCmd { get; private set; }

        public IAsyncRelayCommand QueryTeachersCmd { get; private set; }

        public ObservableCollection<StudentViewModel> Students { get; set; }

        public ObservableCollection<TeacherViewModel> Teachers { get; set; }

        public ObservableCollection<ClassViewModel> Classes { get; set; }

        public string QueryString { get => queryString; set => SetProperty(ref queryString, value); }

        public MainViewModel()
        {
            Students = new ObservableCollection<StudentViewModel>();
            Teachers = new ObservableCollection<TeacherViewModel>();
            Classes = new ObservableCollection<ClassViewModel>();
            ReadStudentsCmd = new AsyncRelayCommand(ReadStudents);
            QueryStudentsCmd = new AsyncRelayCommand(QueryStudents);

            ReadClassesCmd = new AsyncRelayCommand(ReadClasses);
            UpdateClassesCmd = new AsyncRelayCommand(UpdateClasses);
            QueryClassesCmd = new AsyncRelayCommand(QueryClasses);
            DeleteClassesCmd = new AsyncRelayCommand<IEnumerable>(DeleteClasses);

            ReadTeachersCmd = new AsyncRelayCommand(ReadTeachers);
            UpdateTeachersCmd = new AsyncRelayCommand(UpdateTeachers);
            DeleteTeachersCmd = new AsyncRelayCommand<IEnumerable>(DeleteTeachers);
            QueryTeachersCmd = new AsyncRelayCommand(QueryTeachers);
        }

        private async Task DeleteTeachers(IEnumerable teachers)
        {
            if (teachers == null) { return; }
            await Task.Run(() =>
            {
                var list = teachers.Cast<TeacherViewModel>().Select(c => c.Build());
                Storage.Sqlite.Delete<Teacher>().Where(list).ExecuteAffrows();
            });
        }

        private async Task UpdateTeachers()
        {
            await Task.Run(() =>
            {
                Storage.Sqlite.InsertOrUpdate<Teacher>().SetSource(Teachers.Select(c => c.Build())).ExecuteAffrowsAsync();
            });
        }

        private async Task DeleteClasses(IEnumerable classes)
        {
            if (classes == null) { return; }
            var viewModels = classes.Cast<ClassViewModel>();
            await Task.Run(() =>
            {
                var list = viewModels.Select(c => c.Build());
                Storage.Sqlite.Delete<Class>().Where(list).ExecuteAffrows();
            });
            for (int i = 0; i < viewModels.Count(); i++)
            {
                Classes.Remove(viewModels.ElementAt(i));
            }
        }

        private async Task UpdateClasses()
        {
            await Task.Run(() =>
            {
                Storage.Sqlite.InsertOrUpdate<Class>().SetSource(Classes.Select(c => c.Build())).ExecuteAffrowsAsync();
            });
        }

        private Task QueryClasses()
        {
            throw new NotImplementedException();
        }

        private async Task ReadClasses()
        {
            var result = await Task.Run(() =>
            {
                var models = Storage.Sqlite.Select<Class>().ToList().Select(c => new ClassViewModel(c));
                return models;
            });
            Classes.Clear();
            foreach (var item in result)
            {
                Classes.Add(item);
            }
        }

        private async Task QueryTeachers()
        {
            return;
        }

        private async Task ReadTeachers()
        {
            var result = await Task.Run(() =>
            {
                var models = Storage.Sqlite.Select<Teacher>().ToList().Select(t => new TeacherViewModel(t));
                return models;
            });
            Teachers.Clear();
            foreach (var item in result)
            {
                Teachers.Add(item);
            }
        }

        private async Task QueryStudents()
        {
            await Task.Run(() => { });
        }

        private async Task ReadStudents()
        {
            await Task.Run(() => { });
        }
    }
}