using SpaceShooter.Entities.Controllers;
using SpaceShooter.Entities.Models;
using SpaceShooter.Entities.View;
using SpaceShooter.Weapons.Controllers;
using UnityEngine;

namespace SpaceShooter.Weapons.Strategies
{
    public class SideShotStrategy : IWeaponStrategy
    {
        private WeaponController weaponController;

        public SideShotStrategy(WeaponController weaponController)
        {
            this.weaponController = weaponController;
        }

        public void Shoot(Transform projectileSpawnPoint, float projectileSpeed, int projectileDamage)
        {
            ProjectileController leftController = weaponController.GetProjectile();
            leftController.transform.Rotate(0, -45, 0);

            var leftModel = new ProjectileModel(projectileSpeed, leftController.transform.position, leftController.transform.forward, projectileDamage);
            var leftView = new ProjectileView(leftController.transform);
            leftController.Initialize(leftModel, leftView, weaponController);

            ProjectileController rightController = weaponController.GetProjectile();
            rightController.transform.Rotate(0, 45, 0);

            var rightModel = new ProjectileModel(projectileSpeed, rightController.transform.position, rightController.transform.forward, projectileDamage);
            var rightView = new ProjectileView(rightController.transform);
            rightController.Initialize(rightModel, rightView, weaponController);
        }
    }
}