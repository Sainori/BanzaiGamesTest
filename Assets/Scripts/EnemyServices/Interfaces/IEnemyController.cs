using System.Collections.Generic;
using TankServices.Interfaces;
using UnityEngine;

namespace EnemyServices.Interfaces
{
    public interface IEnemyController
    {
        void Initialize(List<Transform> spawnPoints, ITank tank);
        void DirectUpdate();
    }
}