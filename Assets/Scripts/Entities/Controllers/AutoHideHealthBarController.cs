using SpaceShooter.Entities.Models;
using SpaceShooter.Entities.Views;
using UnityEngine;
using UnityEngine.UI;

namespace SpaceShooter.Entities.Controllers
{
    public class AutoHideHealthBarController : MonoBehaviour, IHealthBarController
    {
        #region Variables

        [SerializeField] private Slider healthBarSlider;
        [SerializeField] private float hideHealthBarDelay = 1f;

        private ShipModel shipModel;
        private HealthBarView healthBarView;

        private bool isHealthBarVisible;
        private float healthBarVisibleTime;

        #endregion

        #region Unity methods

        public void Update()
        {
            if (isHealthBarVisible && healthBarView != null)
            {
                healthBarVisibleTime += Time.deltaTime;

                if (healthBarVisibleTime >= hideHealthBarDelay)
                {
                    SetHealthBarVisibility(false);
                }
            }
        }

        private void OnDestroy()
        {
            if (shipModel != null)
            {
                shipModel.OnHealthChanged -= UpdateHealth;
            }
        }

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
                SetHealthBarVisibility(true);

                healthBarVisibleTime = 0f;
            }
        }

        #endregion

        #region Private methods

        private void SetHealthBarVisibility(bool isVisible)
        {
            if (healthBarView != null)
            {
                healthBarView.SetHealthBarVisibility(isVisible);
                isHealthBarVisible = isVisible;
            }
        }

        #endregion
    }
}