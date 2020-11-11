using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using ScrapySharp.Extensions;

namespace ProyectoArqui
{
    class Operaciones
    {

        public void PrimeraPagina()
        {
            List<String> lista = new List<String>();
            HtmlWeb web1 = new HtmlWeb();

            String url = "http://www.sensacine.com/peliculas/criticas-sensacine/";
            HtmlDocument document1 = web1.Load(url);
            foreach (var nodo in document1.DocumentNode.CssSelect(".meta-title-link"))
            {
                lista.Add(nodo.InnerHtml);
            }
            url += "?page=";
            for (int i = 1; i <= 30; i++) 
            {
                int s = i;
                String v = url + s;
                //Console.WriteLine(v);
                HtmlDocument document2 = web1.Load(v);
                foreach (var nodo in document2.DocumentNode.CssSelect(".meta-title-link"))
                {
                    lista.Add(nodo.InnerHtml);
                }               
            }

            foreach (var item in lista)
            {
                Console.WriteLine("Nombre de película"+item);
            }           
        }

        public void Nota()
        {
            List<String> lista2 = new List<String>();
            HtmlWeb web2 = new HtmlWeb();
            String url = "http://www.sensacine.com/peliculas/criticas-sensacine/";
            HtmlDocument document2 = web2.Load(url);

            foreach (var nodo in document2.DocumentNode.CssSelect(".stareval-note"))
            {
                lista2.Add(nodo.InnerHtml);
            }
            url += "?page=";
            for (int i = 1; i <= 30; i++)
            {
                int s = i;
                String v = url + s;
                HtmlDocument document3 = web2.Load(v);
                foreach (var nodo in document2.DocumentNode.CssSelect(".stareval-note"))
                {
                    lista2.Add(nodo.InnerHtml);
                }
            }

            foreach (var item in lista2)
            {
                Console.WriteLine("nota de pelicula"+item);//van en el mismo orden que las peliculas
            }

        }

    }
}
