using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Helpers;
using CandidateHub.Models;

namespace CandidateHub.Services
{
    public class CandidateRepository
   {
        //Cache to Save
      private const string HubCache = "CandidateStore";
       public CandidateRepository()
       {
           var myx = HttpContext.Current;
           if (myx != null)
           {
               if (myx.Cache[HubCache] == null)
               {
                   var candidates = new Candidate[]
                   {
                        new Candidate
                        //Sample Candidate
               {
                   Id=1,
                   FirstName="Juma",
                   LastName="Mkasha",
                   PhoneNo=0773513659,
                   Email="jdmkasha@gmail.com",
                   TimeInterval=72,
                   LinkedIn="https://linkedin.com/in/jumamkasha",
                   GitHub="https://github.io/jdmkasha",
                   Comment="Middle Full Stack Developer"
               }
                   };
                   myx.Cache[HubCache] = candidates;
               }
           }
       } 
    /*public class CandidateRepository
    {
        // private const string HubCache = "CandidateStore";
        public CandidateRepository()
        {
            var candidates = new Candidate[]
                     {
                          new Candidate
                 {
                 }
                     };
            String file = @"C:\Users\Admin\Desktop\Candidate.csv";
            String separator = ",";
            StringBuilder output = new StringBuilder();
            String[] headings =
            {
                "ID", "First Name", "Last Name", "Phone", "Email", "Time Interval", "Linkedin URL", "GitHub URL", "Comment"
            };
            output.AppendLine(string.Join(separator, headings));

            foreach (Candidate candidate in candidates)
            {
                String[] newLine = { candidate.Id.ToString(), candidate.FirstName, candidate.LastName, candidate.PhoneNo.ToString(), candidate.Email, candidate.TimeInterval.ToString(), candidate.LinkedIn, candidate.GitHub, candidate.Comment };
                output.AppendLine(string.Join(separator, newLine));
            }
            try
            {
                File.AppendAllText(file, output.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Data could not be written in CSV file");
            }
            Console.WriteLine("Successfully Saved in CSV File");

        } */
        public Candidate[] GetCandidates()
        {
            var bango = HttpContext.Current;
            if (bango != null)

            {
                return (Candidate[])bango.Cache[HubCache];

            }
            return new Candidate[]
            {
                 new Candidate
                {
                    Id=0,
                    FirstName="Placeholder",
                    LastName="Placeholder",
                    PhoneNo=0,
                    Email="Email",
                    TimeInterval=0,
                    LinkedIn="Linkedin Url",
                    GitHub="GitHub Url",
                    Comment="Comment"
                }

            };
        }

        public bool SaveData(Candidate candidate)
        {
            var kitita = HttpContext.Current;
            if (kitita != null)
            {
                try
                {
                    var liveData = ((Candidate[])kitita.Cache[HubCache]).ToList();
                    liveData.Add(candidate);
                     kitita.Cache[HubCache] = liveData.ToArray();
                     return true;

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return false;
                }
            }
            return false;
        }

    }
}