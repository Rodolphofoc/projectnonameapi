using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace project.noname.domain.Models
{
    public class Music
    {
        public Music()
        {
            Authors = new List<Author>();
            TypeMusic = new TypeMusic();
        }
        public int IdMusic { get; set; }

        public string MusicName { get; set; }

        public TypeMusic TypeMusic { get; set; }

        public List<Author> Authors { get; set; }

    }
}
