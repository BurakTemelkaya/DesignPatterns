using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singelaton
{
    class Program
    {
        static void Main(string[] args)
        {
            var customerManager = CustomerManager.CreateAsSingeleton();
            customerManager.Save();
        }
    }
    class CustomerManager
    {
        private static CustomerManager _customerManager;
        static object _lockObject = new object();
        private CustomerManager()
        {

        }

        public static CustomerManager CreateAsSingeleton()
        {
            //aynı işlemin farklı kullanımı //?? null kontrolü yapar
            //return _customerManager ?? (_customerManager = new CustomerManager());

            lock (_lockObject)//lock kullanımı
            {
                if (_customerManager == null)
                {
                    _customerManager = new CustomerManager();
                }
            }
            return _customerManager;
        }
        public void Save()
        {
            Console.WriteLine("Saved!!");
        }
    }
}
