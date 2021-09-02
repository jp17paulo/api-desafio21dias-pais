using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace api_desafio21dias.Servicos
{
    public class AlunoServico
    {
        public static async Task<bool> ValidarUsuario(int id)
        {
            //Para não dar erro de certificado
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            using (var http = new HttpClient(clientHandler))
            {
                try
                {
                    using (var response = await http.GetAsync($"{Program.AlunosApi}/alunos/{id}"))
                    {
                        return response.IsSuccessStatusCode;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}