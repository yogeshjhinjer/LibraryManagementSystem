using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    public sealed class Book : IBorrowedBook, IBookReturn
    {
        private static Book book;
        private Book()
        {

        }
        public string title { get; set; }
        public string author { get; set; }
        public string ISBN { get; set; }
        public bool borrowed { get; set; }
        public int bookId { get; set; }
        public string bookName { get; set; }
        public int bookPrice { get; set; }
        public int bookCount { get; set; }
        public int x { get; set; }


        public static Book GetInstance()
        {
            if (book == null)
            {
                book = new Book();
            }
            return book;    
        }

        static Borrower borrow = Borrower.GetInstance();
        //To borrow book details from the Library
        public void BorrowedBook(List<Book> bookList, List<Borrower> borrowList)
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
        public void BookReturn(List<Book> bookList)
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
                    if (addReturnBookCount.bookCount >= returnCount + addReturnBookCount.bookCount)
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
