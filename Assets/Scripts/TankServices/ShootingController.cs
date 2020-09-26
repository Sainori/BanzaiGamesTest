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

        private List<TankShell> _freeTankShells = new List<TankShell>();
        private List<TankShell> _activeTankShells = new List<TankShell>();

        public void Shoot()
        {
            if (_freeTankShells.Count == 0)
            {
                _freeTankShells.Add(CreateShell());
            }

            var shell = _freeTankShells.First();

            _freeTankShells.Remove(shell);
            _activeTankShells.Add(shell);

            shell.ShootWithForce(shootForce);
            shell.OnExplosion += OnShellExplosion;
        }

        private void OnShellExplosion(TankShell tankShell)
        {
            _activeTankShells.Remove(tankShell);
            _freeTankShells.Add(tankShell);
            tankShell.Deactivate();
        }

        private TankShell CreateShell()
        {
            var tankShellObject = Instantiate(tankShellPrefab, tankShellPrefab.transform.parent);
            var tankShell = tankShellObject.GetComponent<TankShell>();
            tankShell.Initialize();
            return tankShell;
        }

        public void ChangeWeapon()
        {
            throw new System.NotImplementedException();
        }
    }
}