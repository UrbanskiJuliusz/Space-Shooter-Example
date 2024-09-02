using UnityEngine;

namespace SpaceShooter.Entities.Views
{
    public class ShipView
    {
        #region Variables

        private Transform shipTransform;

        #endregion

        #region Constructors

        public ShipView(Transform transform)
        {
            shipTransform = transform;
        }

        #endregion

        #region Public methods

        public void UpdatePosition(Vector3 newPosition)
        {
            shipTransform.position = newPosition;
        }

        #endregion
    }
}