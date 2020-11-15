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

        public void PrimeraPagina() // obtiene los titulos de todas las peliculas en la página sensacine
        {
            List<String> lista = new List<String>();
            HtmlWeb web1 = new HtmlWeb();

            String url = "http://www.sensacine.com/peliculas/criticas-sensacine/";
            HtmlDocument document = web1.Load(url);
            foreach (var nodo in document.DocumentNode.CssSelect(".meta-title-link"))
            {
                lista.Add(nodo.InnerHtml);
            }
            url += "?page=";
            for (int i = 1; i <= 4; i++) 
            {
                int s = i;
                String v = url + s;
                document = web1.Load(v);
                foreach (var nodo in document.DocumentNode.CssSelect(".meta-title-link"))
                {
                    lista.Add(nodo.InnerHtml);
                }               
            }

            foreach (var item in lista)
            {
                Console.WriteLine("Nombre de película"+item);
            }           
        }
        public void Sinopsis() // obtiene los titulos de todas las peliculas en la página sensacine
        {
            List<String> lista = new List<String>();
            HtmlWeb web1 = new HtmlWeb();

            String url = "http://www.sensacine.com/peliculas/criticas-sensacine/";
            HtmlDocument document = web1.Load(url);
            foreach (var nodo in document.DocumentNode.CssSelect(".content-txt"))
            {
                lista.Add(nodo.InnerHtml);
            }
            url += "?page=";
            for (int i = 1; i <= 4; i++)
            {
                int s = i;
                String v = url + s;
                document = web1.Load(v);
                foreach (var nodo in document.DocumentNode.CssSelect(".content-txt"))
                {
                    lista.Add(nodo.InnerHtml);
                }
            }

            foreach (var item in lista)
            {
                Console.WriteLine("Signosis:" + item);
            }
        }
        public void PrimeraCalificacion() // obtiene las calificaciones de todas las peliculas en la página sensacine
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
            for (int i = 1; i <= 410; i++)
            {
                int s = i;
                String v = url + s;
                document2 = web2.Load(v);
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

        public void SegundaPagina()  // obtiene los titulos de todas las peliculas en la página de metacritic
        {
            List<String> lista3 = new List<String>();
            HtmlWeb web3 = new HtmlWeb();
            String url = "https://www.metacritic.com/browse/movies/score/metascore/year/filtered?sort=desc";
            HtmlDocument document3 = web3.Load(url);

            foreach (var nodo in document3.DocumentNode.CssSelect("a.title"))
            {
                lista3.Add(nodo.InnerHtml);
            }
            url += "&page=";
            for (int i = 1; i <= 5; i++)
            {
                int s = i;
                String v = url + s;
                Console.WriteLine(v);
                document3 = web3.Load(v);
                foreach (var nodo in document3.DocumentNode.CssSelect("a.title"))
                {
                    lista3.Add(nodo.InnerHtml);
                }
            }

            foreach (var item in lista3)
            {
                Console.WriteLine("nombre de pelicula: " + item);//van en el mismo orden que las peliculas
            }            
        }

        public void SegundaCalificacion()  // obtiene las calificaciones de todas las peliculas en la página de metacritic
        {
            List<String> lista4 = new List<String>();
            HtmlWeb web4 = new HtmlWeb();
            String url = "https://www.metacritic.com/browse/movies/score/metascore/all/filtered?sort=desc";
            HtmlDocument document4 = web4.Load(url);

            foreach (var nodo in document4.DocumentNode.CssSelect(".metascore_w.large.movie"))
            {
                lista4.Add(nodo.InnerHtml);
            }
            url += "&page=";
            for (int i = 1; i <= 137; i++)
            {
                int s = i;
                String v = url + s;
                document4 = web4.Load(v);
                foreach (var nodo in document4.DocumentNode.CssSelect(".metascore_w.large.movie"))
                {
                    lista4.Add(nodo.InnerHtml);
                }
            }

            foreach (var item in lista4)
            {
                Console.WriteLine("nota de pelicula: " + item);//van en el mismo orden que las peliculas
            }
        }

        //Esta aun no obtiene solo la fecha de lanzamiento.
        public void TerceraPagina()  // obtiene la fecha de lanzamiento de todas las peliculas en la página de metacritic
        {
            List<String> lista5 = new List<String>();
            HtmlWeb web5 = new HtmlWeb();
            String url = "https://www.metacritic.com/browse/movies/score/metascore/all/filtered?sort=desc";
            HtmlDocument document5 = web5.Load(url);

            foreach (var nodo in document5.DocumentNode.CssSelect(".clamp-details"))
            {
                lista5.Add(nodo.InnerHtml);
            }
            url += "&page=";
            for (int i = 1; i <= 20; i++)
            {
                int s = i;
                String v = url + s;
                document5 = web5.Load(v);
                foreach (var nodo in document5.DocumentNode.CssSelect(".clamp-details"))
                {
                    lista5.Add(nodo.InnerHtml);
                }
            }

            foreach (var item in lista5)
            {
                Console.WriteLine("nota de pelicula: " + item);//van en el mismo orden que las peliculas
            }


        }

    }
}
