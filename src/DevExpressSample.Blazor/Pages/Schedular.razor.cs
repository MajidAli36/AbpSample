using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DevExpressSample.Books;
using Microsoft.AspNetCore.Components;

namespace DevExpressSample.Blazor.Pages 
{
    public partial class Schedular
    {
        [Inject]
        private ISchedularAppService schAppService { get; set; }

        private IReadOnlyList<SchedularDto> schedularList { get; set; }
        private int TotalCount { get; set; }
        private CreateUpdateSchedularDto NewBookDto { get; set; }
        private CreateUpdateSchedularDto EditingBookDto { get; set; }


        public Schedular()
        {
            schedularList = new List<SchedularDto>();
            NewBookDto = new CreateUpdateSchedularDto();
            EditingBookDto = new CreateUpdateSchedularDto();
        }
        protected override async Task OnInitializedAsync()
        {
            await GetBooksAsync();
        }

        private async Task GetBooksAsync()
        {
            schedularList = await schAppService.GetListAsync();
            
            StateHasChanged();
        }
        
        private async Task CreateBookAsync(IDictionary<string, object> input)
        {
            NewBookDto.Name = input.GetOrDefault("Name").ToString();
            NewBookDto.Price = (float) input.GetOrDefault("Price");
            NewBookDto.PublishDate = (DateTime) input.GetOrDefault("PublishDate");
            Console.WriteLine(input.GetOrDefault("Type") == null ? "null" : input.GetOrDefault("Type") );
            await schAppService.CreateAsync(NewBookDto);
            
            await GetBooksAsync(); 

 
        }
        
        private async Task UpdateBookAsync(SchedularDto book, IDictionary<string, object> input)
        {
            EditingBookDto.Name = input.GetOrDefault("Name") == null ? book.Name : input.GetOrDefault("Name").ToString();
            EditingBookDto.Price = input.GetOrDefault("Price") == null ? book.Price : (float) input.GetOrDefault("Price");
            EditingBookDto.PublishDate = input.GetOrDefault("PublishDate") == null ? book.PublishDate : (DateTime)  input.GetOrDefault("PublishDate");
            await schAppService.UpdateAsync(book.Id, EditingBookDto);
           
            await GetBooksAsync();
        }
        
        private async Task DeleteBookAsync(SchedularDto book)
        {
            var confirmMessage = L["BookDeletionConfirmationMessage", book.Name];
            if (!await Message.Confirm(confirmMessage))
            {
                return;
            }

            await schAppService.DeleteAsync(book.Id);
            await GetBooksAsync();
        }
    }
}