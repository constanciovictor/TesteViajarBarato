using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using ViajarBarato_API.Models;

namespace ViajarBarato_API.Controllers
{
    public class PersonagemController : ApiController
    {   
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public List<StarWarsModel> Get()
        {
            List<PersonagemModel> p = new List<PersonagemModel>();
            List<PlanetaModel> pl = new List<PlanetaModel>();
            List<EspecieModel> es = new List<EspecieModel>();

            List<StarWarsModel> starWarsList = new List<StarWarsModel>();       

            #region Personagens

            //Personagens
            var requisicaoWeb = WebRequest.CreateHttp(ConfigurationManager.AppSettings["UrlPersonagens"]);
            requisicaoWeb.Method = "GET";
            requisicaoWeb.UserAgent = "RequisicaoWebDemo";
            using (var resposta = requisicaoWeb.GetResponse())
            {
                var streamDados = resposta.GetResponseStream();
                StreamReader reader = new StreamReader(streamDados);
                object objResponse = reader.ReadToEnd();

                var post = JsonConvert.DeserializeObject<ObjetoRetorno>(objResponse.ToString());

                if (post.results.Count > 0)
                {
                    post.results.ForEach(x => {

                        es = new List<EspecieModel>();

                        x.species.ForEach(y => { es.Add(this.ListaEspeciePorId(y)); });

                        var starWars = new StarWarsModel()
                        {
                            Personagem = x,
                            Planeta = this.ListaPlanetaPorId(x.homeworld),
                            Especie = es
                        };

                        starWarsList.Add(starWars);
                    });
                }
                
                streamDados.Close();
                resposta.Close();
            }

            #endregion

            return starWarsList;
        }

        public EspecieModel ListaEspeciePorId(string url)
        {
            
            //Especies
            var requisicaoWeb = WebRequest.CreateHttp(url);
            requisicaoWeb.Method = "GET";
            requisicaoWeb.UserAgent = "RequisicaoWebDemo";
            using (var resposta = requisicaoWeb.GetResponse())
            {
                var streamDados = resposta.GetResponseStream();
                StreamReader reader = new StreamReader(streamDados);
                object objResponse = reader.ReadToEnd();

                var post = JsonConvert.DeserializeObject<EspecieModel>(objResponse.ToString());

                //Console.WriteLine(post.Id + " " + post.title + " " + post.body);
                //Console.ReadLine();
                streamDados.Close();
                resposta.Close();

                return post;
            }
        }

        public PlanetaModel ListaPlanetaPorId(string url)
        {

            //Especies
            var requisicaoWeb = WebRequest.CreateHttp(url);
            requisicaoWeb.Method = "GET";
            requisicaoWeb.UserAgent = "RequisicaoWebDemo";
            using (var resposta = requisicaoWeb.GetResponse())
            {
                var streamDados = resposta.GetResponseStream();
                StreamReader reader = new StreamReader(streamDados);
                object objResponse = reader.ReadToEnd();

                var post = JsonConvert.DeserializeObject<PlanetaModel>(objResponse.ToString());

                //Console.WriteLine(post.Id + " " + post.title + " " + post.body);
                //Console.ReadLine();
                streamDados.Close();
                resposta.Close();

                return post;
            }
        }

    }
}
