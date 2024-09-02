using UnityEngine;

namespace SpaceShooter.Entities.View
{
    public class ProjectileView
    {
        #region Variables

        private Transform projectileTransform;

        #endregion

        #region Constructors

        public ProjectileView(Transform projectileTransform)
        {
            this.projectileTransform = projectileTransform;
        }

        #endregion

        #region Public methods

        public void UpdatePosition(Vector3 newPosition)
        {
            projectileTransform.position = newPosition;
        }

        #endregion
    }
}