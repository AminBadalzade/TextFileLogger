using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Without generics
namespace Generics
{
    public class OriginalTextFileProcessor
    {
        public static List<Person> LoadPeople(string filePath)
        {
            List<Person> output = new List<Person>();

            Person p;

            var lines = File.ReadAllLines(filePath).ToList();

            lines.RemoveAt(0);

            foreach (var line in lines)
            {
                var vals = line.Split(',');
                p = new Person();

                p.FirstName = vals[0];
                p.IsAlive = bool.Parse(vals[1]);
                p.LastName = vals[2];

                output.Add(p);
            }

            return output;
        }

        public static List<LogEntry> LoadLogs(string filePath)
        {
            List<LogEntry> output = new List<LogEntry>();

            LogEntry log;

            var lines = File.ReadAllLines(filePath).ToList();

            lines.RemoveAt(0);

            foreach (var line in lines)
            {
                var vals = line.Split(',');
                log = new LogEntry();

                log.ErrorCode = int.Parse(vals[0]);
                log.Messager = vals[1];
                log.TimeOfEvent = DateTime.Parse(vals[2]);

                output.Add(log);
            }

            return output;
        }

        public static void SaveLogs(List<LogEntry> log, string filePath)
        {
            List<string> lines = new List<string>();

            //Add a header row
            lines.Add("ErrorCode,Message,TimeOfEvent");

            foreach (var l in log)
            {
                lines.Add($"{l.ErrorCode},{l.Messager},{l.TimeOfEvent}");
            }

            File.WriteAllLines(filePath, lines);
        }

        public static void SavePeople(List<Person> people, string filePath)
        {
             List<string> lines = new List<string>();

            //Add a header row
            lines.Add("FirstName,IsAlive,LastName");

            foreach (var p in people)
            {
                lines.Add($"{p.FirstName},{p.IsAlive},{p.LastName}");
            }

            File.WriteAllLines(filePath, lines);
        }
    }
}
