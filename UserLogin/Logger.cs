using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace UserLogin
{
    static public class Logger
    {
        static public string ErrorCode;

        static private List<string> currentSessionActivities = new List<string>();
        static public void LogActivity(string activity)
        {
            string activityLine = DateTime.Now + ";"
                                + LoginValidation.userName + ";"
                                + LoginValidation.currentUserRole + ";"
                                + activity;
            currentSessionActivities.Add(activityLine);

            if (File.Exists("Logger.txt") == true)
            {
                File.AppendAllText("Logger.txt", activityLine);
            }
            else File.WriteAllText("Logger.txt", activityLine);
        }

        static public void LogFailedActivity(string ErrorMessage)
        {
            if (ErrorMessage.ToLower().Contains("username"))
            {
                ErrorCode = "0";
            }

            if (ErrorMessage.ToLower().Contains("password"))
            {
                ErrorCode = "1";
            }
            string activityLine = DateTime.Now + ";"
                                + ErrorMessage + ";"
                                + ErrorCode + ";";
            currentSessionActivities.Add(activityLine);

            if (File.Exists("LoginFail.txt") == true)
            {
                File.AppendAllText("LoginFail.txt", activityLine);
            }
            else File.WriteAllText("LoginFail.txt", activityLine);
        }
        static public IEnumerable<string> GetCurrentActivities(string filter)
        {
            List<string> filteredActivity = (from activity in currentSessionActivities where activity.Contains(filter) select activity).ToList();
            return filteredActivity;
        }

        static public IEnumerable<string> GetLogActivities()
        {
            StreamReader reader = new StreamReader("Logger.txt");
            List<string> activityLine = new List<string>();
            activityLine.Add(reader.ReadLine());
            return activityLine;
        }
    }
}