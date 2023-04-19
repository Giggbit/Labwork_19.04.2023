using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Labwork_19._04._2023
{
    internal class Program
    {
        public class Bank {
            public int money;
            public string name;
            public int percent;

            public Bank() { }
            public Bank(int money, string name, int percent) {
                this.money = money;
                this.name = name;
                this.percent = percent;
            }

            public void Edit() {
                Thread thr = new Thread(new ThreadStart(MyThread));
                thr.Start();
            }
            public void Print() {
                Console.WriteLine($"name: {name}");
                Console.WriteLine($"money: {money}");
                Console.WriteLine($"percent: {percent}");
            }
        }

        public static void MyThread() {
            Bank bank = new Bank();
            Action act = delegate {
                Console.Write("money: ");
                string m = Console.ReadLine();
                bank.money = Convert.ToInt32(m);
                Console.Write("name: ");
                bank.name = Console.ReadLine();
                Console.Write("perecent: ");
                string p = Console.ReadLine();
                bank.percent = Convert.ToInt32(p);
            };
            Thread.Sleep(1000);
            act.Invoke();
            Console.WriteLine();
            bank.Print();
        }

        static void Main(string[] args) {
            Bank bank = new Bank(0," ", 0);
            bank.Edit();

        }
    }
}
