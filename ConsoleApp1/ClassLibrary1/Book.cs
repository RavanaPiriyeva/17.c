using System;

namespace ClassLibrary1
{
    public class Book
    {
        public Book()
        {
            _no++;
            No = _no;
        }
        public int _no;
        public int No { get; }
        public string Name { get; set; }
        public string AuthorNmae { get; set; }
        public string Genre { get; set; }
        public double Price { get; set; }   
 //        - No
 //- Name
 //- AuthorName
 //- Genre(genre enum tipində)
 //- Price
    }
}
