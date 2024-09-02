using System;
using UnityEngine;

namespace SpaceShooter.Entities.Models
{
    public abstract class EntityModel
    {
        #region Variables

        private float currentSpeed;
        private Vector3 currentPosition;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the current speed of the ship.
        /// </summary>
        public float CurrentSpeed
        {
            get => currentSpeed;
            set
            {
                if (currentSpeed != value)
                {
                    currentSpeed = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the current position of the ship.
        /// </summary>
        public Vector3 CurrentPosition
        {
            get => currentPosition;
            set
            {
                if (currentPosition != value)
                {
                    currentPosition = value;
                }
            }
        }

        #endregion

        #region Constructors

        protected EntityModel(float speed, Vector3 position)
        {
            CurrentSpeed = speed;
            CurrentPosition = position;
        }

        #endregion
    }
}