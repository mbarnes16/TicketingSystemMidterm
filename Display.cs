using System;
using System.IO;
namespace TicketingSystemMidterm
{
    public class Display
    {
        public void whatTicketTypeMenu()
        {
            Console.WriteLine("1) Bug/Defect");
            Console.WriteLine("2) Enhancement");
            Console.WriteLine("3) Task");
        }
        public void menuOptions() 
        {
            Console.WriteLine("1) Read data from file");
            Console.WriteLine("2) Create a new ticket");
            Console.WriteLine("3) Search tickets");
            Console.WriteLine("4) Enter any key to exit");
        }
        public void searchTicketChoice()
        {
            Console.WriteLine("1) Search status");
            Console.WriteLine("2) Search priority");
            Console.WriteLine("3) Search submitter");
        }
    }
}