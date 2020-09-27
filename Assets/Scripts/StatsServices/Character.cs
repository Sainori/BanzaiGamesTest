using UnityEngine;

namespace StatsServices
{
    public class Character : MonoBehaviour
    {
        [SerializeField] private int health;
        [SerializeField] private int damage;
        [SerializeField] [Range(0, 1)] private float defense;

        public bool IsDead => health <= 0;

        public void GetDamage(int takenDamage)
        {
            health -= (int) (takenDamage * defense);
        }
    }
}