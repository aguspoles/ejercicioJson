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
            WebRequest req = WebRequest.Create("http://www.omdbapi.com/?t=[Terminator]&");

            WebResponse respuesta = req.GetResponse();

            Stream stream = respuesta.GetResponseStream();

            StreamReader sr = new StreamReader(stream);

            /*string pasoAMinuscula = sr.ReadToEnd();
            pasoAMinuscula.ToLower();*/
            JObject data = JObject.Parse(sr.ReadToEnd());
            Console.WriteLine((string)data["Titulo"]);
            string titulo;
            Console.Write("Introduzca el nombre de la pelicula:");
            titulo = Console.ReadLine();

            //string titulo = (string)data[año];

            Console.WriteLine(titulo);

            Console.ReadKey();
        }

    }
}
