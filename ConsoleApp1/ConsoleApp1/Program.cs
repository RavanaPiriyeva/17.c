using System;



namespace ConsoleApp1
{
    public delegate bool FindDelegate(Book book);
    internal class Program
    {
        static void Main(string[] args)
        {
            string strCount;
            int count;
            bool checkCount = true;
            Library library = new Library();
            string bookName;
            string authorName;
            string strGenre;
            GenreType genre;
            double price;
            string strPrice;
            int typegenre;
            int i = 0;
            string strmenu;
            int menu;

            do
            {
                if (checkCount)
                {
                    Console.WriteLine("Nece kitab daxil etmek isdeyirsiz?\n");
                    checkCount = false;
                }
                else
                {
                    Console.WriteLine("Kitab sayini duzgun daxil edin!!!!!\n");
                }
              
                strCount = Console.ReadLine();
            }
            while (!int.TryParse(strCount, out count));

            while (library.Books.Count < count)
            {
                bool checkName = true;
                do
                {
                    if (checkName) { 
                        Console.WriteLine($"{i + 1}.Kitabin adini daxil edin:\n");
                    checkName = false;
                }
                
                    else
                    {
                        Console.WriteLine($"{i + 1}.Kitabin adini duzgun  daxil edin!!!!!\n");
                    }
                bookName=Console.ReadLine();
                }
                while(string.IsNullOrEmpty(bookName));
                bool checkAuthorName = true;
                do
                {
                    if (checkAuthorName)
                    {
                        Console.WriteLine($"{i + 1}.Yazicinin adini daxil edin :\n");
                        checkAuthorName = false;
                    }
                    else
                    {
                        Console.WriteLine($"{i + 1}.Yazicinin adini duzgun  daxil edin !!!!!!!!\n");
                    }
                    authorName = Console.ReadLine();
                }
                while (string.IsNullOrEmpty(authorName));
                bool checkGenre = true;
                do
                {
                    if (checkGenre)
                    {
                        Console.WriteLine($"{i + 1}.Janr daxil edin:\n");
                        checkGenre = false;
                    }
                    else
                    {
                        Console.WriteLine($"{i + 1}.Janri duzgun daxil edin!!!!!!\n");
                    }

                    foreach (var item in Enum.GetValues(typeof(GenreType)))
                        {
                        Console.WriteLine((int)item+"."+item);
                    }
                strGenre=Console.ReadLine();
                }
                while(!int.TryParse(strGenre , out typegenre) || !Enum.IsDefined(typeof(GenreType),typegenre));
                bool checkPrice = true;
                do {
                    if (checkPrice) { 
                    Console.WriteLine($"{i + 1}.Qiymet daxil edin:\n");
                    checkPrice = false;
                    }
                    else
                    {
                        Console.WriteLine($"{i + 1}.Qiymeti duzgun daxil edin!!!!!!\n");
                    }
                    strPrice = Console.ReadLine();
                }
                while (!double.TryParse(strPrice, out price));
                Book book = new Book();
                book.Name = bookName;
                foreach (var item in Enum.GetValues(typeof(GenreType)))
                {
                    if ((int)item== typegenre)
                    {
                        book.Genre = (GenreType)item;
                    }
                }
                
                book.Price = price;
                book.AuthorNmae = authorName;
                
                library.Books.Add(book);

                i++;
            }
            bool check = true;
            bool checkMenu = true;
            while (check)
            {
                Console.WriteLine("\n=============================== MENU =====================================\n");
                Console.WriteLine("\n1.Kitablarin siyahisin goster\n2.Filtirle\n3.Kitab sil\n4.Proqrami bitir\n");
                do {
                    if (checkMenu)
                    {
                        Console.WriteLine("Secim et:");
                        checkMenu= false;
                    }
                    else
                    {
                        Console.WriteLine("Secimi duzgun  et!!!!!");
                    }
                    strmenu = Console.ReadLine();
                }
                while(!int.TryParse(strmenu, out menu));

                switch (strmenu) {
                    case "1":
                        Console.WriteLine("\n=============================== BOOKS =====================================\n");
                        foreach (var item in library.Books)
                        {
                            Console.WriteLine(item.No + "   " + item.Name + "     " + item.AuthorNmae + "    " + item.Price + "     " + item.Genre);
                        }
                        break;
                        case "2":
                        Console.WriteLine("\n1.Qiymete gore\n2.Janra gore\n3.No gore\n");
                        string strFiltreMenu;
                        int filtreMenu;
                        string strFilteGanre;
                        int filtreGenre;
                        string strFiltreNo;
                        int filtreNo;
                        do
                        {
                            strFiltreMenu = Console.ReadLine();
                        }
                        while (!int.TryParse(strFiltreMenu, out filtreMenu));
                        switch (filtreMenu)
                        {
                            case 1:
                                Console.WriteLine("Maksimum ve minumum deyerler daxil edin:\n");
                                int max = Convert.ToInt32(Console.ReadLine());
                                int min = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("\n=============================== BOOKS =====================================\n");
                                foreach (var item in library.FilterByPrice(max, min))
                                {
                                    Console.WriteLine(item.No + "   " + item.Name + "     " + item.AuthorNmae + "    " + item.Price + "     " + item.Genre);
                                } 

                                break;
                            case 2:
                                do { 
                                Console.WriteLine("Axtarilacaq janri daxil edin:\n");
                                foreach (var item in Enum.GetValues(typeof(GenreType)))
                                {
                                    Console.WriteLine((int)item + "." + item);
                                }
                                strFilteGanre = Console.ReadLine();
                                }
                                while (!int.TryParse(strFilteGanre, out filtreGenre) || !Enum.IsDefined(typeof(GenreType), filtreGenre)) ;
                                foreach (var item in Enum.GetValues(typeof(GenreType)))
                                {
                                    if ((int)item == filtreGenre)
                                    {
                                        Console.WriteLine("\n=============================== BOOKS =====================================\n");
                                        foreach (var books in library.FiltreByGenre((GenreType)item) )
                                        {
                                            Console.WriteLine(books.No + "   " + books.Name + "     " + books.AuthorNmae + "    " + books.Price + "     " + books.Genre);
                                            break;
                                        }
                                       
                                    }
                                }
                               
                                break;

                            case 3:
                                do
                                {
                                    Console.WriteLine("Axtarilacaq nomre daxil edin:\n");
                                    strFiltreNo = Console.ReadLine();
                                }
                                while (!int.TryParse(strFiltreNo, out filtreNo));

                                Book book = library.FiltreByNo(filtreNo);
                                {
                                    Console.WriteLine("\n=============================== BOOKS =====================================\n");
                                    if(book != null) { 
                                    Console.WriteLine(book.No + "   " + book.Name + "     " + book.AuthorNmae + "    " + book.Price + "     " + book.Genre);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Bele nomreli kitab yoxdur!!!!\n");
                                    }
                                }
                                Console.WriteLine(library.IsExistBookByNo(filtreNo));

                                break;
                        }


                        break;
                    case "3":
                        Console.WriteLine("Silinecey nomrenidaxil edin:\n ");
                        int removeNo = Convert.ToInt32(Console.ReadLine());
                        library.RemoveAll(x => x.No == removeNo);
                        Console.WriteLine("\n=============================== BOOKS =====================================\n");
                        foreach (var book in library.Books)
                        {
                            Console.WriteLine(book.No + "   " + book.Name + "     " + book.AuthorNmae + "    " + book.Price + "     " + book.Genre);
                        }
                        break;
                    case "4":
                        return;
                        break;
                        default:
                        Console.WriteLine("Duzgun daxil et!!!!!!");
                        break;
                }

            }
          
        }
    }
}
