using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace FebrabanFeriados
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var url = "https://feriadosbancarios.febraban.org.br/Home/ObterFeriadosFederais?ano=2025";

            using var handler = new HttpClientHandler
            {
                UseCookies = false
            };

            using var client = new HttpClient(handler);

            var request = new HttpRequestMessage(HttpMethod.Get, url);

            // Headers
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("text/javascript"));
            request.Headers.Add("Accept-Language", "pt-BR,pt;q=0.9,en-US;q=0.8,en;q=0.7");
            request.Headers.Add("Connection", "keep-alive");
            request.Headers.Add("Referer", "https://feriadosbancarios.febraban.org.br/");
            request.Headers.Add("Request-Id", "|bd3caadcb9b642fd9f54869df36a0649.94bdf403ae0c4e0f");
            request.Headers.Add("Sec-Fetch-Dest", "empty");
            request.Headers.Add("Sec-Fetch-Mode", "cors");
            request.Headers.Add("Sec-Fetch-Site", "same-origin");
            request.Headers.Add("User-Agent", "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_15_7) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/136.0.0.0 Safari/537.36");
            request.Headers.Add("X-Requested-With", "XMLHttpRequest");
            request.Headers.Add("sec-ch-ua", "\"Chromium\";v=\"136\", \"Google Chrome\";v=\"136\", \"Not.A/Brand\";v=\"99\"");
            request.Headers.Add("sec-ch-ua-mobile", "?0");
            request.Headers.Add("sec-ch-ua-platform", "\"macOS\"");
            request.Headers.Add("traceparent", "00-bd3caadcb9b642fd9f54869df36a0649-94bdf403ae0c4e0f-01");

            request.Headers.Add("Cookie", "cookiesession1=678A3E1CC9C1F1BB6B2678FA1012F90B; _ga=GA1.1.312471641.1748892569; ai_user=4t1qsm0eBwoVsh+UNmMGgo|2025-06-02T19:29:29.286Z; ai_session=kz6LeWtKnC1Z5vg9qzRDnr|1748892569393|1748892569393; _ga_KJWKM4PZXY=GS2.1.s1748892568$o1$g1$t1748892583$j45$l0$h0");

            try
            {
                var response = await client.SendAsync(request);

                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();
                Console.WriteLine("Resposta da API:\n");
                Console.WriteLine(json);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Erro ao acessar API: {e.Message}");
            }
        }
        
        // static async Task Main(string[] args)
        // {
        //     var url = "https://feriadosbancarios.febraban.org.br/Municipais/Listar";

        //     using var client = new HttpClient();
        //     client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0");

        //     try
        //     {
        //         var html = await client.GetStringAsync(url);

        //         var htmlDoc = new HtmlDocument();
        //         htmlDoc.LoadHtml(html);

        //         var inputToken = htmlDoc.DocumentNode.SelectSingleNode("//input[@id='Token']");

        //         if (inputToken != null)
        //         {
        //             var tokenValue = inputToken.GetAttributeValue("value", string.Empty);
        //             Console.WriteLine("Token capturado:");
        //             Console.WriteLine(tokenValue);
        //         }
        //         else
        //         {
        //             Console.WriteLine("Token não encontrado na página.");
        //         }
        //     }
        //     catch (Exception ex)
        //     {
        //         Console.WriteLine($"Erro ao capturar token: {ex.Message}");
        //     }
        // }
    }
}
