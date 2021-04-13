using DevExpressSample.Books;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Volo.Abp.DependencyInjection;

namespace DevExpressSample.Data
{
    public class SampleDataService2 : ISingletonDependency
    {
        private List<SchedularDto> DataSource2 = new List<SchedularDto>
        {
            new SchedularDto
            {
                Id = Guid.NewGuid(),
                Name = "Leonardo Da Vinci",
                PublishDate = DateTime.Today,
                Price = 33.99F
            },
            new SchedularDto
            {
                Id = Guid.NewGuid(),
                Name = "Einstein: His Life and Universe",
                PublishDate = DateTime.Now,
                Price = 90.99F
            },
            new SchedularDto
            {
                Id = Guid.NewGuid(),
                Name = "Steve Jobs",
                PublishDate = DateTime.Now,
                Price = 36.99F
            },
            new SchedularDto
            {
                Id = Guid.NewGuid(),
                Name = "Crime and Punishment",
                PublishDate = DateTime.Now,
                Price = 30.99F
            },
            new SchedularDto
            {
                Id = Guid.NewGuid(),
                Name = "Notes from Underground",
                PublishDate = DateTime.Now,
                Price = 90.99F
            },
            new SchedularDto
            {
                Id = Guid.NewGuid(),
                Name = "Kürk Mantolu Madonna",
                PublishDate = DateTime.Now,
                Price = 20.99F
            },
            new SchedularDto
            {
                Id = Guid.NewGuid(),
                Name = "Outliers: The Story of Success",
                PublishDate = DateTime.Now,
                Price = 17.35F
            },
            new SchedularDto
            {
                Id = Guid.NewGuid(),
                Name = "Blink: The Power of Thinking Without Thinking",
                PublishDate = DateTime.Now,
                Price = 8.23F
            },
            new SchedularDto
            {
                Id = Guid.NewGuid(),
                Name = "How Google Works",
                PublishDate = DateTime.Now,
                Price = 25.99F
            },
            new SchedularDto
            {
                Id = Guid.NewGuid(),
                Name = "Domain-Driven Design",
                PublishDate = DateTime.Now,
                Price = 54.99F
            },
            new SchedularDto
            {
                Id = Guid.NewGuid(),
                Name = "Implementing Domain-Driven Design",
                PublishDate = DateTime.Now,
                Price = 54.48F
            },
            new SchedularDto
            {
                Id = Guid.NewGuid(),
                Name = "The Pragmatic Programmer",
                PublishDate = DateTime.Now,
                Price = 59.28F
            },
            new SchedularDto
            {
                Id = Guid.NewGuid(),
                Name = "Design Patterns",
                PublishDate = DateTime.Now,
                Price = 28.28F
            }
        };

        public List<SchedularDto> GetBooks()
        {
            return DataSource2;
        }

        public SchedularDto GetBook(Guid id)
        {
            return DataSource2.SingleOrDefault(x => x.Id == id);
        }

        public SchedularDto CreateBook(SchedularDto input)
        {
            DataSource2.Add(new SchedularDto
            {
                Id = input.Id,
                Name = input.Name,
                Price = input.Price,
                PublishDate = input.PublishDate
            });

            return input;
        }

        public SchedularDto UpdateBook(SchedularDto input)
        {
            DeleteBook(input);
            CreateBook(input);

            return input;
        }

        public void DeleteBook(SchedularDto input)
        {
            DataSource2.Remove(input);
        }
    }
}
