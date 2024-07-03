using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    public interface IBorrowedBook
    {
        void BorrowedBook(List<Book> bookList, List<Borrower> borrowList);
    }
}
