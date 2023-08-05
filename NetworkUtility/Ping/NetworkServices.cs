using NetworkUtility.DNS;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace NetworkUtility.Ping
{
    public class NetworkServices
    {
        private readonly IDns dns;

        public NetworkServices(IDns dns)
        {
            this.dns = dns;
        }
        public string SendPing() 
        {
            var dnsSucces = dns.SendDNS();

            if (dnsSucces)
                return "Success: ping sent";
            else
                return "Failed: Ping not sent";
        }

        public int PingTimeOut(int a, int b)
        {
            return a + b;
        }

        public PingOptions GetPingOption() 
        {
            return new PingOptions
            {
                DontFragment = true,
                Ttl = 1
            };
        }

        public IEnumerable<PingOptions> GetPingOptions()
        {
            IEnumerable pingOptions = new[]
            {
                new PingOptions
                {
                    DontFragment = true,
                    Ttl = 1
                },
                new PingOptions
                {
                    DontFragment = true,
                    Ttl = 1
                },
            };

            return (IEnumerable<PingOptions>)pingOptions;  
        }
    }
}
