namespace Complex19.Connectivity
{
    internal interface INetworkConnectionStateService
    {
        event EventHandler<ConnectivityChangedEventArgs> ConnectivityChanged;

        NetworkAccess CurrentState { get; }

        IEnumerable<ConnectionProfile> ConnectionProfiles { get; }
    }
}
