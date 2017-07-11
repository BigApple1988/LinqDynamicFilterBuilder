using System;
using System.Collections.Generic;
using System.Linq;
using LinqDynamicFilterBuilder.Example.DAL;
using LinqDynamicFilterBuilder.Example.Filters;
using LinqDynamicFilterBuilder.Example.Repositories;
using Xunit;
namespace LinqDynamicFilterBuilder.Tests
{
    public class LinqDynamicFilterBuilderTests
    {
        ExampleContext _context = new ExampleContext()
        {
            SampleEntities = new List<SampleEntity>
            {
                new SampleEntity
                {
                    SampleEntityId = 1,
                    SampleVirtualEntity = new SampleVirtualEntity
                    {
                        SampleVirtualEntityId = 5,
                        SomeValue = "five"
                    }
                },
                new SampleEntity
                {
                    SampleEntityId = 2,
                    SampleVirtualEntity = new SampleVirtualEntity
                    {
                        SampleVirtualEntityId = 6,
                        SomeValue = "six"
                    }
                },
                new SampleEntity
                {
                    SampleEntityId = 3,
                    SampleVirtualEntity = new SampleVirtualEntity
                    {
                        SampleVirtualEntityId = 7,
                        SomeValue = "seven"
                    }
                }

            }.AsQueryable()
        };

                       

        [Fact]
        public void GetFilteredTest()
        {
           
            var repo = new SampleRepository(_context);
            //получение элементов с айдишниками виртуального свойства больше 5
            var filter = new SampleFilter()
            {
                VirtualEntityId = 5
            };
            var result = repo.GetFiltered(filter);
            Assert.True(result.Count==2); //получаем два элемента
            
            
        }
        [Fact]
        public void FindByIdTest()
        {
            var id = 3;
            var repo = new SampleRepository(_context);
            var result = repo.FindById(id);
            Assert.True(result.SampleEntityId==id); 


        }
    }
}
