using System;
using System.Net;
using System.IO;

using Newtonsoft.Json.Linq;

namespace Ejercicio1
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo userKey;
            string title;
            int x, y;

            while (true)
            {
                Console.Write("Introduzca el nombre de la pelicula:");
                x = Console.CursorLeft;
                y = Console.CursorTop;
                Console.Write("\nPress ENTER to exit");
                Console.SetCursorPosition(x, y);

                userKey = Console.ReadKey();
                if (userKey.Key == ConsoleKey.Enter)
                    break;
                else title = userKey.Key.ToString() + Console.ReadLine();

                    //request a la pagina
                    WebRequest req = WebRequest.Create("http://www.omdbapi.com/?t="
                        + "[" + title + "]&");

                WebResponse respuesta = req.GetResponse();

                //stream de la respuesta de la pagina
                Stream stream = respuesta.GetResponseStream();

                //leo el stream
                StreamReader sr = new StreamReader(stream);

                //creo un objeto json con lo q leo del stream
                JObject data = JObject.Parse(sr.ReadToEnd());
      
                Console.SetCursorPosition(0, y + 2);
                Console.WriteLine("Year:" + (string)data["Year"]);
                Console.WriteLine("Error:" + (string)data["Error"]);
            }


            //Console.WriteLine(data.ToString());

        }

    }
}
