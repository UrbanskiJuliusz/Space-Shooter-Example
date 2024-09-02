using UnityEngine;
using SpaceShooter.Entities.Controllers;
using SpaceShooter.Entities.Models;
using SpaceShooter.Entities.View;
using SpaceShooter.Weapons.Controllers;

namespace SpaceShooter.Weapons.Strategies
{
    public class SingleShotStrategy : IWeaponStrategy
    {
        private WeaponController weaponController;

        public SingleShotStrategy(WeaponController weaponController)
        {
            this.weaponController = weaponController;
        }

        public void Shoot(Transform projectileSpawnPoint, float projectileSpeed, int projectileDamage)
        {
            ProjectileController projectileController = weaponController.GetProjectile();

            var model = new ProjectileModel(projectileSpeed, projectileSpawnPoint.position, projectileSpawnPoint.forward, projectileDamage);
            var view = new ProjectileView(projectileController.transform);
            projectileController.Initialize(model, view, weaponController);
        }
    }
}
