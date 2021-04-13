using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace DevExpressSample.Books
{
    public interface ISchedularAppService : IApplicationService 
    {
        Task<List<SchedularDto>> GetListAsync();
        
        Task<SchedularDto> GetAsync(Guid id);

        Task<SchedularDto> CreateAsync(CreateUpdateSchedularDto input);

        Task<SchedularDto> UpdateAsync(Guid id, CreateUpdateSchedularDto input);
        
        Task DeleteAsync(Guid id);
    }
}