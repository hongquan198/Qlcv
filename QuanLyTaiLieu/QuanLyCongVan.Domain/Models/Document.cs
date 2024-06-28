using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTaiLieu.Domain.Models
{
    public class Document
    {
        public int DocumentId { get; set; }
        public string Signer { get; set; }
        public string ApprovedBy { get; set; }
        public int NumberPage { get; set; }
        public string NumberSymbols { get; set; }
        public DateTime DateTime { get; set; }
        public string Abstract { get; set; }
        public string Content { get; set; }

        // Đến 
        public string Receive { get; set; }
        public int NumberFrom { get; set; }
        public DateTime DateFrom { get; set; }

        //Đi
        public string Sender { get; set; }
        public int NumberGo { get; set; }
        public int Quantity { get; set; }

        // fk chung
        public int PlaceDocId { get; set; } //Đến: Nơi nhận; Đi: nơi ban hành
        public PlaceDoc PlaceDoc { get; set; }

        //fk chung
        public string NumberDocCode { get; set; }
        public NumberDoc NumberDoc { get; set; }

        public int TypeDocId { get; set; } 
        public TypeDoc TypeDoc { get; set; }
    }
}
