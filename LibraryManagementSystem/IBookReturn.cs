using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    public interface IBookReturn
    {
        void BookReturn(List<Book> bookList);
    }
}
