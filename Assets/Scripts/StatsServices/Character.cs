using UnityEngine;

namespace StatsServices
{
    public class Character : MonoBehaviour
    {
        [SerializeField] protected int health;
        [SerializeField] protected int damage;
        [SerializeField] [Range(0, 1)] protected float defense;

        public bool IsDead => health <= 0;

        public void TakeDamage(int takenDamage)
        {
            health -= (int) (takenDamage * defense);
        }
    }
}