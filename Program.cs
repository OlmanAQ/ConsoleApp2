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
            String linea;
            try
            {
                StreamReader sr = new StreamReader("C:\\Users\\Kristel Salas\\source\\repos\\ProyectoArqui\\Peliculas.txt");//direccion local en donde se guarda el archivo
                linea = sr.ReadLine(); //Lee la primera línea de texto               
                while (linea != null)  //Continúa leyendo hasta llegar al final del archivo
                {
                    Console.WriteLine("Pelicula: "+ linea);
                    Parallel.Invoke(
                        () =>
                        {
                            Parallel.Invoke(
                                    () =>
                                    {

                                        float cali3 = prueba.PrimeraPagina(linea);   //se manda el tiulo y se devuelve la calificacion
                                        Console.WriteLine("Calificacion sensacine: "+ cali3);

                                    },// cierre de la primera accion
                                    () =>
                                    {

                                        int cali4 = prueba.SegundaPagina(linea);     //se manda titulo y devuelve calificacion
                                        Console.WriteLine("Calificacion metacritic: " + cali4);

                                    }
                                );//cierre del parallel invoke

                        },  // cierre de la primera accion
                        () =>
                        {

                            String fecha2 = prueba.TerceraPagina(linea); //se manda titulo y devuelve fecha de lanzamiento
                            Console.WriteLine("Fecha exacta: " + fecha2);

                        }, //cierre de la segunda accion
                        () =>
                        {
                            //nombre de la funcion

                        } //cierre de la tercera accion
                    ); //cierre del parallel invoke                 
                    linea = sr.ReadLine(); //Lee la siguiente línea
                }
                sr.Close();//cierra el archivo
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }


            

        }
    }
}
