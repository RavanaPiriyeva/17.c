using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1
{
    public class Library
    {

        List<Book> Books = new List<Book>();
        public List<Book> FilterByPrice(FindDelegate book)
        {
            foreach (var item in Books)
            {
                if (book(item))
                {

                }

            }

        }
        public Book FiltreByGenre()
        {

        }

        public Book FiltreByNo()
        {

        }

        public bool IsExistBookByNo()
        {

        }

        public void RemoveAll()
        {

        }

 //        - Books  - Book listi
 //- FilterByPrice() - min və max dəyərləri qəbul edib o araqlıqda qiymətə sahib booklardan ibarət siyahı qaytarır
 //- FilterByGenre() - Genre deyeri qəbul edib genre dəyəri o olan booklardan ibarət siyahı qaytarır
 //- FindBookByNo() - nömrə dəyəri qəbul edir və No dəyəti o olan book obyektini tapıq qaytarmağa çalışır, tapmasa null qaytarır
 //- isExistBookByNo() - no dəyəri göndərilir və metod əgər həmin no-lu book varsa true yoxdursa false qaytarır
 //- RemoveAll() - predicate qəbul edir və o şərti ödəyən bütün kitabları silir
    }
}
