using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTaiLieu.Domain.Models
{
    public class NumberDoc
    {
        public string NumberDocCode { get; set; }
        public string NumberDocName { get; set; }
        public string Description { get; set; }
        public ICollection<Document> Documents { get; set; }
    }
}
