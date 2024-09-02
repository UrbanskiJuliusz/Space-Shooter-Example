using SpaceShooter.Entities.Controllers;
using SpaceShooter.Utilities;
using SpaceShooter.Weapons.Strategies;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter.Weapons.Controllers
{
    public class WeaponController : MonoBehaviour
    {
        #region Variables

        [Header("Projectile Settings")]
        [SerializeField] private GameObject projectilePrefab;
        [SerializeField] private Transform projectileSpawnPoint;
        [SerializeField] private float projectileSpeed = 10f;
        [SerializeField] private int projectileDamage = 1;

        [Header("Weapon Settings")]
        [SerializeField] private float fireRate = 0.5f;

        [Header("Pooling Settings")]
        [SerializeField] private int poolSize = 20;
        
        private ObjectPool<ProjectileController> projectilePool;
        private IWeaponStrategy currentShootingStrategy;
        private float nextFireTime = 0f;

        private Dictionary<WeaponType, IWeaponStrategy> shootingStrategies;

        #endregion

        #region Unity methods

        void Awake()
        {
            projectilePool = new ObjectPool<ProjectileController>(projectilePrefab, poolSize);

            shootingStrategies = new Dictionary<WeaponType, IWeaponStrategy>
            {
                { WeaponType.SingleShot, new SingleShotStrategy(this) },
                { WeaponType.SideShot, new SideShotStrategy(this) }
            };

            currentShootingStrategy = shootingStrategies[WeaponType.SingleShot];
        }

        void Update()
        {
            if (Time.time >= nextFireTime)
            {
                currentShootingStrategy.Shoot(projectileSpawnPoint, projectileSpeed, projectileDamage);
                nextFireTime = Time.time + fireRate;
            }

            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                if (shootingStrategies.TryGetValue(WeaponType.SingleShot, out var strategy))
                {
                    currentShootingStrategy = strategy;
                }
                else
                {
                    Debug.LogWarning("SingleShot strategy not found!");
                }
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                if (shootingStrategies.TryGetValue(WeaponType.SideShot, out var strategy))
                {
                    currentShootingStrategy = strategy;
                }
                else
                {
                    Debug.LogWarning("SideShot strategy not found!");
                }
            }
        }

        #endregion

        #region Public methods

        public ProjectileController GetProjectile()
        {
            return projectilePool.GetObject(projectileSpawnPoint.position, projectileSpawnPoint.rotation);
        }

        public void ReturnProjectile(ProjectileController projectile)
        {
            projectilePool.ReturnObject(projectile);
        }

        #endregion

        public enum WeaponType
        {
            SingleShot,
            SideShot
        }
    }
}