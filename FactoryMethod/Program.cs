using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            //factory method dizayn ile interface kullanarak kodun bağımlılıklarını azalttık
            CustomerManager customerManager = new CustomerManager(new LoggerFactory());
            customerManager.Save();

            CustomerManager customerManager2 = new CustomerManager(new LoggerFactory2());
            customerManager2.Save();

            Console.ReadLine();
        }
    }
    public class LoggerFactory:ILoggerFactory
    {
        public ILogger CreateLogger()
        {
            //Business to decide factory
            return new EdLogger();
        }

    }
    public class LoggerFactory2 : ILoggerFactory
    {
        public ILogger CreateLogger()
        {
            //Business to decide factory
            return new Log4NetLogger();
        }
    }

    public interface ILoggerFactory
    {
        ILogger CreateLogger();
    }

    public interface ILogger
    {
        void Log();
    }
    public class EdLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged with EdLogger");
        }
    }
    public class Log4NetLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged with LogfNetLogger");
        }
    }
    public class CustomerManager
    {
        ILoggerFactory _loggerFactory;
        public CustomerManager(ILoggerFactory loggerFactory)
        {
            _loggerFactory = loggerFactory;
        }
        public void Save()
        {
            Console.WriteLine("Saved");
            //ILogger logger = new LoggerFactory().CreateLogger(); bağımlı kod
            ILogger logger = _loggerFactory.CreateLogger();
            logger.Log();
        }
    }
}
