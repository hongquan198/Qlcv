using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTaiLieu.Domain.Models
{
    public class TypeDoc
    {
        public int TypeDocId { get; set; }
        public string TypeDocName { get; set; }
        public string Description { get; set; }
        public ICollection<Document> Documents { get; set; }
    }
}
