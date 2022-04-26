using System.Security.Cryptography.X509Certificates;

namespace multitenant_poc.Middlewares
{
    public class CertificateProvider : ICertificateProvider
    {
        public X509Certificate GetCertificate(string hostname)
        {
            throw new System.NotImplementedException();
        }
    }
}
