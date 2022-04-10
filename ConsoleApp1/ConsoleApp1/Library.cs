using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class Library
    {

        public List<Book> Books = new List<Book>();
       public   List<Book> FilterByPrice(int max, int min)
        {
            List<Book> bookss = new List<Book>();
            foreach (var item in Books)
            {
                if (item.Price <= max && item.Price >= min)
                {
                    bookss.Add(item);
                }

            }
            return bookss;

        }
        public List<Book> FiltreByGenre(GenreType genre)
        {
            List<Book> bookss = new List<Book>();
            foreach (var item in Books)
            {
                if (genre==item.Genre)
                {
                    bookss.Add(item);
                }

            }
            return bookss;

        }

        public Book FiltreByNo(int no)
        {
            foreach (var item in Books)
            {
                if (no==item.No)
                {
                    return item;
                }

            }
            return null;

        }

        public bool IsExistBookByNo(int no)
        {
            foreach (var item in Books)
            {
                if (no == item.No)
                {
                    return true; 
                }

            }
            return false; 

        }

        public void RemoveAll(Predicate<Book> book)
        {
            foreach (var item in Books)
            {
                if (book(item))
                {
                  Books.Remove(item);
                    break;
                }

            }

        }
    }
}
