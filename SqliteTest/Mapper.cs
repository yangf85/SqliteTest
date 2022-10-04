using Mapster;
using MapsterMapper;
using SqliteTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqliteTest
{
    internal class MappingHelper
    {
        public MappingHelper()
        {
            Mapper = MappingBuild();
        }

        public IMapper Mapper { get; private set; }

        private IMapper MappingBuild()
        {
            var config = new TypeAdapterConfig();

            config.ForType<Class, ClassViewModel>().TwoWays().PreserveReference(true);
            config.ForType<Teacher, TeacherViewModel>().TwoWays().PreserveReference(true);
            config.ForType<Student, StudentViewModel>().TwoWays().PreserveReference(true);
            var map = new Mapper(config);
            return map;
        }
    }
}