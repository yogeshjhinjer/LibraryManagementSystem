using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    public sealed class Borrower
    {
        private static Borrower borrower;
        private Borrower()
        {

        }
        public int borrowerId {  get; set; }    
        public string borrowerName { get; set; }
        public string borrowerAddress { get; set; }
        public string borrowerEmail { get; set; }
        public string borrowerPhoneNumber { get; set; }
        public int borrowBookId { get; set; }
        public DateTime borrowDate { get; set; }
        public int borrowCount { get; set; }

        public static Borrower GetInstance()
        {
            if (borrower == null)
            {
                borrower = new Borrower();
            }
            return borrower;
        }
    }
}
