using UnityEngine;

namespace SpaceShooter.Entities.ScriptableObjects
{
    [CreateAssetMenu(fileName = "NewShipData", menuName = "SpaceShooter/Ship Data", order = 1)]
    public class ShipData : ScriptableObject
    {
        [Header("General Settings")]
        public EnemyType enemyType;
        public MovementType movementType;
        public int health;
        public float speed;
        public GameObject prefab;
    }

    public enum EnemyType
    {
        Ship1,
        Ship2,
        Ship3
    }

    public enum MovementType
    {
        ConstantForward
    }
}
