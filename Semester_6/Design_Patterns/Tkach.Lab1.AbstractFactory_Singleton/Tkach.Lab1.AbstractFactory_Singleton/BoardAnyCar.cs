using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tkach.Lab1.AbstractFactory_Singleton
{
    class BoardAnyCar
    {
        // возвращает количество размещенных людей
        private BoardAnyCar randomBoard;
        private static Random rnd = new Random();

        public BoardAnyCar()
        {

        }

        public virtual int Board(int passengersAmount)
        {
            int num = rnd.Next(0, 2);
            switch(num)
            {
                case 0:
                    randomBoard = new BoardBus();
                    break;
                case 1:
                    randomBoard = new BoardTaxi();
                    break;
            }

            int boardedPassengers = 0;
            int boardedDrivers = 0;
            boardedDrivers += BoardDriver();
            boardedPassengers += BoardPassengers(passengersAmount);

            if(boardedDrivers == 0)
            {
                Console.WriteLine("Cant departure without driver");
            }

            if (boardedPassengers == 0)
            {
                Console.WriteLine("Cant departure without passengers");
            }

            return boardedPassengers;
        }
        protected virtual int BoardDriver()
        {
            return randomBoard.BoardDriver();
        }
        protected virtual int BoardPassengers(int amount)
        {
            return randomBoard.BoardPassengers(amount);
        }
    }
}
