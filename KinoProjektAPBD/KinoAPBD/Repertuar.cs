using System;
using System.Collections.Generic;

namespace KinoAPBD
{
    public class Repertuar
    {
        public int IDS { get; set; }
        public int IDF { get; set; }
        public DateTime Termin { get; set; }
        public int Nr_sali { get; set; }
        public string Tytul { get; set; }
        public string Rezyser { get; set; }
        public int Dlugosc { get; set; }
        public IList<Repertuar> Rep { get; set; }
    }
}
