using UnityEngine;

namespace SpaceShooter.Movement
{
    public class ConstantForwardMovement : IMovement
    {
        public Vector3 CalculateNewPosition(Vector3 currentPosition, float speed)
        {
            Vector3 moveInput = Vector3.forward;
            Vector3 newPosition = currentPosition - (speed * moveInput * Time.deltaTime);
            return newPosition;
        }
    }
}