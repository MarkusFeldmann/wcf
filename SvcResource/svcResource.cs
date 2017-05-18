using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace SvcResource
{
    [ServiceContract]
    public interface ISvcResource
    {
        [OperationContract]
        void SetName(String n);
        [OperationContract]
        void SetLastName(String ln);
        [OperationContract]
        String GetName();
        [OperationContract]
        String GetLastName();
    }

    public class Resource : ISvcResource
    {
        private String _name;
        private String _lastname;

        public void SetName(String name)
        {
            _name = name;
        }

        public void SetLastName(String lastname)
        {
            _lastname = lastname;
        }
        public string GetName()
        {
                return _name;
        }

        public string GetLastName()
        {
            return _lastname;
        }
    }
}
