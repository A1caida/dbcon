using System;
using System.Data.Common;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace db
{
    struct owo
    {
        public string id;
        public string name;
        public string project;
        public string crew;

    }

    class Program
    {

        MySqlConnection uwu;

        public List<owo> kek()
        {
            MySqlConnectionStringBuilder stringBuilder = new MySqlConnectionStringBuilder();
            stringBuilder.Server = "localhost";
            stringBuilder.UserID = "root";
            stringBuilder.Database = "sowwy";
            stringBuilder.SslMode = MySqlSslMode.None;
            uwu = new MySqlConnection(stringBuilder.ConnectionString);

            MySqlCommand command = uwu.CreateCommand();
            Console.WriteLine("Введите команду: ");
            string Kurisu = Console.ReadLine(); // SELECT `year`, `name`, `project`,`crew` FROM sowwy.nazvanie JOIN  sowwy.projectt ON nazvanie.projecttt = projectt.id
            command.CommandText = Kurisu;

            List<owo> bd = new List<owo>();

            try
            {
                uwu.Open();
                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        owo databd = new owo
                        {
                            id = reader.GetString(0),
                            name = reader.GetString(1),
                            project = reader.GetString(2),
                            crew = reader.GetString(3),
                        };
                        bd.Add(databd);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return bd;
        }
        static void Main(string[] args)
        {
            Program Kurisu = new Program();
            var Maki = Kurisu.kek();
            foreach (var data in Maki)
            {
                Console.WriteLine(data.id + " | " + data.name.PadRight(15) + " | " + data.project.PadRight(10) + " | " + data.crew.PadRight(10));
            }
            Console.ReadLine();
        }
    }  
}



