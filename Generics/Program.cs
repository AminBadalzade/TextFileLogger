using System;
using System.Diagnostics;

namespace Generics
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsAlive { get; set; }
    }
    public class LogEntry
    {
        public string Messager { get; set; }
        public int ErrorCode { get; set; }

        public DateTime TimeOfEvent { get; set; } = DateTime.UtcNow;
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.ReadLine();

            DemonstrateTextFileStorage();

            Console.WriteLine();
            Console.Write("Press enter to shut down...");
            Console.ReadLine();
        }
        private static void DemonstrateTextFileStorage()
        {
            List<Person> people = new List<Person>();
            List<LogEntry> logs = new List<LogEntry>();

            //string PeopleFile = @"C:\Users\Amin0\OneDrive\İş masası\FileFor\People.csv";
            string LogsFile = @"C:\Users\Amin0\OneDrive\İş masası\FileFor\logs.csv";
            //File.Create(PeopleFile).Close();
            File.Create(LogsFile).Close();
            PopulateLists(people, logs);

            /* New way of doing things - generics */


            /* Old way of doing things - non-generics */

            //OriginalTextFileProcessor.SavePeople(people, PeopleFile);

            //var newPeople = OriginalTextFileProcessor.LoadPeople(PeopleFile);

            //foreach(var p in newPeople)
            //{
            //    Console.WriteLine($"{p.FirstName} {p.LastName} (IsAlive = {p.IsAlive})");
            //}

            //OriginalTextFileProcessor.SaveLogs(logs, LogsFile);

            //var newLogs = OriginalTextFileProcessor.LoadLogs(LogsFile);
            
            //foreach(var p in logs)
            //{
            //    Console.WriteLine($"{p.ErrorCode} {p.Messager} at {p.TimeOfEvent.ToShortDateString()}");
            //}
            
        }

        private static void PopulateLists(List<Person> people, List<LogEntry> logs)
        {
            people.Add(new Person { FirstName = "Amin", LastName = "Badalzade" });
            people.Add(new Person { FirstName = "Emin", LastName = "Bedel", IsAlive = true});
            people.Add(new Person { FirstName = "Edgar", LastName = "Goyjali" });
            people.Add(new Person { FirstName = "Asif", LastName = "AsifOglu" });

            logs.Add(new LogEntry {Messager = "Hello guys", ErrorCode = 9999 });
            logs.Add(new LogEntry { Messager = "Amin is dead", ErrorCode = 444 });
            logs.Add(new LogEntry { Messager = "Ikram is cooking", ErrorCode = 321 });
        }

    }
}