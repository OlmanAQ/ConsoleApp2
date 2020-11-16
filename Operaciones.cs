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
        public String fecha, descripcion;

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
            for (int i = 1; i <= 66; i++)//66
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



        public int SegundaPagina(String nombre2)  // obtiene los titulos y calificacion de todas las peliculas en la página de metacritic
        {
            HtmlWeb web3 = new HtmlWeb();
            String url = "https://www.metacritic.com/browse/movies/score/metascore/year/filtered?sort=desc";
            HtmlDocument document3 = web3.Load(url);

            foreach (var nodo in document3.DocumentNode.CssSelect(".clamp-summary-wrap"))
            {
                var nodo2 = nodo.CssSelect("h3").First();
                var titulo2 = nodo2.InnerHtml;
                if (titulo2.Equals(nombre2))
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
                    var titulo2 = nodo2.InnerHtml;
                    if (titulo2.Equals(nombre2))
                    {
                        var nodo3 = nodo.CssSelect(".metascore_w.large.movie").First();
                        califinal2 = Convert.ToInt32(nodo3.InnerHtml);
                        break;
                    }                  
                }
            }      
            return califinal2;
        }       


        public String TerceraPagina(String nombre3)  // obtiene la fecha de lanzamiento de todas las peliculas en la página de metacritic
        {
            HtmlWeb web5 = new HtmlWeb();
            String url = "https://www.metacritic.com/browse/movies/score/metascore/year/filtered?sort=desc";
            HtmlDocument document5 = web5.Load(url);

            foreach (var nodo in document5.DocumentNode.CssSelect(".clamp-summary-wrap"))
            {
                var nodo2 = nodo.CssSelect("h3").First();
                String titulo3 = nodo2.InnerHtml;
                if (nombre3.Equals(titulo3))
                {
                    var nodo3 = nodo.CssSelect(".clamp-details");
                    var nodo4 = nodo3.CssSelect("span").First();
                    fecha = nodo4.InnerHtml;
                    break;
                }
            }
            url += "&page=";
            for (int i = 1; i <= 5; i++)//5
            {
                int s = i;
                String v = url + s;
                document5 = web5.Load(v);
                foreach (var nodo in document5.DocumentNode.CssSelect(".clamp-summary-wrap"))
                {
                    var nodo2 = nodo.CssSelect("h3").First();
                    String titulo3 = nodo2.InnerHtml;
                    if (nombre3.Equals(titulo3))
                    {
                        var nodo3 = nodo.CssSelect(".clamp-details");
                        var nodo4 = nodo3.CssSelect("span").First();
                        fecha = nodo4.InnerHtml;
                        break;
                    }
                }
            }
            return fecha;   
        }


        public String Sinopsis(String nombre3) // obtiene la sinopsis de cada película
        {
            HtmlWeb web1 = new HtmlWeb();
            String url = "http://www.sensacine.com/peliculas/mejores/nota-sensacine/decada-2020/";
            HtmlDocument document = web1.Load(url);
            foreach (var nodo in document.DocumentNode.CssSelect(".data_box"))
            {
                var nodo2 = nodo.CssSelect(".tt_18.d_inline").First();
                var prueba = nodo2.CssSelect("a.no_underline");
                String titulo = Convert.ToString(prueba.First().InnerText);
                //Console.WriteLine(titulo);
                if (String.Equals(nombre3, titulo))
                {
                    var nodo3 = nodo.CssSelect("p").First();
                    descripcion = nodo3.InnerHtml;
                    //Console.WriteLine(descripcion);
                    break;
                }
            }
            url += "?page=";
            for (int i = 1; i <= 66; i++)//66
            {
                int s = i;
                String v = url + s;
                document = web1.Load(v);
                foreach (var nodo in document.DocumentNode.CssSelect(".data_box"))
                {
                    var nodo2 = nodo.CssSelect(".tt_18.d_inline").First();
                    var prueba = nodo2.CssSelect("a");
                    String titulo = Convert.ToString(prueba.First().InnerHtml);
                    //Console.WriteLine(titulo);
                    if (String.Equals(nombre3, titulo))
                    {
                        var nodo3 = nodo.CssSelect("p").First();
                        descripcion = nodo3.InnerHtml;
                        //Console.WriteLine(descripcion);
                        break;
                    }

                }
            }
            return descripcion;
        }

    }
}
