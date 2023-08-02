using CommunityToolkit.Mvvm.Input;
using Complex19.Connectivity;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Complex19
{
    public class MainPageViewModel : BindableObject
    {
        private readonly IGeminiClientFactory _geminiClientFactory;

        public MainPageViewModel( IGeminiClientFactory geminiClientFactory ) 
        {
            _geminiClientFactory = geminiClientFactory;
            NavigateTest = new RelayCommand( () =>
            {
                var uri = new Uri("gemini://gemini.circumlunar.space");
                var client = _geminiClientFactory.CreateClient();
                var response = client.SendRequest(new GeminiRequest(uri));

                var contentType = new ContentType(response.MetaData);
                if (contentType.CharSet == null)
                {
                    contentType.CharSet = "UTF-8";
                }
                if (contentType.MediaType == null)
                {
                    contentType.MediaType = "text/gemini";
                }

                var encoding = Encoding.GetEncoding(contentType.CharSet);
                var bytes = new byte[response.Content.Length];
                using var charsetStreamReader = new StreamReader(response.Content, encoding);
                var txt = charsetStreamReader.ReadToEnd();
                Debug.WriteLine(txt);

                response.Dispose();
            });
        }

        public ICommand NavigateTest { get; }
    }
}
