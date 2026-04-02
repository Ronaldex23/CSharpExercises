using Newtonsoft.Json;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Winform_ConsultaCEP.Models;

namespace Winform_ConsultaCEP.Services
{
    class ConsultadorCep
    {
        private readonly HttpClient client = new HttpClient();

        public async Task<Endereco> ConsultaCEP(string _cep)
        {
            string url = $"https://viacep.com.br/ws/{_cep}/json/";
            HttpResponseMessage response = await client.GetAsync(url);

            response.EnsureSuccessStatusCode();

            string json = await response.Content.ReadAsStringAsync();
            
            //Desserialização do Json em C# Object
            Endereco? endereco = JsonConvert.DeserializeObject<Endereco>(json);

            if (endereco == null || endereco.Erro)
            {
                throw new Exception("CEP inválido ou inexistente. Tente novamente");
            }

            return endereco;
        }
    }
}
