using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeLibraryApp.Models
{
    public partial class booksRead
    {

        public int BooksRead_id { get; set; }
        public int Book_id { get; set; }
        public int Reader_id { get; set; }
        public System.DateTime DateRead { get ; set ; }
        public virtual book book { get; set; }
        public virtual reader reader { get; set; }
    }
}
