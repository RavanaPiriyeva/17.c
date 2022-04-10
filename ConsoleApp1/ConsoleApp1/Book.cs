using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class Book
    {
        public Book()
        {
            _no++;
            No = _no;
        }
        static int _no;
        public int No { get; }
        public string Name { get; set; }
        public string AuthorNmae { get; set; }
        public GenreType Genre { get; set; }
        public double Price { get; set; }
    }
}
