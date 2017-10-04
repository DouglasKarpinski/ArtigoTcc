using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;

namespace Data.Services.Emotion
{
    public class EmotionService : IEmotionService
    {
        private const string _emotionWebApi = "http://emotionwebapi.azurewebsites.net/api/emotion/";
        private readonly string _token = "tokenzao RU1PVElPTldFQkFQSUxFT05BUkRPRURPVUdMQVNUQ0MyMDE3";

        public IList<Emotion> Demonstracao(string file)
        {
            if (string.IsNullOrEmpty(file))
                throw new NullReferenceException("Você precisa informar o arquivo!");

            var client = new HttpClient();

            client.DefaultRequestHeaders.Add("Authorization", _token);

            file = file.Replace("data:image/jpeg;base64,", "");
            file = file.Replace("data:image/png;base64,", "");

            var content = JsonConvert.SerializeObject(new {base64String = file});
            var buffer = Encoding.UTF8.GetBytes(content);
            var byteContent = new ByteArrayContent(buffer);

            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = client.PostAsync(_emotionWebApi + "demonstration", byteContent).Result;

            if (!response.IsSuccessStatusCode)
                throw new HttpRequestException("Ops...............Algo errado aconteceu, verifique!");

            var responseContent = response.Content.ReadAsStringAsync().Result;

            var emotion = JsonConvert.DeserializeObject<IList<Emotion>>(responseContent);

            return emotion;
        }
    }
}
