using SvcResource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;

namespace svcClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Binding b = new BasicHttpBinding();
            EndpointAddress a = new EndpointAddress("http://localhost:8000");


            IChannelFactory<ISvcResource> f = new ChannelFactory<ISvcResource>(b);

            ISvcResource proxy = f.CreateChannel(a);

            proxy.SetLastName("kkk");
            var t = proxy.GetLastName();

            Console.WriteLine("LastName = {0}", t);
            Console.ReadLine();

            
        }
    }
}
