using System;
using System.Collections.Generic;
using System.Text;

namespace MyMusic.Core
{
    public class Music
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ArtistId { get; set; }
        public Artitst Artist { get; set; }
    }
}
