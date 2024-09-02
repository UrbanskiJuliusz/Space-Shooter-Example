using UnityEngine;
using SpaceShooter.Entities.ScriptableObjects;
using SpaceShooter.Entities.Controllers;
using SpaceShooter.Entities.Models;
using SpaceShooter.Entities.Views;
using SpaceShooter.Utilities;
using System.Collections.Generic;
using SpaceShooter.Movement;

namespace SpaceShooter.Core
{
    public class EnemySpawner : ISpawner
    {
        #region Variables

        private ShipListData shipListData;

        private int poolSize = 5;
        private Dictionary<EnemyType, ObjectPool<EnemyController>> enemyPools;

        #endregion

        #region Constructors

        public EnemySpawner(ShipListData shipListData)
        {
            this.shipListData = shipListData;

            enemyPools = new Dictionary<EnemyType, ObjectPool<EnemyController>>();

            foreach (var shipData in shipListData.ships)
            {
                if (shipData.prefab != null)
                {
                    ObjectPool<EnemyController> pool = new ObjectPool<EnemyController>(shipData.prefab, poolSize);
                    enemyPools.Add(shipData.enemyType, pool);
                }
            }
        }

        #endregion

        #region Public methods

        public void Spawn()
        {
            ShipData randomShipData = shipListData.GetRandomShip();
            if (randomShipData == null || !enemyPools.ContainsKey(randomShipData.enemyType))
            {
                Debug.LogError("Failed to spawn enemy: random ship data is null or not found in pools.");
                return;
            }

            Vector3 spawnPosition = new Vector3(Random.Range(-10f, 10f), 0f, 17f);
            Quaternion rotation = Quaternion.Euler(0, 180f, 0);

            EnemyController enemyController = GetEnemy(randomShipData.enemyType, spawnPosition, rotation);
            if (enemyController != null)
            {
                ShipModel shipModel = new ShipModel(randomShipData.speed, spawnPosition, randomShipData.health);
                ShipView shipView = new ShipView(enemyController.transform);

                switch (randomShipData.movementType)
                {
                    case MovementType.ConstantForward:
                        enemyController.Initialize(shipModel, shipView, randomShipData.enemyType, this, new ConstantForwardMovement());
                        break;
                    default:
                        enemyController.Initialize(shipModel, shipView, randomShipData.enemyType, this, new ConstantForwardMovement());
                        break;
                }
            }
            else
            {
                Debug.LogError("Enemy instance does not have an EnemyController component.");
            }
        }

        public EnemyController GetEnemy(EnemyType enemyType, Vector3 position, Quaternion rotation)
        {
            if (!enemyPools.ContainsKey(enemyType))
            {
                Debug.LogError("Enemy pool not found for the given prefab.");
                return null;
            }

            ObjectPool<EnemyController> selectedPool = enemyPools[enemyType];
            EnemyController enemyController = selectedPool.GetObject(position, rotation);
            return enemyController;
        }

        public void ReturnEnemy(EnemyType enemyType, EnemyController enemyController)
        {
            ObjectPool<EnemyController> selectedPool = enemyPools[enemyType];
            selectedPool.ReturnObject(enemyController);
        }

        #endregion
    }
}