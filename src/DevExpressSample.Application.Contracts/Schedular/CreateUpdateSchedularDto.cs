using System;
using System.ComponentModel.DataAnnotations;

namespace DevExpressSample.Books
{
    public class CreateUpdateSchedularDto
    {
        [Required]
        [StringLength(128)]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime PublishDate { get; set; } = DateTime.Now;

        [Required]
        public float Price { get; set; }
    }
}