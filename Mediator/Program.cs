using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator//Arabulucu desenidir
{//Farklı sistemleri birbiri ile görüştürme görevini üstlenir
    class Program
    {
        static void Main(string[] args)
        {
            Mediator mediator = new Mediator();

            Teacher engin = new Teacher(mediator);
            engin.Name = "Engin";
            mediator.Teacher = engin;

            Student burak = new Student(mediator);
            burak.Name = "Burak";

            Student salih = new Student(mediator);
            salih.Name = "Salih";

            mediator.Students = new List<Student> { burak, salih };

            engin.SendNewImageUrl("slide1.jpg");
            engin.ReciveQuestion("is it true", salih);

            Console.ReadLine();


        }
    }
    abstract class CourseMember
    {
        protected Mediator Mediator;

        public CourseMember(Mediator mediator)
        {
            Mediator = mediator;
        }
    }
    class Teacher : CourseMember
    {
        public string Name { get; set; }

        public Teacher(Mediator mediator) : base(mediator)
        {
        }

        internal void ReciveQuestion(string question, Student student)
        {
            Console.WriteLine("Teacher recieved a question from {0} , {1}", student.Name, question);
        }
        public void SendNewImageUrl(string url)
        {
            Console.WriteLine("Teacher changed slide : {0}", url);
            Mediator.UpdateImage(url);
        }
        public void AnswerQuestion(string answer, Student student)
        {
            Console.WriteLine("Teacher answered question {0} , answer {1}", student.Name, answer);
        }
    }
    class Student : CourseMember
    {
        public Student(Mediator mediator) : base(mediator)
        {
        }

        internal void ReciveImage(string url)
        {
            Console.WriteLine("{1} received image : {0}", url, Name);
        }

        internal void ReciveAnswer(string answer)
        {
            Console.WriteLine("{1} received answer {0}", answer, Name);
        }
        public string Name { get; set; }
    }
    class Mediator
    {
        public Teacher Teacher { get; set; }
        public List<Student> Students { get; set; }
        public void UpdateImage(string url)
        {
            foreach (var student in Students)
            {
                student.ReciveImage(url);
            }
        }
        public void SendQuestion(string question, Student student)
        {
            Teacher.ReciveQuestion(question, student);
        }
        public void SendAnswer(string answer, Student student)
        {
            student.ReciveAnswer(answer);
        }
    }
}
