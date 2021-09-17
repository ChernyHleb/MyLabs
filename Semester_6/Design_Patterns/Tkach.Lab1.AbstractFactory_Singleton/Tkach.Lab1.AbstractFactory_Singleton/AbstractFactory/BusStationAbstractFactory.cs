namespace Tkach.Lab1.AbstractFactory_Singleton
{
    class BusStationAbstractFactory : IStationAbstractFactory
    {
        public BoardAnyCar BoardAnyCar()
        {
            return new BoardBus();
        }

        public Driver CreateDriver()
        {
            return BusDriver.GetNewDriver();
        }
    }
}
