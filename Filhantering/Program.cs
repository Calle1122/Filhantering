using System;
using System.IO;
using System.Xml.Serialization;

namespace Filhantering
{
    class Program
    {
        static void Main(string[] args)
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



            // myPlayer = (Player) serializer.Deserialize(file);

            // Console.ReadLine();
        }
    }
}
