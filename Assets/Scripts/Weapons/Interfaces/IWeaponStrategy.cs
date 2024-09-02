using UnityEngine;

namespace SpaceShooter.Weapons.Strategies
{
    public interface IWeaponStrategy
    {
        void Shoot(Transform projectileSpawnPoint, float projectileSpeed, int projectileDamage);
    }
}