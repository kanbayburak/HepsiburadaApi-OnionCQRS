using HepsiburadaApi.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HepsiburadaApi.Domain.Entities
{
    public class Detail : EntityBase
    {
        public Detail()
        {
            
        }
        public Detail(string title, string decription, int categoryId)
        {
            Title = title;
            Description = decription;
            CategoryId = categoryId;
        }
        public string Title { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
