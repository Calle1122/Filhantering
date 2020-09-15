using System;
using System.IO;
using System.Xml.Serialization;

namespace Filhantering
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Vill du skapa en ny spelare eller läsa en gammal?");
            System.Console.WriteLine("Skriv 'ny' eller 'gammal'");
            string svar = Console.ReadLine();

            if(svar == "ny")
            {
                Player myPlayer = new Player();

                System.Console.WriteLine("What is the Players name?");
                string name = Console.ReadLine(); 
                myPlayer.name = name;

                System.Console.WriteLine("What is the Players hp?");
                string hp = Console.ReadLine();
                int hpInt = int.Parse(hp);
                myPlayer.hp = hpInt;

                System.Console.WriteLine("What is the Players attack?");
                string atk = Console.ReadLine();
                int atkInt = int.Parse(atk);
                myPlayer.atk = atkInt;

                System.Console.WriteLine("What is the Players defense?");
                string def = Console.ReadLine();
                int defInt = int.Parse(def);
                myPlayer.def = defInt;

                XmlSerializer serializer = new XmlSerializer(typeof(Player));

                FileStream file = File.Open("player.xml", FileMode.OpenOrCreate);

                serializer.Serialize(file, myPlayer);

                file.Close();
            }

            else if(svar == "gammal")
            {
                Player myPlayer = new Player();

                XmlSerializer serializer = new XmlSerializer(typeof(Player));

                FileStream file = File.Open("player.xml", FileMode.OpenOrCreate);

                myPlayer = (Player) serializer.Deserialize(file);

                file.Close();

                System.Console.WriteLine(myPlayer.name);
                System.Console.WriteLine(myPlayer.hp);
                System.Console.WriteLine(myPlayer.atk);
                System.Console.WriteLine(myPlayer.def);

                Console.ReadLine();
            }
        }
    }
}
