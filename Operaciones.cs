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
        //recibe el titulo compara y devuelve la calificacion
        public double PrimeraPagina(String nombre) // obtiene los titulos y calificacion de todas las peliculas en la página sensacine
        {
            List<String> lista = new List<String>();
            HtmlWeb web1 = new HtmlWeb();

            String url = "http://www.sensacine.com/peliculas/criticas-sensacine/";
            HtmlDocument document = web1.Load(url);

            foreach (var nodo in document.DocumentNode.CssSelect(".card.entity-card.entity-card-list.cf"))
            {
                var nodo2 = nodo.CssSelect(".meta-title-link").First();
                //lista.Add(nodo2.InnerHtml);
                var titulo = nodo2.InnerHtml;
                if (titulo.Equals(nombre))
                {
                    var nodo3 = nodo.CssSelect(".stareval-note").First();                  
                    lista.Add(nodo3.InnerHtml);
                }
                
            }
            url += "?page=";
            for (int i = 1; i <= 10; i++)//410
            {
                int s = i;
                String v = url + s;
                document = web1.Load(v);
                foreach (var nodo in document.DocumentNode.CssSelect(".card.entity-card.entity-card-list.cf"))
                {
                    var nodo2 = nodo.CssSelect(".meta-title-link").First();
                    //lista.Add(nodo2.InnerHtml);
                    var titulo = nodo2.InnerHtml;
                    if (titulo.Equals(nombre))
                    {
                        var nodo3 = nodo.CssSelect(".stareval-note").First();
                        lista.Add(nodo3.InnerHtml);
                    }
                }
            }

            //foreach (var item in lista)
            //{
            //    Console.WriteLine(item);
            //}
            double califinal = Convert.ToDouble(lista[0]);
            return califinal;
        }
       


        public int SegundaPagina(String nombre)  // obtiene los titulos y calificacion de todas las peliculas en la página de metacritic
        {
            List<String> lista3 = new List<String>();
            HtmlWeb web3 = new HtmlWeb();
            String url = "https://www.metacritic.com/browse/movies/score/metascore/all/filtered?sort=desc";
            HtmlDocument document3 = web3.Load(url);

            foreach (var nodo in document3.DocumentNode.CssSelect(".clamp-summary-wrap"))
            {
                var nodo2 = nodo.CssSelect("h3").First();
                //lista3.Add(nodo2.InnerHtml);
                var titulo = nodo2.InnerHtml;
                if (titulo.Equals(nombre))
                {
                    var nodo3 = nodo.CssSelect(".metascore_w.large.movie").First();
                    lista3.Add(nodo3.InnerHtml);
                }               
            }
            url += "&page=";
            for (int i = 1; i <= 10; i++)//137
            {
                int s = i;
                String v = url + s;
                document3 = web3.Load(v);
                foreach (var nodo in document3.DocumentNode.CssSelect(".clamp-summary-wrap"))
                {
                    var nodo2 = nodo.CssSelect("h3").First();
                    //lista3.Add(nodo2.InnerHtml);
                    var titulo = nodo2.InnerHtml;
                    if (titulo.Equals(nombre))
                    {
                        var nodo3 = nodo.CssSelect(".metascore_w.large.movie").First();
                        lista3.Add(nodo3.InnerHtml);
                    }                  
                }
            }

            //foreach (var item in lista3)
            //{
            //    Console.WriteLine(item);
            //}
            int califinal = Convert.ToInt32(lista3[0]);
            return califinal;
        }
       


        public void TerceraPagina()  // obtiene la fecha de lanzamiento de todas las peliculas en la página de metacritic
        {
            List<String> lista5 = new List<String>();
            HtmlWeb web5 = new HtmlWeb();
            String url = "https://www.metacritic.com/browse/movies/score/metascore/all/filtered?sort=desc";
            HtmlDocument document5 = web5.Load(url);

            foreach (var nodo in document5.DocumentNode.CssSelect(".clamp-summary-wrap"))
            {
                var nodo2 = nodo.CssSelect("h3").First();
                lista5.Add(nodo2.InnerHtml);
                var nodo3 = nodo.CssSelect(".clamp-details");
                var nodo4 = nodo3.CssSelect("span").First();
                lista5.Add(nodo4.InnerHtml);
            }
            url += "&page=";
            for (int i = 1; i <= 10; i++)
            {
                int s = i;
                String v = url + s;
                document5 = web5.Load(v);
                foreach (var nodo in document5.DocumentNode.CssSelect(".clamp-summary-wrap"))
                {
                    var nodo2 = nodo.CssSelect("h3").First();
                    lista5.Add(nodo2.InnerHtml);
                    var nodo3 = nodo.CssSelect(".clamp-details");
                    var nodo4 = nodo3.CssSelect("span").First();
                    lista5.Add(nodo4.InnerHtml);
                }
            }

            foreach (var item in lista5)
            {
                Console.WriteLine("nota de pelicula: " + item);
            }
        }

    }
}
