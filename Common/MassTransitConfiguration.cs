using MassTransit.RabbitMqTransport;
using System;
using System.Net.Security;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;

namespace Common
{
    public class MassTransitConfiguration : RabbitMqHostSettings
    {
        public string Host { get; } 

        public int Port { get; }

        public string VirtualHost { get; }

        public string Username { get; }

        public string Password { get; }

        public TimeSpan Heartbeat { get; }

        public bool Ssl { get; }

        public SslProtocols SslProtocol { get; }

        public string SslServerName { get; }

        public SslPolicyErrors AcceptablePolicyErrors { get; }

        public string ClientCertificatePath { get; }

        public string ClientCertificatePassphrase { get; }

        public X509Certificate ClientCertificate { get; }

        public bool UseClientCertificateAsAuthenticationIdentity { get; }

        public LocalCertificateSelectionCallback CertificateSelectionCallback { get; set; }

        public RemoteCertificateValidationCallback CertificateValidationCallback { get; set; }

        public IRabbitMqEndpointResolver EndpointResolver { get; }

        public string ClientProvidedName { get; }

        public Uri HostAddress { get; }

        public bool PublisherConfirmation { get; }

        public ushort RequestedChannelMax { get; }

        public TimeSpan RequestedConnectionTimeout { get; }

        public BatchSettings BatchSettings { get; }
    }
}
