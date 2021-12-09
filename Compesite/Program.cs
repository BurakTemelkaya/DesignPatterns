using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compesite
{
    class Program//Hiyerarşik desen
    {
        static void Main(string[] args)
        {
            Employee engin = new Employee { Name = "Engin Demiroğ" };
            Employee salih = new Employee { Name = "Salih Demiroğ" };

            engin.AddSubordinate(salih);

            Employee derin = new Employee { Name = "Derin Demiroğ" };
            engin.AddSubordinate(derin);

            Contractor ali = new Contractor { Name = "Ali" };
            derin.AddSubordinate(ali);

            Employee Ahmet = new Employee { Name = "Ahmet" };
            salih.AddSubordinate(Ahmet);

            Console.WriteLine(engin.Name);

            foreach (Employee manager in engin)
            {
                Console.WriteLine(" {0}", manager.Name);
                foreach (IPerson employee in manager)
                {
                    Console.WriteLine("  {0}", employee.Name);
                }
            }
            Console.ReadLine();
        }
    }
    interface IPerson
    {
        string Name { get; set; }
    }
    class Contractor : IPerson
    {
        public string Name { get; set; }
    }
    class Employee : IPerson, IEnumerable<IPerson>
    {
        List<IPerson> _subordinates = new List<IPerson>();

        public void AddSubordinate(IPerson person)
        {
            _subordinates.Add(person);
        }
        public void RemoveSubordinate(IPerson person)
        {
            _subordinates.Remove(person);
        }
        public IPerson GetSubordinate(int index)
        {
            return _subordinates[index];
        }
        public string Name { get; set; }

        public IEnumerator<IPerson> GetEnumerator()
        {
            foreach (var subordinates in _subordinates)
            {
                yield return subordinates;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
