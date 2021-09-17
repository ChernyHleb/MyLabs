namespace Tkach.Lab1.AbstractFactory_Singleton
{
    abstract class BoardAnyCar
    {
        public abstract int Board(int passengersAmount, Driver driver);
        public abstract int BoardDriver(Driver driver);
        public abstract int BoardPassengers(int amount);
    }
}
