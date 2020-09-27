using UnityEngine;

namespace TankServices
{
    public class TankWeapon : MonoBehaviour
    {
        [SerializeField] public int damage;

        public void Activate()
        {
            gameObject.SetActive(true);
        }

        public void Deactivate()
        {
            gameObject.SetActive(false);
        }
    }
}