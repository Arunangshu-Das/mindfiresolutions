using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncAwait
{
    abstract class Cloud
    {
        public enum Level
        {
            low,
            medium,
            high,
        }
        public string compute = null;
        public string Compute
        {
            get;
            set;
        }
        public virtual string Getname()
        {
            return "hello from cloud";
        }

        public virtual void Getlevel()
        {
            Console.WriteLine(Level.medium);
        }

        public abstract string GetSpeed();
    }

    class Aws : Cloud
    {
        public string Compute { set; get; }
        public override string Getname()
        {
            return "hello from AWS";
        }

        public override string GetSpeed()
        {
            return "99% uptime";
        }
        public override void Getlevel()
        {
            Console.WriteLine(Level.high);
        }
    }

    class Gcloud : Cloud
    {
        public string welcome = "hello";
        public string Compute { set; get; }
        public override string Getname()
        {
            return "hello from gcloud";
        }

        public override string GetSpeed()
        {
            return "95% uptime";
        }
        public override void Getlevel()
        {
            Console.WriteLine(Level.medium);
        }
    }

    internal class Hello
    {
        static void Run(string[] args)
        {
            Cloud cloud = new Aws();
            cloud.Compute = "EC2";
            Console.WriteLine(cloud.Compute);
            Console.WriteLine(cloud.Getname());
            Console.WriteLine(cloud.GetSpeed());
            cloud.Getlevel();
            cloud = new Gcloud();
            cloud.Compute = "NanoCloud";
            Console.WriteLine(cloud.Compute);
            Console.WriteLine(cloud.Getname());
            Console.WriteLine(cloud.GetSpeed());
            cloud.Getlevel();
            Console.ReadLine();
        }
    }
}
