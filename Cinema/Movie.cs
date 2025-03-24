using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema
{
    public class Movie
    {
        public int id {  get; set; }
        public string movie_name { get; set; }
        public DateTime release_date { get; set; }
        public string poster { get; set; }
        public bool IsShowing => release_date <= DateTime.Now;
    }
}
