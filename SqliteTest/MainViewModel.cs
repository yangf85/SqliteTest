using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SqliteTest.Models;
using System;
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

        public IAsyncRelayCommand ReadCmd { get; private set; }

        public IAsyncRelayCommand WriteCmd { get; private set; }

        public IAsyncRelayCommand QueryCmd { get; private set; }

        public ObservableCollection<Student> Students { get; set; }

        public string QueryString { get => queryString; set => SetProperty(ref queryString, value); }

        public MainViewModel()
        {
            Students = new ObservableCollection<Student>();
            ReadCmd = new AsyncRelayCommand(Read);
            WriteCmd = new AsyncRelayCommand(Write);
            Initial();
        }

        private void Initial()
        {
            var stu1 = new Student() { Name = "小胡", Age = 17 };
            var stu2 = new Student() { Name = "小张", Age = 18 };
            var stu3 = new Student() { Name = "小王", Age = 14 };
            var stu4 = new Student() { Name = "小刘", Age = 16 };
            Students.Add(stu1);
            Students.Add(stu2);
            Students.Add(stu3);
            Students.Add(stu4);
        }

        private Task Write()
        {
            return Task.Run(() =>
            {
                Storage.Sqlite.Insert(Students);
            });
        }

        private Task Read()
        {
            return Task.Run(() =>
             {
                 var list = Storage.Sqlite.Select<Student>(new Student { Age = 18 }).ToList();
                 foreach (var item in list)
                 {
                     Students.Add(item);
                 }
             });
        }
    }
}