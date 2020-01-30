using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MyMusic.Core
{
    public class Artitst
    {
        public Artitst()
        {
            Musics = new Collection<Music>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Music> Musics { get; set; }
    }
}