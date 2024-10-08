using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bogus;
using Encurtador_Url.Api.Data;
using Encurtador_Url.Api.Models;

namespace Encurtador_Url.Api.Services
{
    public class LinkServices
    {
        public string GerarUrlAleatoria()
        {
            var random = new Faker();
            string sequencia = random.Random.AlphaNumeric(10)[random.Random.Number(0, 5)..];
            return sequencia;
        }

        public Link? ObterUrlOriginal(string urlShort, AppDbContext context)
        {
            var link = context.Links.Where(x => x.UrlShort.Contains(urlShort)).FirstOrDefault();


            if (link == null)
            {
                return null;
            }

            return link;
        }
    }
}