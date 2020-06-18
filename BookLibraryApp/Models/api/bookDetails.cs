using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BookLibraryApp.Models.api
{
    public class bookDetails
    {
        [JsonPropertyName("publisher")]
        public string publisher { get; set; }
        [JsonPropertyName("synopsys")]
        public string synopsys { get; set; }
        [JsonPropertyName("language")]
        public string language { get; set; }
        [JsonPropertyName("image")]
        public string image { get; set; }
        [JsonPropertyName("title_long")]
        public string title_long { get; set; }
        [JsonPropertyName("edition")]
        public string edition { get; set; }
        [JsonPropertyName("pages")]
        public int pages { get; set; }
        [JsonPropertyName("date_published")]
        public string date_published { get; set; }
        [JsonPropertyName("authors")]
        public string[] authors { get; set; }
        [JsonPropertyName("title")]
        public string title { get; set; }
        [JsonPropertyName("isbn13")]
        public string isbn13 { get; set; }
        [JsonPropertyName("msrp")]
        public string msrp { get; set; }
        [JsonPropertyName("binding")]
        public string binding { get; set; }
        [JsonPropertyName("publish_date")]
        public string publish_date { get; set; }
        [JsonPropertyName("isbn")]
        public string isbn { get; set; }



        //public string dewey_decimal { get; set; }
        //public string dimensions { get; set; }
        //public string overview { get; set; }
        //public string excerpt { get; set; }


        //public string[] subjects { get; set; }
        //public string[] reviews { get; set; }
        //public string[] prices { get; set; }
    }
}
