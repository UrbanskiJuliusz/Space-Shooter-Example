using System;
using UnityEngine;

namespace SpaceShooter.Entities.Models
{
    public class ShipModel : EntityModel
    {
        #region Variables

        private int currentHealth;
        private readonly int maxHealth;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the current health of the ship. 
        /// Triggers the OnHealthChanged event when the health value is changed.
        /// </summary>
        public int CurrentHealth
        {
            get => currentHealth;
            set
            {
                if (currentHealth != value)
                {
                    currentHealth = value;
                    OnHealthChanged?.Invoke(currentHealth);
                }
            }
        }

        /// <summary>
        /// Gets the maximum health of the ship, which is set in the constructor and cannot be modified.
        /// </summary>
        public int MaxHealth => maxHealth;

        #endregion

        #region Constructors

        public ShipModel(float speed, Vector3 position, int health) : base(speed, position) 
        {
            maxHealth = health;
            CurrentHealth = health;
        }

        #endregion

        #region Events

        /// <summary>
        /// Event triggered when the health of the ship changes.
        /// </summary>
        public event Action<int> OnHealthChanged;

        #endregion
    }
}