using SpaceShooter.Entities.Controllers;
using SpaceShooter.Entities.Models;
using SpaceShooter.Entities.ScriptableObjects;
using SpaceShooter.Entities.Views;
using SpaceShooter.Movement;
using UnityEngine;

namespace SpaceShooter.Core
{
    public class GameManager : MonoBehaviour
    {
        #region Variables

        [SerializeField] private GameObject playerPrefab;

        private ISpawner enemySpawner;

        private float enemySpawnInterval = 2f;
        private float timeSinceLastSpawn = 0f;

        #endregion

        #region Unity methods

        private void Awake()
        {
            ShipListData shipListData = Resources.Load<ShipListData>("Ships/AllShips");
            enemySpawner = new EnemySpawner(shipListData);
        }

        private void Start() => StartGame();

        private void Update()
        {
            HandleEnemySpawning();
        }

        #endregion

        #region Public methods

        public void StartGame()
        {
            SpawnPlayer();
        }

        #endregion

        #region Private methods

        private void SpawnPlayer()
        {
            GameObject player = Instantiate(playerPrefab);
            PlayerController playerController = player.GetComponent<PlayerController>();

            ShipModel playerModel = new ShipModel(speed: 10f, position: Vector3.zero, health: 3);
            ShipView playerView = new ShipView(playerController.transform);

            playerController.Initialize(playerModel, playerView, new InputMovement());
        }

        private void HandleEnemySpawning()
        {
            timeSinceLastSpawn += Time.deltaTime;

            if (timeSinceLastSpawn >= enemySpawnInterval)
            {
                SpawnEnemy();
                timeSinceLastSpawn = 0f;
            }
        }

        private void SpawnEnemy()
        {
            enemySpawner.Spawn();
        }

        #endregion
    }
}