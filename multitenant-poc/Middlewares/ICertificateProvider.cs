using System.Security.Cryptography.X509Certificates;

namespace multitenant_poc.Middlewares
{
    public interface ICertificateProvider
    {
        X509Certificate GetCertificate(string hostname);
    }
}
