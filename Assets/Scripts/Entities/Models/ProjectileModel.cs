using UnityEngine;

namespace SpaceShooter.Entities.Models
{
    public class ProjectileModel : EntityModel
    {
        #region Variables

        private Vector3 currentDirection;
        private int currentDamage;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the current direction of the projectile.
        /// </summary>
        public Vector3 CurrentDirection
        {
            get => currentDirection;
            set
            {
                if (currentDirection != value)
                {
                    currentDirection = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the current damage of the projectile.
        /// </summary>
        public int CurrentDamage
        {
            get => currentDamage;
            set
            {
                if (currentDamage != value)
                {
                    currentDamage = value;
                }
            }
        }

        #endregion

        #region Constructors

        public ProjectileModel(float speed, Vector3 position, Vector3 direction, int damage) : base(speed, position)
        {
            CurrentDirection = direction;
            CurrentDamage = damage;
        }

        #endregion
    }
}