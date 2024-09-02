using SpaceShooter.Entities.Models;
using SpaceShooter.Entities.Views;
using UnityEngine;
using UnityEngine.UI;

namespace SpaceShooter.Entities.Controllers
{
    public class AlwaysVisibleHealthBarController : MonoBehaviour, IHealthBarController
    {
        #region Variables

        [SerializeField] private Slider healthBarSlider;

        private ShipModel shipModel;
        private HealthBarView healthBarView;

        #endregion

        #region Unity methods

        private void OnDestroy() => shipModel.OnHealthChanged -= UpdateHealth;

        #endregion

        #region Public methods

        public void Initialize(ShipModel shipModel)
        {
            this.shipModel = shipModel;

            healthBarView = new HealthBarView(healthBarSlider);

            shipModel.OnHealthChanged += UpdateHealth;
            UpdateHealth(shipModel.CurrentHealth);
        }

        public void UpdateHealth(int currentHealth)
        {
            if (healthBarView != null)
            {
                float healthPercentage = Mathf.Clamp01((float)currentHealth / shipModel.MaxHealth);
                healthBarView.UpdateHealthBar(healthPercentage);
                healthBarView.SetHealthBarVisibility(true);
            }
        }

        #endregion
    }
}