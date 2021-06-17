using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tkach.Lab1.AbstractFactory_Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            int waitingPassengersAmount = 0;
            Console.WriteLine("How many passengers do you need to board?");
            waitingPassengersAmount = Convert.ToInt32(Console.ReadLine());

            BoardAnyCar randomBoard = new BoardAnyCar();
            int boardnum = 0;
            while (waitingPassengersAmount > 0)
            {
                boardnum++;
                Console.WriteLine("~BOARD-" + boardnum);
                waitingPassengersAmount -= randomBoard.Board(waitingPassengersAmount);
                Console.WriteLine("~people waiting:" + waitingPassengersAmount + "\n");
            }

            Console.ReadLine();
        }
    }
}
