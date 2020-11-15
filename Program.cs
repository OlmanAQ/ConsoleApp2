using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using ScrapySharp.Extensions;
using System.IO;

namespace ProyectoArqui
{
   class Program
   {

        static void Main(string[] args)
        {
            Operaciones prueba = new Operaciones();

            //List<String> Peliculas = new List<string>() { "Mank", "Nomadland", "Tenet" };

            //foreach (var item in Peliculas)
            //{
            //    double cali = prueba.PrimeraPagina(item); //se manda el tiulo y se devuelve la calificacion
            //    int cali2 = prueba.SegundaPagina(item); //se manda titulo y devuelve calificacion
            //    Console.WriteLine("Pelicula: " + item + " Calificaciones: " + "Sensacine: " + cali + " Metacritic: " + cali2);
            //}




            String linea;
            try
            {
                //Pasa la ruta del archivo y el nombre del archivo al constructor StreamReader
                StreamReader sr = new StreamReader("C:\\Users\\Kristel Salas\\source\\repos\\ProyectoArqui\\Peliculas.txt");//direccion local en donde se guarda el archivo
                linea = sr.ReadLine(); //Lee la primera línea de texto
                float cali = prueba.PrimeraPagina(linea); //se manda el tiulo y se devuelve la calificacion
                int cali2 = prueba.SegundaPagina(linea); //se manda titulo y devuelve calificacion
                Console.WriteLine("--Nombre de la película:" + linea + " --Calificacion de la pelicula: " + " Sensacine:" + cali + " Metacritic:" + cali2);
                while (linea != null) //Continúa leyendo hasta llegar al final del archivo
                {
                    float cali3 = prueba.PrimeraPagina(linea); //se manda el tiulo y se devuelve la calificacion
                    int cali4 = prueba.SegundaPagina(linea); //se manda titulo y devuelve calificacion
                    Console.WriteLine("--Nombre de la película: " + linea + " --Calificacion de la pelicula: " + " Sensacine:" +cali3 +"  Metacritic:"+ cali4 );
                    linea = sr.ReadLine(); //Lee la siguiente línea
                }
                sr.Close();//cierra el archivo
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Fin del archivo");
            }

            //Parallel.Invoke(
            //    () =>
            //    {
            //        //Nombre de la funcion

            //    },  // cierre de la primera accion
            //    () =>
            //    {
            //        //nombre de la funcion

            //    }, //cierre de la segunda accion
            //    () =>
            //    {
            //        //nombre de la funcion

            //    } //cierre de la tercera accion
            //); //cierre del parallel invoke

        }
   }
}
