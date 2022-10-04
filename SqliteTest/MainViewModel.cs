using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Mapster;
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

        public MainViewModel()
        {
            Classes = new ObservableCollection<ClassViewModel>();

            ReadClassesCmd = new AsyncRelayCommand(ReadClasses);
            UpdateClassesCmd = new AsyncRelayCommand(UpdateClasses);
            QueryClassesCmd = new AsyncRelayCommand(QueryClasses);
            DeleteClassesCmd = new AsyncRelayCommand<IEnumerable>(DeleteClasses);
        }

        public ObservableCollection<ClassViewModel> Classes { get; set; }
        public IAsyncRelayCommand DeleteClassesCmd { get; private set; }
        public IAsyncRelayCommand QueryClassesCmd { get; private set; }
        public string QueryString { get => queryString; set => SetProperty(ref queryString, value); }
        public IAsyncRelayCommand ReadClassesCmd { get; private set; }

        public IAsyncRelayCommand UpdateClassesCmd { get; private set; }

        public IAsyncRelayCommand UpdateTeachersCmd { get; private set; }

        private async Task DeleteClasses(IEnumerable classes)
        {
            if (classes == null) { return; }
            var map = new MappingHelper();
            var list = classes.Cast<ClassViewModel>();
            var models = list.Select(c => map.Mapper.Map<Class>(c));
            await Task.Run(() =>
            {
                var rep = Storage.Sqlite.GetRepository<Class>();
                foreach (var item in models)
                {
                    rep.DeleteCascadeByDatabase(c => c.Id == item.Id);
                }
            });
            foreach (var item in list)
            {
                Classes.Remove(item);
            }
        }

        private Task QueryClasses()
        {
            throw new NotImplementedException();
        }

        private async Task ReadClasses()
        {
            var map = new MappingHelper();
            //var rep = Storage.Sqlite.GetRepository<Class>();
            var result = await Task.Run(() =>
            {
                var models = Storage.Sqlite.Select<Class>().IncludeMany(c => c.Students).IncludeMany(c => c.Teachers).ToList(true);
                return models;
            });
            Classes.Clear();
            foreach (var item in result)
            {
                var c = map.Mapper.Map<ClassViewModel>(item);
                Classes.Add(c);
            }
        }

        private async Task UpdateClasses()
        {
            var helper = new MappingHelper();

            await Task.Run(() =>
            {
                var rep = Storage.Sqlite.GetRepository<Class>();
                rep.DbContextOptions.EnableCascadeSave = true;
                foreach (var c in Classes)
                {
                    var model = helper.Mapper.Map<Class>(c);

                    rep.InsertOrUpdate(model);
                }
            });
        }
    }
}