using System.Collections.Generic;

namespace Tkach.Lab7_8.Game.MissionManager
{
    class MissionManager : IObserver
    {
        public List<Mission> missions;

        public MissionManager()
        {
            missions = new List<Mission>();
        }

        public void Update(object obj)
        {
            missions.Remove((Mission)obj);
        }

        public bool AreMissionsPassed()
        {
            if (missions.Count == 0)
                return true;

            return false;
        }
    }
}
