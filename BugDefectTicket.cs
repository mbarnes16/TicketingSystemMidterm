using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NLog.Web;
namespace TicketingSystemMidterm
{
    public class BugDefectTicket
    {
        public string filePath 
        {get; set;}
        public List<BugDefect> BugDefectTickets 
        {get; set;}
        private static NLog.Logger logger = NLogBuilder.ConfigureNLog(Directory.GetCurrentDirectory() + "\\nlog.config").GetCurrentClassLogger();
        public BugDefectTicket(string bugDefectTicketFilePath)
        {
            filePath = bugDefectTicketFilePath;
            BugDefectTickets = new List<BugDefect>();

            try
            {
                StreamReader sr = new StreamReader(filePath);
                while(!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    string[] ticketDetails = line.Split(',');

                      if (ticketDetails.Length == 8)
                    {
                        BugDefect bugDefect = new BugDefect();

                        bugDefect.ticketID = UInt64.Parse(ticketDetails[0]);
                        bugDefect.summary = ticketDetails[1];
                        bugDefect.status = ticketDetails[2];
                        bugDefect.priority = ticketDetails[3];
                        bugDefect.submitter = ticketDetails[4];
                        bugDefect.assigned = ticketDetails[5];
                        bugDefect.watching = ticketDetails[6].Split('|').ToList();
                        bugDefect.severity = ticketDetails[7];
                        BugDefectTickets.Add(bugDefect);
                    }
                }
                sr.Close();
                logger.Info("Tickets in file: {count}", BugDefectTickets.Count);
            }
            
            catch (Exception ex)
            {
                logger.Error(ex.Message);
            }
        }
        public void AddBugDefectTicket(BugDefect bugDefect)
        {
            try{
                    if (BugDefectTickets.Count == 0)
                    {
                    bugDefect.ticketID = 1;
                    }
                    else
                    {
                    bugDefect.ticketID = BugDefectTickets.Max(m => m.ticketID) + 1;
                    }
                StreamWriter sw = new StreamWriter(filePath, true);
                sw.WriteLine($"{bugDefect.ticketID},{bugDefect.summary},{bugDefect.status},{bugDefect.priority},{bugDefect.submitter},{bugDefect.assigned},{string.Join("|", bugDefect.watching)},{bugDefect.severity}");
                sw.Close();
                BugDefectTickets.Add(bugDefect);
                logger.Info("Ticket ID {ID} added", bugDefect.ticketID);
                }
                catch (Exception ex)
                    {
                    logger.Error(ex.Message);
                    }
        }
    }

}