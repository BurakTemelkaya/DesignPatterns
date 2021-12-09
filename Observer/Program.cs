using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer//kendisine abone olan sistemlerin, bir işlem olduğunda devreye girmesini sağlayan tasarım desenidir.
{
    class Program
    {
        static void Main(string[] args)
        {
            var customerObserver = new CustomerObserver();
            var employeeObserver = new EmployeeObserver();

            ProductManager productManager = new ProductManager();
            productManager.Attach(customerObserver);//customerı ekledik
            productManager.Attach(employeeObserver);// employee'ı ekledik

            //productManager.Detach(customerObserver);//customerı çıkardık
            productManager.Detach(employeeObserver);//employee'ı çıkardık

            productManager.UpdatePrice();

            Console.ReadLine();
        }
    }
    class ProductManager
    {
        List<Observer> _observers = new List<Observer>();
        public void UpdatePrice()
        {
            Console.WriteLine("Product price changed");
            Notify();
        }
        public void Attach(Observer observer)//abonelik ekleme
        {
            _observers.Add(observer);
        }
        public void Detach(Observer observer)//abonelikten çıkarma
        {
            _observers.Remove(observer);
        }
        private void Notify()//bilgilendirme 
        {
            foreach (var observer in _observers)
            {
                observer.Update();//observerları çağırma
            }
        }
    }
    abstract class Observer
    {
        public abstract void Update();
    }
    class CustomerObserver : Observer
    {
        public override void Update()
        {
            Console.WriteLine("Message to Customer : Product Price Changed");
        }
    }
    class EmployeeObserver : Observer
    {
        public override void Update()
        {
            Console.WriteLine("Message to Employee : Product Price Changed");
        }
    }
}
