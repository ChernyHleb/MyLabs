using System;
using System.Collections.Generic;
using static System.Console;

namespace Tkach.Lab7_8.Game
{
    class InputHandler : IObservable
    {
        List<IObserver> observers;
        ConsoleKey lastKeyPressed;

        public InputHandler()
        {
            observers = new List<IObserver>();
        }

        public void HandleInput()
        {
            do // wait until last key pressed
            {
                ConsoleKeyInfo keyInfo = ReadKey(true);
                lastKeyPressed = keyInfo.Key;
            } while (Console.KeyAvailable);

            NotifyObservers();
        }

        public void NotifyObservers()
        {
            foreach(IObserver observer in observers)
            {
                observer.Update(lastKeyPressed);
            }
        }

        public void RegisterObserver(IObserver observer)
        {
            observers.Add(observer);
        }

        public void RemoveObserver(IObserver observer)
        {
            observers.Remove(observer);
        }
    }
}
