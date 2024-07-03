using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    public class Program
    {
        static void Main(string[] args)
        {

            Console.Write("Welcome !!!\nEnter your book details : ");
            bool close = true;
            while (close)
            {
                Console.WriteLine("\nMenu\n" +
                "1)Add book\n" +
                "2)Delete book\n" +
                "3)Search book\n" +
                "4)Borrow book\n" +
                "5)Return book\n" +
                "6)Close\n\n");
                Console.Write("Choose your option from menu :");

                int option = int.Parse(Console.ReadLine());

                if (option == 1)
                {
                    Common.AddBook();
                }
                else if (option == 2)
                {
                    Common.RemoveBook();
                }
                else if (option == 3)
                {
                    Common.SearchBook();
                }
                else if (option == 4)
                {
                    Common.Borrow();
                }
                else if (option == 5)
                {
                    Common.ReturnBook();
                }
                else if (option == 6)
                {
                    Console.WriteLine("Thank you");
                    close = false;
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid option\nRetry !!!");
                }
            }

            Console.ReadLine();
        }
    }
}
