using System.Collections.Generic;
using UnityEngine;

namespace EnemyServices.Interfaces
{
    public interface IEnemyController
    {
        void Initialize(List<Transform> spawnPoints, Transform player);
        void DirectUpdate();
    }
}