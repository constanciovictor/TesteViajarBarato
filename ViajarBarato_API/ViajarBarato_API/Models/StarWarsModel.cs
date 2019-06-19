using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ViajarBarato_API.Models
{
    public class StarWarsModel
    {
        public PersonagemModel Personagem { get; set; }

        public List<EspecieModel> Especie { get; set; }
        public PlanetaModel Planeta { get; set; }
    }
}