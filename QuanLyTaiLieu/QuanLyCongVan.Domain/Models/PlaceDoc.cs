using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTaiLieu.Domain.Models
{
    public class PlaceDoc
    {
        public int PlaceDocId { get; set; }
        public string PlaceDocName { get; set; }
        public string Description { get; set; }
        public ICollection<Document> Documents { get; set; }
    }
}
