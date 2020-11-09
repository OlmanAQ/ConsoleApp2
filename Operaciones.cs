using System;
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
            HtmlWeb web1 = new HtmlWeb();
            HtmlDocument document1 = web1.Load("https://www.metacritic.com/");


        }

        public void SegundaPagina()
        {
            HtmlWeb web2 = new HtmlWeb();
            HtmlDocument document2 = web2.Load("");


        }

    }
}
