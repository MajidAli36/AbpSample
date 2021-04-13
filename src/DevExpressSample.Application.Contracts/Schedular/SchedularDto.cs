using System;
using Volo.Abp.Application.Dtos;

namespace DevExpressSample.Books
{
    public class SchedularDto : AuditedEntityDto<Guid>
    {
        public string Name { get; set; }
        
        public DateTime PublishDate { get; set; }

        public float Price { get; set; }
    }
}