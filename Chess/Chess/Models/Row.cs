using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chess.Models
{
    // Data die de frontend nodig heeft om een rij op het bord weer te kunnen geven
    public class Row
    {
        public int Number { get; set; }
        public List<Field> Fields { get; set; }
    }
}
