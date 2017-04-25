using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.IO;

using Newtonsoft.Json.Linq;

namespace Ejercicio2
{
    class Program
    {

        static void Main(string[] args)
        {
            ConsoleKeyInfo userKey;
            string city;
            int x, y;

            while (true)
            {
                Console.Write("Introduzca el nombre de la ciudad:");
                x = Console.CursorLeft;
                y = Console.CursorTop;
                Console.Write("\nPress ENTER to exit");
                Console.SetCursorPosition(x, y);

                userKey = Console.ReadKey();
                if (userKey.Key == ConsoleKey.Enter)
                    break;
                else city = userKey.Key.ToString() + Console.ReadLine();


                WebRequest req = WebRequest.Create("https://maps.googleapis.com/maps/api/geocode/json?address="
                    + city);
                WebResponse respuesta = req.GetResponse();
                Stream stream = respuesta.GetResponseStream();
                StreamReader sr = new StreamReader(stream);
                JObject data = JObject.Parse(sr.ReadToEnd());

                Console.SetCursorPosition(0, y + 2);
                string res = "";
                int i = 0;
                while (res != "country" && res != "dato erroneo")
                {
                    try
                    {
                        res = (string)data["results"][0]["address_components"][i]["types"][0];
                    }
                    catch (Exception e)
                    {
                        res = "dato erroneo";
                        Console.WriteLine(e.GetType().Name);
                        //Console.WriteLine(e.Message);
                    }
                    i++;
                }
                i--;

                if (res == "country")
                    Console.WriteLine("Pais: " +
                        (string)data["results"][0]["address_components"][i]["long_name"]);

                else Console.WriteLine("Ciudad no encontrada");
            }
        }
    }
}
