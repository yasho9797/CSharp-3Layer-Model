using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools
{
    public static class LogManager
    {
        private static string Path = "Log";

        
        // מחזיר את השנה הנוכחית
        public static string getYearFolder()
        {
            return Path + "/" + DateTime.Now.Year.ToString();
        }

        //מחזיר את השנה ואת החודש
        public static string getFolderMonth()
        {
            return getYearFolder() + DateTime.Now.Month.ToString();
        }

        //מחזיר את הקובץ הנוכחי בתוך החודש
        public static string getFile()
        {
            return getFolderMonth() + "/" + DateTime.Now.Year.ToString() + ".txt";
        }

        public static void WriteToLog(string projectName, string funcName, string message)
        {
          
            string Folder = getFolderMonth();
            string YearFolder = getYearFolder();
            string File = getFile();

            if(!Directory.Exists(Folder))
                Directory.CreateDirectory(Folder);
            if(!Directory.Exists(YearFolder)) 
                Directory.CreateDirectory(YearFolder);
            if(!Directory.Exists(File))
                Directory.CreateDirectory(File);

            using(StreamWriter writerText = new StreamWriter(File))
            {
                writerText.WriteLine($"{DateTime.Now}\t{projectName}.{funcName}:\t {message}");
            }
        }

        //פונקציה שמוחקת את ה2 החודשים האחרונים ובודקת האם קיימים
        public static void DeleteOldFolder()
        {
            if (!Directory.Exists(getFile()))
                return;
            string[] nameFolders = Directory.GetDirectories(Path);

            foreach (string dir in nameFolders)
            {
                string[] dateFolder = dir.Split('/');
                if (dateFolder.Length > 2)
                    continue;
                int year = (int.Parse(dateFolder[0]));
                int month = (int.Parse(dateFolder[1]));
                if (year == DateTime.Now.Year)
                {
                    if (month + 2 < DateTime.Now.Month)
                    {
                        Directory.Delete(dir, true);
                    }
                }
                else
                {
                    if (DateTime.Now.Month == 1)
                    {
                        if (month != 11 && month != 12)
                        {
                            Directory.Delete(dir, true);
                        }
                    }
                    if (DateTime.Now.Month == 2)
                    {
                        if (month != 12)
                        {
                            Directory.Delete(dir, true);
                        }
                    }
                }


            }



        }
    }
}
