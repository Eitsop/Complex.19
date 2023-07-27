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
            return mauiAppBuilder;
        }

        public static MauiAppBuilder RegisterViewModels(this MauiAppBuilder mauiAppBuilder)
        {
            return mauiAppBuilder;
        }

        public static MauiAppBuilder RegisterViews( this MauiAppBuilder mauiAppBuilder) 
        { 
            return mauiAppBuilder; 
        }
    }
}
