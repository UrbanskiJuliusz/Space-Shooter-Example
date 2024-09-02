using SpaceShooter.Entities.Models;
using SpaceShooter.Entities.Views;
using SpaceShooter.Movement;
using UnityEngine;

namespace SpaceShooter.Entities.Controllers
{
    public class PlayerController : MonoBehaviour
    {
        #region Variables

        public ShipModel ShipModel { get; private set; }
        private ShipView shipView;

        private IMovement movement;

        #endregion

        #region Unity methods

        private void Update()
        {
            if (movement == null || ShipModel == null || shipView == null)
            {
                Debug.LogWarning("PlayerController is not properly initialized. Update skipped.");
                return;
            }

            Vector3 newPosition = movement.CalculateNewPosition(ShipModel.CurrentPosition, ShipModel.CurrentSpeed);
            UpdatePlayerPosition(newPosition);
        }

        #endregion

        #region Public methods

        public void Initialize(ShipModel shipModel, ShipView shipView, IMovement movement)
        {
            this.ShipModel = shipModel;
            this.shipView = shipView;

            this.movement = movement;

            IHealthBarController healthBarController = GetComponent<IHealthBarController>();
            if (healthBarController != null)
                healthBarController.Initialize(shipModel);
            else
                Debug.LogWarning("IHealthBarController component not found on this GameObject.");
        }

        #endregion

        #region Private methods

        private void UpdatePlayerPosition(Vector3 newPosition)
        {
            ShipModel.CurrentPosition = newPosition;
            shipView.UpdatePosition(ShipModel.CurrentPosition);
        }

        #endregion
    }
}