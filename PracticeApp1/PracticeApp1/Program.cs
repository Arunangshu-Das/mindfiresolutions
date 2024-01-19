using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace PracticeApp1
{
    abstract class cloud
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
        public virtual string getname()
        {
            return "hello from cloud";
        }

        public virtual void getlevel()
        {
            Console.WriteLine(Level.medium);
        }

        public abstract string getSpeed();
    }

    class aws: cloud
    {
        public string compute;
        public string Compute
        {
            set;
            get;
        }
        public override string getname()
        {
            return "hello from AWS";
        }

        public override string getSpeed()
        {
            return "99% uptime";
        }
        public override void getlevel()
        {
            Console.WriteLine(Level.high);
        }
    }

    class gcloud : cloud
    {
        public string compute;
        public string Compute
        {
            set;
            get;
        }
        public override string getname()
        {
            return "hello from gcloud";
        }

        public override string getSpeed()
        {
            return "95% uptime";
        }
        public override void getlevel()
        {
            Console.WriteLine(Level.medium);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            cloud cloud = new aws();
            cloud.Compute = "EC2";
            Console.WriteLine(cloud.Compute);
            Console.WriteLine(cloud.getname());
            Console.WriteLine(cloud.getSpeed());
            cloud.getlevel();
            cloud=new gcloud();
            cloud.Compute = "NanoCloud";
            Console.WriteLine(cloud.Compute);
            Console.WriteLine(cloud.getname());
            Console.WriteLine(cloud.getSpeed());
            cloud.getlevel();
            Console.ReadLine();
        }
    }
}
