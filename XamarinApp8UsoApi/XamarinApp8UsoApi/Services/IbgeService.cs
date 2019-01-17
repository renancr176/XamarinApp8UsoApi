using System;
using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json;
using XamarinApp8UsoApi.Models;

namespace XamarinApp8UsoApi.Services
{
    public class IbgeService
    {
        private static string _baseUrl = "https://servicodados.ibge.gov.br/api/";

        public List<EstadoModel> GetEstados()
        {
            WebClient wc = new WebClient();
            var jsonObj = wc.DownloadString(_baseUrl + "v1/localidades/estados");
            return JsonConvert.DeserializeObject<List<EstadoModel>>(jsonObj);
        }

        public List<MunicipioModel> GetMunicipioFromUf(int ufId)
        {
            WebClient wc = new WebClient();
            var jsonObj = wc.DownloadString(String.Format(_baseUrl+ "v1/localidades/estados/{0}/municipios", ufId));
            return JsonConvert.DeserializeObject<List<MunicipioModel>>(jsonObj);
        }
    }
}
