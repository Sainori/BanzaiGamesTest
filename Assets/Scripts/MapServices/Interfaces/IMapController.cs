using System.Collections.Generic;
using UnityEngine;

namespace MapServices.Interfaces
{
    public interface IMapController
    {
        Transform GetPlayerSpawnPoint(); 
        List<Transform> GetEnemySpawnPoints(); 
        void CreateMap();
        void DeleteMap();
    }
}