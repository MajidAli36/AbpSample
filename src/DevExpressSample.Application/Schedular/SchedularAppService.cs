using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DevExpressSample.Data;
using Volo.Abp.Application.Services;

namespace DevExpressSample.Books
{
    public class SchedularAppService :  ApplicationService, ISchedularAppService
    {
        private readonly SampleDataService2 _sampleBookDataService2;

        public SchedularAppService(SampleDataService2 sampleBookDataService2)
        {
            _sampleBookDataService2 = sampleBookDataService2;
        }

        public async Task<List<SchedularDto>> GetListAsync()
        {
            return await Task.Run(() => _sampleBookDataService2.GetBooks());
        }
        
        public async Task<SchedularDto> GetAsync(Guid id)
        {
            var book = await Task.Run(() => _sampleBookDataService2.GetBook(id));
            
            return book;
        }

        public async Task<SchedularDto> CreateAsync(CreateUpdateSchedularDto input)
        {
            var newBook = new SchedularDto
            {
                Id = GuidGenerator.Create(),
                Name = input.Name,
                PublishDate = input.PublishDate,
                Price = input.Price
            };
            
            newBook = await Task.Run(() => _sampleBookDataService2.CreateBook(newBook));

            return newBook;
        }
        
        public async Task<SchedularDto> UpdateAsync(Guid id, CreateUpdateSchedularDto input)
        {
            var book = await Task.Run(() => _sampleBookDataService2.GetBook(id));

            book.Name = input.Name;
            book.Price = input.Price;
            book.PublishDate = input.PublishDate;
            
            book = await Task.Run(() => _sampleBookDataService2.UpdateBook(book));

            return book;
        }
        
        public async Task DeleteAsync(Guid id)
        {
            var book = await Task.Run(() => _sampleBookDataService2.GetBook(id));

            await Task.Run(() => _sampleBookDataService2.DeleteBook(book));
        }
    }
}