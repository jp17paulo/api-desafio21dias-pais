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
                using (var response = await http.GetAsync($"{Program.AlunoApi}/alunos/{id}"))
                {
                    return response.IsSuccessStatusCode;
                }
            }
        }
    }
}