using System.ComponentModel.DataAnnotations;
using System;
using System.IO;
using NLog.Web;

namespace TicketingSystemMidterm
{
    class Program
    {
        private static NLog.Logger logger = NLogBuilder.ConfigureNLog(Directory.GetCurrentDirectory() + "\\nlog.config").GetCurrentClassLogger();
        static void Main(string[] args)
        {
            string bugDefectTicketFilePath = Directory.GetCurrentDirectory() + "\\tickets.csv";
            string enhancementTicketFilePath = Directory.GetCurrentDirectory() + "\\enhancements.csv";
            string taskTicketFilePath = Directory.GetCurrentDirectory() + "\\tasks.csv";


            logger.Info("Program started");

            BugDefectTicket bugDefectTicket = new BugDefectTicket(bugDefectTicketFilePath);
            EnhancementTicket enhancementTicket = new EnhancementTicket(enhancementTicketFilePath);
            TaskTicket taskTicket = new TaskTicket(taskTicketFilePath);
            string choice = "";
            string ticketChoice = "";

            do{

            Display display = new Display();
            display.menuOptions();
            choice = Console.ReadLine();
            logger.Info("User choice: {Choice}", choice);

                if (choice == "1")
                {
                    display.whatTicketTypeMenu();
                    ticketChoice = Console.ReadLine();
                    logger.Info("Ticket choice: {ticketChoice}", ticketChoice);
                    if (ticketChoice == "1")
                    {
                        foreach (Ticket m in bugDefectTicket.BugDefectTickets)
                        {
                            Console.WriteLine(m.DisplayTicket());
                        }
                    }
                    else if(ticketChoice == "2")
                    {
                        foreach (Ticket m in enhancementTicket.EnhancementTickets)
                        {
                            Console.WriteLine(m.DisplayTicket());
                        }
                    }
                    else if (ticketChoice == "3")
                    {
                        foreach (Ticket m in taskTicket.TaskTickets)
                        {
                            Console.WriteLine(m.DisplayTicket());
                        }
                    }
                }

                if (choice == "2")
                {
                    
                    display.whatTicketTypeMenu();
                    ticketChoice = Console.ReadLine();
                    logger.Info("Ticket choice: {ticketChoice}", ticketChoice);
                    if (ticketChoice == "1")
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
                
                         bugDefectTicket.AddBugDefectTicket(bugDefect);
                                    
                    }
                    if (ticketChoice == "2")
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

                    
                        enhancementTicket.AddEnhancemant(enhancement);
                    }
                    if (ticketChoice == "3")
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
                       
                        taskTicket.AddTask(task);

                    }
                }
            } 
            while (choice == "1" || choice == "2");
            logger.Info("Program ended");
        }
    }
}
