using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dependency//bağımlılığı azaltmak için kullanılır.
{
    class Program
    {
        static void Main(string[] args)
        {
            IKernel kernal = new StandardKernel();
            //ninject ile dependency metonu daha iyi kullanabildik.
            kernal.Bind<IProductDal>().To<NhProductDal>().InSingletonScope();
            //kernal.Bind<IProductDal>().To<EfProductDal>().InSingletonScope();
            //ProductManager productManager = new ProductManager(new EfProductDal());
            ProductManager productManager = new ProductManager(kernal.Get<IProductDal>());
            productManager.Save();

            Console.ReadLine();
        }
    }
    interface IProductDal
    {
        void Save();
    }
    class EfProductDal : IProductDal//Dal = data acces layer
    {
        public void Save()
        {
            Console.WriteLine("Saved with Entity Framework");
        }
    }
    class NhProductDal : IProductDal//Dal = data acces layer
    {
        public void Save()
        {
            Console.WriteLine("Saved with Nh");
        }
    }
    class ProductManager
    {
        private IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public void Save()
        {
            //Business Code
            //ProductDal productDal = new ProductDal();//product managerda produc dal'ı newlersek EfProductDal'a bağımlı oluruz nesnel zafiyet oluşur.
            _productDal.Save();
        }
    }
}
