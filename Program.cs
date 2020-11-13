using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using ScrapySharp.Extensions;

namespace ProyectoArqui
{
   class Program
    {
        static void Main(string[] args)
        {
            //Operaciones prueba = new Operaciones();
            //prueba.PrimeraPagina();
            //Operaciones prueba2 = new Operaciones();
            //prueba2.PrimeraCalificacion();
            //Operaciones prueba3 = new Operaciones();
            //prueba3.SegundaPagina();
            //Operaciones prueba4 = new Operaciones();
            //prueba4.SegundaCalificacion();
            Operaciones prueba5 = new Operaciones();
            prueba5.TerceraPagina();
        }
    }
}
