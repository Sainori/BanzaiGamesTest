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

        [SerializeField] private List<TankWeapon> _weapons = new List<TankWeapon>();

        [SerializeField] private string enemyTag = "Enemy";
        private int _weaponIndex = 0;
        private TankWeapon _currentWeapon;

        public void Initialize()
        {
            _currentWeapon = _weapons[0];
            _currentWeapon.Activate();
        }

        public void Shoot()
        {
            if (_freeTankShells.Count == 0)
            {
                _freeTankShells.Add(CreateShell());
            }

            var shell = _freeTankShells.First();

            shell.Initialize(_currentWeapon.damage, enemyTag);
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

        public void ChangeWeapon(WeaponChange weaponChange)
        {
            _currentWeapon.Deactivate();

            if (_weaponIndex == _weapons.Count - 1 && weaponChange == WeaponChange.Next)
            {
                _weaponIndex = 0;
            }
            else if (_weaponIndex == 0 && weaponChange == WeaponChange.Previous)
            {
                _weaponIndex = _weapons.Count - 1;
            }
            else
            {
                _weaponIndex += (int) weaponChange;
            }

            _currentWeapon = _weapons[_weaponIndex];
            _currentWeapon.Activate();
        }
    }
}