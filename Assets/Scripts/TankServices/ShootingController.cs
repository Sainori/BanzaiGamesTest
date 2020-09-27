using System.Collections.Generic;
using System.Linq;
using TankServices.Interfaces;
using UnityEngine;

namespace TankServices
{
    public class ShootingController : MonoBehaviour, IShootingController
    {
        [SerializeField] private GameObject tankShellPrefab;
        [SerializeField] private int shootForce = 2000;

        [SerializeField] private List<TankShell> _freeTankShells = new List<TankShell>();
        [SerializeField] private List<TankShell> _activeTankShells = new List<TankShell>();

        public void Shoot()
        {
            if (_freeTankShells.Count == 0)
            {
                _freeTankShells.Add(CreateShell());
            }

            var shell = _freeTankShells.First();

            shell.Initialize(10);
            shell.OnShoot += OnShoot;
            shell.ShootWithForce(shootForce);
            shell.OnExplosion += OnExplosion;
        }

        private void OnShoot(TankShell shell)
        {
            _freeTankShells.Remove(shell);
            _activeTankShells.Add(shell);
        }

        private void OnExplosion(TankShell tankShell)
        {
            _activeTankShells.Remove(tankShell);
            _freeTankShells.Add(tankShell);
            tankShell.Deactivate();
        }

        private TankShell CreateShell()
        {
            var tankShell = Instantiate(tankShellPrefab, tankShellPrefab.transform.parent);
            return tankShell.GetComponent<TankShell>();
        }

        public void ChangeWeapon()
        {
            throw new System.NotImplementedException();
        }
    }
}