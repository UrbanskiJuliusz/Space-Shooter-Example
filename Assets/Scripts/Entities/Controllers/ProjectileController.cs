using SpaceShooter.Core;
using SpaceShooter.Entities.Models;
using SpaceShooter.Entities.View;
using SpaceShooter.Weapons.Controllers;
using UnityEngine;

namespace SpaceShooter.Entities.Controllers
{
    public class ProjectileController : MonoBehaviour
    {
        #region Variables

        private ProjectileModel projectileModel;
        private ProjectileView projectileView;

        private WeaponController weaponController;

        #endregion

        #region Unity methods

        private void Update()
        {
            UpdateProjectilePosition();

            if (Mathf.Abs(projectileModel.CurrentPosition.x) > 16f || Mathf.Abs(projectileModel.CurrentPosition.z) > 16f)
            {
                weaponController.ReturnProjectile(this);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer == SpaceShooterLayers.ENEMIES)
            {
                if (other.TryGetComponent<EnemyController>(out var enemyController))
                {
                    enemyController.ShipModel.CurrentHealth -= projectileModel.CurrentDamage;
                }

                weaponController.ReturnProjectile(this);
            }
        }

        #endregion

        #region Public methods

        public void Initialize(ProjectileModel projectileModel, ProjectileView projectileView, WeaponController weaponController)
        {
            this.projectileModel = projectileModel;
            this.projectileView = projectileView;
            this.weaponController = weaponController;
        }

        #endregion

        #region Private methods

        private void UpdateProjectilePosition()
        {
            projectileModel.CurrentPosition += projectileModel.CurrentDirection * projectileModel.CurrentSpeed * Time.deltaTime;

            projectileView.UpdatePosition(projectileModel.CurrentPosition);
        }

        #endregion
    }
}