using System;
using UnityEngine;

namespace EnemyServices
{
    public class Enemy : MonoBehaviour
    {
        public Action<Enemy> OnEnemyDestroy = enemy => { };

        private void OnDestroy()
        {
            OnEnemyDestroy(this);
        }
    }

}