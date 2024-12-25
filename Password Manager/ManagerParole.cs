using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text;
using System;
using System.IO;

namespace Password_Manager
{
    public class ManagerParole
    {
        public static Random rand = new Random();
        public static string MainPassword = "";
        public static string Extensie = ".txt"; // Основной формат по умолчанию
        public static string NumeProgram = "Password Manager";
        public static string LocatieFisier = "";
        public static int LungimeParola = Properties.Settings.Default.lungimeParola;
        public static int SecundeStergereParola = 5;

        public static void SalveazaParolele(string path, string pass)
        {
            var data = new { Password = pass, Conturi = Cont.Conturi };
            string json = JsonConvert.SerializeObject(data, Formatting.Indented);
            File.WriteAllText(path, json);
        }

        public static bool CitesteConturi(string path, string parola)
        {
            try
            {
                string json = File.ReadAllText(path);
                var data = JsonConvert.DeserializeObject<dynamic>(json);
                if (data.Password == parola)
                {
                    Cont.Conturi = JsonConvert.DeserializeObject<List<Cont>>(Convert.ToString(data.Conturi));
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        public static void AdaugaExemple(int nr)
        {
            for (int i = 0; i < nr; i++)
            {
                Cont.Conturi.Add(new Cont($"email{i}", RandomString(LungimeParola), $"site{i}", "cont exemplu"));
            }
        }

        public static string CaracterePermise = Properties.Settings.Default.caractereParola;
        public static string RandomString(int length)
        {
            StringBuilder res = new StringBuilder();

            while (0 < length--)
            {
                res.Append(CaracterePermise[rand.Next(CaracterePermise.Length)]);
            }
            return res.ToString();
        }
    }
}
