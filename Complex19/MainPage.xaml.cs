using Complex19.Connectivity;
using System.Diagnostics;
using System.Net.Mime;
using System.Text;

namespace Complex19;

public partial class MainPage : ContentPage
{
	public MainPage( MainPageViewModel viewModel )
	{
		InitializeComponent();
		BindingContext = viewModel;
	}

	//private void OnCounterClicked(object sender, EventArgs e)
	//{
	//	var uri = new Uri("gemini://gemini.circumlunar.space");
	//	var client = new GeminiClient();
	//	var response = client.SendRequest(new GeminiRequest(uri));

	//	var contentType = new ContentType(response.MetaData);
	//	if( contentType.CharSet == null )
	//	{
	//		contentType.CharSet = "UTF-8";
	//	}
	//	if( contentType.MediaType == null )
	//	{
	//		contentType.MediaType = "text/gemini";
	//	}
        
	//	var bytes = new byte[response.Content.Length];
	//	response.Content.Read(bytes, 0, bytes.Length);
	//	var txt = Encoding.GetEncoding().GetString(bytes);
	//	Debug.WriteLine(txt);

	//	response.Dispose();
 //   }
}

