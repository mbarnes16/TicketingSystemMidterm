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
            Console.WriteLine("3) Enter any key to exit");
        }
        public void BugDefectChoice()
        { 
            BugDefect bugDefect = new BugDefect();
            Console.WriteLine("Enter ticket summary");
            bugDefect.summary = Console.ReadLine();

            Console.WriteLine("Enter ticket status");
            bugDefect.status = Console.ReadLine();

            Console.WriteLine("Enter ticket priority");
            bugDefect.priority = Console.ReadLine();

            Console.WriteLine("Enter ticket submitter");
            bugDefect.submitter = Console.ReadLine();

            Console.WriteLine("Enter who is assigned");
            bugDefect.assigned = Console.ReadLine();
            string input;
            Console.WriteLine("Enter who is watching");
            input = Console.ReadLine();
                if (input.Length > 0)
                    {
                        bugDefect.watching.Add(input);
                    }
                        

                if (bugDefect.watching.Count == 0)
                    { 
                            bugDefect.watching.Add("(no watchers listed)");
                    }

            Console.WriteLine("Enter Bug/Defect ticket severity");
            bugDefect.severity = Console.ReadLine();
        }
        public void enhancementChoice()
        {
            Enhancement enhancement = new Enhancement();
            Console.WriteLine("Enter ticket summary");
            enhancement.summary = Console.ReadLine();

            Console.WriteLine("Enter ticket status");
            enhancement.status = Console.ReadLine();

            Console.WriteLine("Enter ticket priority");
            enhancement.priority = Console.ReadLine();

            Console.WriteLine("Enter ticket submitter");
            enhancement.submitter = Console.ReadLine();

            Console.WriteLine("Enter who is assigned");
            enhancement.assigned = Console.ReadLine();
            
            string input;
            Console.WriteLine("Enter who is watching");
            input = Console.ReadLine();
            if(input.Length > 0)
            {
                enhancement.watching.Add(input);
            }
            if (enhancement.watching.Count == 0)
            {
                enhancement.watching.Add("(no watchers listed)"); 
            }

            Console.WriteLine("Enter ticket software");
            enhancement.software = Console.ReadLine();

            Console.WriteLine("Enter ticket cost");
            enhancement.cost = Console.ReadLine();

            Console.WriteLine("Enter ticket reason");
            enhancement.reason = Console.ReadLine();

            Console.WriteLine("Enter ticket estimate");
            enhancement.estimate = Console.ReadLine();

        }
        public void taskChoice()
        {
             Task task = new Task();

            Console.WriteLine("Enter ticket summary");
            task.summary = Console.ReadLine();

            Console.WriteLine("Enter ticket status");
            task.status = Console.ReadLine();

            Console.WriteLine("Enter ticket priority");
            task.priority = Console.ReadLine();

            Console.WriteLine("Enter ticket submitter");
            task.submitter = Console.ReadLine();

            Console.WriteLine("Enter who is assigned");
            task.assigned = Console.ReadLine();
            
            string input;
            Console.WriteLine("Enter who is watching");
            input = Console.ReadLine();
            if(input.Length > 0)
            {
                task.watching.Add(input);
            }
            if (task.watching.Count == 0)
            {
                task.watching.Add("(no watchers listed)"); 
            }
            Console.WriteLine("Enter ticket project name");
            task.projectName = Console.ReadLine();

            Console.WriteLine("Enter ticket due date");
            task.dueDate = Console.ReadLine();
        }
    }
}