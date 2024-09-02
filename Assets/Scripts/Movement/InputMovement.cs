using UnityEngine;

namespace SpaceShooter.Movement
{
    public class InputMovement : IMovement
    {
        public Vector3 CalculateNewPosition(Vector3 currentPosition, float speed)
        {
            Vector3 moveInput = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
            Vector3 newPosition = currentPosition + moveInput * speed * Time.deltaTime;
            newPosition.x = Mathf.Clamp(newPosition.x, -12f, 12f);
            return newPosition;
        }
    }
}