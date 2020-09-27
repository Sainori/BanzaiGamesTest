namespace TankServices.Interfaces
{
    public interface IShootingController
    {
        void Initialize();
        void Shoot();
        void ChangeWeapon(WeaponChange weaponChange);
    }
}