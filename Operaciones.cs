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
        public int califinal2;
        public float califinal;
        //recibe el titulo compara y devuelve la calificacion
        public float PrimeraPagina(String nombre) // obtiene los titulos y calificacion de todas las peliculas en la página sensacine
        {
            List<String> lista = new List<String>();
            HtmlWeb web1 = new HtmlWeb();
            String url = "http://www.sensacine.com/peliculas/mejores/nota-sensacine/decada-2020/";
            HtmlDocument document = web1.Load(url);

            foreach (var nodo in document.DocumentNode.CssSelect(".data_box"))
            {
                var nodo2 = nodo.CssSelect("a.no_underline").First();               
                var titulo = nodo2.InnerHtml;
                if (titulo.Equals(nombre))
                {
                    var nodo3 = nodo.CssSelect(".note").First();                  
                    califinal = float.Parse(nodo3.InnerHtml);
                    break;
                }
            }
            url += "?page=";
            for (int i = 1; i <= 20; i++)//66
            {
                int s = i;
                String v = url + s;
                document = web1.Load(v);
                foreach (var nodo in document.DocumentNode.CssSelect(".data_box"))
                {
                    var nodo2 = nodo.CssSelect(".no_underline").First();
                    var titulo = nodo2.InnerHtml;
                    if (titulo.Equals(nombre))
                    {
                        var nodo3 = nodo.CssSelect(".note").First();
                        califinal = float.Parse(nodo3.InnerHtml);
                        break;
                    }
                }
            }
            return califinal;
        }



        public int SegundaPagina(String nombre)  // obtiene los titulos y calificacion de todas las peliculas en la página de metacritic
        {
            List<String> lista3 = new List<String>();
            HtmlWeb web3 = new HtmlWeb();
            String url = "https://www.metacritic.com/browse/movies/score/metascore/year/filtered?sort=desc";
            HtmlDocument document3 = web3.Load(url);

            foreach (var nodo in document3.DocumentNode.CssSelect(".clamp-summary-wrap"))
            {
                var nodo2 = nodo.CssSelect("h3").First();
                var titulo = nodo2.InnerHtml;
                if (titulo.Equals(nombre))
                {
                    var nodo3 = nodo.CssSelect(".metascore_w.large.movie").First();
                    califinal2 = Convert.ToInt32(nodo3.InnerHtml);
                    break;
                }               
            }
            url += "&page=";
            for (int i = 1; i <= 5; i++)//5
            {
                int s = i;
                String v = url + s;
                document3 = web3.Load(v);
                foreach (var nodo in document3.DocumentNode.CssSelect(".clamp-summary-wrap"))
                {
                    var nodo2 = nodo.CssSelect("h3").First();
                    var titulo = nodo2.InnerHtml;
                    if (titulo.Equals(nombre))
                    {
                        var nodo3 = nodo.CssSelect(".metascore_w.large.movie").First();
                        califinal2 = Convert.ToInt32(nodo3.InnerHtml);
                        break;
                    }                  
                }
            }      
            return califinal2;
        }
       


        public void TerceraPagina()  // obtiene la fecha de lanzamiento de todas las peliculas en la página de metacritic
        {
            List<String> lista5 = new List<String>();
            HtmlWeb web5 = new HtmlWeb();
            String url = "https://www.metacritic.com/browse/movies/score/metascore/year/filtered?sort=desc";
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
            for (int i = 1; i <= 5; i++)
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
