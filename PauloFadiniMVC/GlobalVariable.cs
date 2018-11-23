using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Net.Http.Headers;

namespace PauloFadiniMVC
{
    
    static class GlobalVariable
    {
        public static HttpClient WebApiClient = new HttpClient();

        static GlobalVariable()
        {
            //Adicionamos o endereço da aplicação API
            WebApiClient.BaseAddress = new Uri("http://localhost:58646/api/");
            //Adicionamos uma limpeza de dados na variável
            WebApiClient.DefaultRequestHeaders.Clear();
            //Adicionamos o tipo do Json
            WebApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

    }
}