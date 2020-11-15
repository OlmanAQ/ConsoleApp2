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
            //prueba.PrimeraPagina();
            //prueba.SegundaPagina();
            //prueba.TerceraPagina();

            //el error puede ser que la lista que mando de vyuelta con la calificacion tenga que cambair o no quien sabe mañana me dare
            //cuenta xd


            String linea;
            try
            {
                //Pasa la ruta del archivo y el nombre del archivo al constructor StreamReader
                StreamReader sr = new StreamReader("C:\\Users\\Kristel Salas\\source\\repos\\ProyectoArqui\\Peliculas.txt");//direccion local en donde se guarda el archivo
                linea = sr.ReadLine(); //Lee la primera línea de texto
                while (linea != null) //Continúa leyendo hasta llegar al final del archivo
                {
                    //Console.WriteLine(linea); //escribe la linea en la ventana de la consola
                    double cali = prueba.PrimeraPagina(linea); //se manda el tiulo y se devuelve la calificacion
                    int cali2 = prueba.SegundaPagina(linea); //se manda titulo y devuelve calificacion
                    Console.WriteLine("nombre de la película:"+linea + " Calificacion de la pelicula: " +cali);
                    Console.WriteLine("nombre de la película:" + linea + " Calificacion de la pelicula: " + cali2);
                    linea = sr.ReadLine(); //Lee la siguiente línea
                }               
                sr.Close();//cierra el archivo
            }
            catch (ArgumentOutOfRangeException outOfRange)
            {
                Console.WriteLine("Exception: " + outOfRange.Message);
                //Console.WriteLine("Exception: " + e.Message);
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
