using SvcResource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;

namespace HostService
{
    class Program
    {
        static void Main(string[] args)
        {
            Binding b = new BasicHttpBinding();
            Uri a = new Uri("http://localhost:8000");
            ServiceHost h = new ServiceHost(typeof(Resource));
            h.AddServiceEndpoint(typeof(ISvcResource), b, a);

            Console.WriteLine("Host is running at {0}", a);
            h.Open();

            Console.ReadLine();
            
            //IChannelFactory<ISvcResource> f = new ChannelFactory<ISvcResource>(b);

            //ISvcResource proxy = f.CreateChannel(a);

            //proxy.SetLastName("kkk");
            //var t = proxy.GetLastName();
            var deb = 1;
        }
    }
}
