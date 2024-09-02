using SpaceShooter.Core;
using SpaceShooter.Entities.Models;
using SpaceShooter.Entities.ScriptableObjects;
using SpaceShooter.Entities.Views;
using SpaceShooter.Movement;
using UnityEngine;

namespace SpaceShooter.Entities.Controllers
{
    public class EnemyController : MonoBehaviour
    {
        #region Variables

        public ShipModel ShipModel { get; private set; }
        private ShipView shipView;

        private IMovement movement;

        private EnemyType enemyType;
        private ISpawner spawner;

        #endregion

        #region Unity methods

        private void Update()
        {
            if (movement == null || ShipModel == null || shipView == null)
            {
                Debug.LogWarning("EnemyController is not properly initialized. Update skipped.", this);
                return;
            }

            Vector3 newPosition = movement.CalculateNewPosition(ShipModel.CurrentPosition, ShipModel.CurrentSpeed);
            UpdateEnemyPosition(newPosition);
        }

        private void OnDestroy()
        {
            if (ShipModel != null)
            {
                ShipModel.OnHealthChanged -= HandleHealthChanged;
            }
        }

        #endregion

        #region Public methods

        public void Initialize(ShipModel shipModel, ShipView shipView, EnemyType enemyType, ISpawner spawner, IMovement movement)
        {
            this.ShipModel = shipModel;
            this.shipView = shipView;

            this.movement = movement;

            this.enemyType = enemyType;
            this.spawner = spawner;

            shipModel.OnHealthChanged += HandleHealthChanged;

            IHealthBarController healthBarController = GetComponent<IHealthBarController>();
            healthBarController.Initialize(shipModel);
        }

        #endregion

        #region Private methods

        private void UpdateEnemyPosition(Vector3 newPosition)
        {
            ShipModel.CurrentPosition = newPosition;
            shipView.UpdatePosition(ShipModel.CurrentPosition);
        }

        private void HandleHealthChanged(int currentHealth)
        {
            if (currentHealth <= 0)
            {
                DestroyShip();
            }
        }

        private void DestroyShip()
        {
            if (spawner is EnemySpawner enemySpawner)
            {
                enemySpawner.ReturnEnemy(enemyType, this);
            }
        }

        #endregion
    }
}