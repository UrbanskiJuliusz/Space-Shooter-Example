using UnityEngine;
using UnityEngine.UI;

namespace SpaceShooter.Entities.Views
{
    public class HealthBarView
    {
        #region Variables

        private Slider healthBar;

        #endregion

        #region Constructors

        public HealthBarView(Slider healthBar)
        {
            this.healthBar = healthBar;
        }

        #endregion

        #region Public methods

        public void UpdateHealthBar(float healthPercentage)
        {
            if (healthBar != null)
            {
                healthBar.value = healthPercentage;
            }
        }

        public void SetHealthBarVisibility(bool isVisible)
        {
            if (healthBar != null)
            {
                healthBar.gameObject.SetActive(isVisible);
            }
        }

        #endregion
    }
}