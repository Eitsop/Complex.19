using Complex19.Connectivity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Complex19
{
    internal static class DependencyInjectionExtensions
    {
        public static MauiAppBuilder RegisterAppServices(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddSingleton<INetworkConnectionStateService, NetworkConnectionStateService>();
            mauiAppBuilder.Services.AddSingleton<IGeminiStatusLineParserFactory, GeminiStatusLineParserFactory>();
            mauiAppBuilder.Services.AddSingleton<IGeminiClientFactory, GeminiClientFactory>();

            return mauiAppBuilder;
        }

        public static MauiAppBuilder RegisterViewModels(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddSingleton<MainPageViewModel>();
            return mauiAppBuilder;
        }

        public static MauiAppBuilder RegisterViews( this MauiAppBuilder mauiAppBuilder) 
        {
            mauiAppBuilder.Services.AddSingleton<MainPage>();
            return mauiAppBuilder; 
        }
    }
}
