using Microsoft.Maui.Networking;
using System.Net.NetworkInformation;

namespace Complex19.Connectivity
{
    internal class NetworkConnectionStateService : INetworkConnectionStateService
    {
        public NetworkConnectionStateService() 
        {
            Microsoft.Maui.Networking.Connectivity.ConnectivityChanged += onNetworkConnecttivityChanged;
        }

        private void onNetworkConnecttivityChanged(object sender, ConnectivityChangedEventArgs e)
        {
            ConnectivityChanged?.Invoke(this, e);
        }

        public event EventHandler<ConnectivityChangedEventArgs> ConnectivityChanged;

        public IEnumerable<ConnectionProfile> ConnectionProfiles => Microsoft.Maui.Networking.Connectivity.Current.ConnectionProfiles;

        public NetworkAccess CurrentState => Microsoft.Maui.Networking.Connectivity.Current.NetworkAccess;
    }
}
