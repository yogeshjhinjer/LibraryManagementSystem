using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
     //* Add a new book to the system.
     //* Search for books by title or author.
     //* List all available books (not borrowed).
     //* Borrow a book by a borrower (ensure the book is available).
     //* Return a borrowed book.
     //* Display information about a specific borrower(including borrowed books).
    public static class Common
    {
        static Book book = Book.GetInstance();
        static Borrower borrow = Borrower.GetInstance();
        static List<Book> bookList = new List<Book>();
        static List<Borrower> borrowList = new List<Borrower>();

        //To add book details to the Library database
        public static void AddBook()
        {
            Console.WriteLine("Book Id:{0}", book.bookId = bookList.Count + 1);
            Console.Write("Book Name:");
            book.bookName = Console.ReadLine();
            
            Console.Write("Book Price:");
            book.bookPrice = int.Parse(Console.ReadLine());

            Console.Write("Title of Books:");
            book.title = Console.ReadLine();

            Console.Write("Author of Books:");
            book.author = Console.ReadLine();

            Console.Write("ISBN:");
            book.ISBN = Console.ReadLine();

            Console.Write("Is Borrowed - (Please enter values - true/false) :");
            book.borrowed = bool.Parse(Console.ReadLine());

            Console.Write("Number of Books:");
            book.x = book.bookCount = int.Parse(Console.ReadLine());
            bookList.Add(book);
        }


        //To delete book details from the Library database 
        public static void RemoveBook()
        {
            Console.Write("Enter Book id to be deleted : ");

            int Del = int.Parse(Console.ReadLine());

            if (bookList.Exists(x => x.bookId == Del))
            {
                bookList.RemoveAt(Del - 1);
                Console.WriteLine("Book id - {0} has been deleted", Del);
            }
            else
            {
                Console.WriteLine("Invalid Book id");
            }

            bookList.Add(book);
        }

        //To search book details from the Library database using Book id 
        public static void SearchBook()
        {
           
            Console.Write("Search by BOOK id :");
            int find = int.Parse(Console.ReadLine());

            if (bookList.Exists(x => x.bookId == find))
            {
                foreach (Book searchId in bookList)
                {
                    if (searchId.bookId == find)
                    {
                        Console.WriteLine("Book id :{0}\n" +
                        "Book name :{1}\n" +
                        "Book price :{2}\n" +
                        "Book Count :{3}\n" +
                        "Book Author :{4}\n" +
                        "Book Title :{5}\n" +
                        "Book ISBN :{6}\n" +
                        "Book Borrowed :{7}", searchId.bookId, searchId.bookName, searchId.bookPrice, searchId.bookCount, searchId.author, searchId.title, searchId.ISBN, searchId.borrowed);
                    }
                }
            }
            else
            {
                Console.WriteLine("Book id {0} not found", find);
            }
        }

        //To borrow book details from the Library
        public static void Borrow()
        {
            Console.WriteLine("User id : {0}", (borrow.borrowerId = borrowList.Count + 1));
            Console.Write("Name :");

            borrow.borrowerName = Console.ReadLine();

            Console.Write("Book id :");
            borrow.borrowBookId = int.Parse(Console.ReadLine());
            Console.Write("Number of Books : ");
            borrow.borrowCount = int.Parse(Console.ReadLine());
            Console.Write("Address :");
            borrow.borrowerAddress = Console.ReadLine();
            Console.Write("Email :");
            borrow.borrowerEmail = Console.ReadLine();
            Console.Write("Phone Number :");
            borrow.borrowerPhoneNumber = Console.ReadLine();

            borrow.borrowDate = DateTime.Now;
            Console.WriteLine("Date - {0} and Time - {1}", borrow.borrowDate.ToShortDateString(), borrow.borrowDate.ToShortTimeString());

            if (bookList.Exists(x => x.bookId == borrow.borrowBookId))
            {
                foreach (Book searchId in bookList)
                {
                    if (searchId.bookCount >= searchId.bookCount - borrow.borrowCount && searchId.bookCount - borrow.borrowCount >= 0)
                    {
                        if (searchId.bookId == borrow.borrowBookId)
                        {
                            searchId.bookCount = searchId.bookCount - borrow.borrowCount;
                            break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Only {0} books are found", searchId.bookCount);
                        break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Book id {0} not found", borrow.borrowBookId);
            }
            borrowList.Add(borrow);
        }

        //To return borrowed book to the library 
        public static void ReturnBook()
        {
            Console.WriteLine("Enter following details :");

            Console.Write("Book id : ");
            int returnId = int.Parse(Console.ReadLine());

            Console.Write("Number of Books:");
            int returnCount = int.Parse(Console.ReadLine());

            if (bookList.Exists(y => y.bookId == returnId))
            {
                foreach (Book addReturnBookCount in bookList)
                {
                    if (addReturnBookCount.x >= returnCount + addReturnBookCount.bookCount)
                    {
                        if (addReturnBookCount.bookId == returnId)
                        {
                            addReturnBookCount.bookCount = addReturnBookCount.bookCount + returnCount;
                            break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Count exists the actual count");
                        break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Book id {0} not found", returnId);
            }
        }


    }
}
