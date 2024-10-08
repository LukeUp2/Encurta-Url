using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Encurtador_Url.Api.Models
{
    public class Link
    {
        public int Id { get; set; }
        public string UrlOriginal { get; set; } = string.Empty;
        public string UrlShort { get; set; } = string.Empty;
        public string CreatedAt { get; set; } = DateTime.Now.ToString();
    }
}