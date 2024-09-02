using UnityEngine;

namespace SpaceShooter.Movement
{
    public interface IMovement
    {
        Vector3 CalculateNewPosition(Vector3 currentPosition, float speed);
    }
}
