using System.Collections.Generic;

namespace KinoAPBD
{
    public class Cennik
    {
        public int IDM { get; set; }
        public int Nr_sali { get; set; }
        public int Nr_miejsca { get; set; }
        public decimal Cena { get; set; }
        public IList<Cennik> Cen { get; set; }
    }
}
