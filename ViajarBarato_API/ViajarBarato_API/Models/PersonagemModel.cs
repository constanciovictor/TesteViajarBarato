using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ViajarBarato_API.Models
{
    public class PersonagemModel
    {
        
        public string name { get; set; }

        public string homeworld { get; set; }

        public List<string> species { get; set; }

        //public EspecieModel Especie { get; set; }
        //public PlanetaModel Planeta { get; set; }
    }

    public class ObjetoRetorno
    {
        public int count { get; set; }
        public string next { get; set; }
        public string previous { get; set; }

        public List<PersonagemModel> results { get; set; }
    }
}