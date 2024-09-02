using SpaceShooter.Entities.Models;

namespace SpaceShooter.Entities.Controllers
{
    public interface IHealthBarController
    {
        void Initialize(ShipModel shipModel);
        void UpdateHealth(int currentHealth);
    }
}