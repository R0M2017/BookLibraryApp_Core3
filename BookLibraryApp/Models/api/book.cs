using Org.BouncyCastle.X509.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BookLibraryApp.Models.api
{
    public class book
    {
        [JsonPropertyName("book")]
        public bookDetails Book { get; set; }
    }
}
