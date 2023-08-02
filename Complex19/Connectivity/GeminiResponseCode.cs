namespace Complex19.Connectivity
{
    public enum GeminiResponseCode
    {
        Input = 10,
        SensitiveInput = 11,

        Success = 20,

        TemporaryRedirect = 30,
        PermentantRedirect = 31,

        TemporaryFailure = 40,
        ServerUnavailable = 41,
        CgiFailure = 42,
        ProxyError = 43,
        SlowDown = 44,

        PermentantFailure = 50,
        NotFound = 51,
        Gone = 52,
        ProxyRequestRefused = 53,
        BadRequest = 59,

        ClientCertificateRequired = 60,
        CertificateNotAuthorised = 61,
        CertificateNotValid = 62,

    }
}
