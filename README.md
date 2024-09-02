# Space Shooter 3D Example

<p align="justify">
<strong>Space Shooter 3D Example</strong> is a game developed in Unity that demonstrates simple "shoot 'em up" gameplay in a three-dimensional space environment. This project utilizes the MVC (Model-View-Controller) architectural pattern to separate game logic, user interface, and data.
</p>

## Files in the Project

### Models

| File | Description |
|------|-------------|
| [EntityModel](https://github.com/UrbanskiJuliusz/Space-Shooter-Example/blob/main/Assets/Scripts/Entities/Models/EntityModel.cs) | An abstract base class for all entities in the game. Stores common properties such as current speed and position. |
| [ShipModel](https://github.com/UrbanskiJuliusz/Space-Shooter-Example/blob/main/Assets/Scripts/Entities/Models/ShipModel.cs) | A class representing the player's or enemy's ship model. Handles attributes such as health and events related to its changes. |
| [ProjectileModel](https://github.com/UrbanskiJuliusz/Space-Shooter-Example/blob/main/Assets/Scripts/Entities/Models/ProjectileModel.cs) | A class representing the projectile model. Contains properties such as flight direction and inflicted damage. |

### Views

| File | Description |
|------|-------------|
| [ShipView](https://github.com/UrbanskiJuliusz/Space-Shooter-Example/blob/main/Assets/Scripts/Entities/Views/ShipView.cs) | A class responsible for visualizing the ship. Handles the update of the ship's model position in the game world. |
| [ProjectileView](https://github.com/UrbanskiJuliusz/Space-Shooter-Example/blob/main/Assets/Scripts/Entities/Views/ProjectileView.cs) | A class responsible for visualizing projectiles. Handles the update of the projectile's model position in the game world. |
| [HealthBarView](https://github.com/UrbanskiJuliusz/Space-Shooter-Example/blob/main/Assets/Scripts/Entities/Views/HealthBarView.cs) | A class responsible for displaying the health bar of entities. Handles updating the bar's value and its visibility. |

### Controllers

| File | Description |
|------|-------------|
| [PlayerController](https://github.com/UrbanskiJuliusz/Space-Shooter-Example/blob/main/Assets/Scripts/Entities/Controllers/PlayerController.cs) | The player's controller responsible for managing the movement of the player's ship and interacting with the health model. |
| [EnemyController](https://github.com/UrbanskiJuliusz/Space-Shooter-Example/blob/main/Assets/Scripts/Entities/Controllers/EnemyController.cs) | The enemy controller, which manages enemy movement, their health, and collision-related interactions. |
| [ProjectileController](https://github.com/UrbanskiJuliusz/Space-Shooter-Example/blob/main/Assets/Scripts/Entities/Controllers/ProjectileController.cs) | The projectile controller, responsible for projectile movement and handling collisions with enemies. |
| [IHealthBarController](https://github.com/UrbanskiJuliusz/Space-Shooter-Example/blob/main/Assets/Scripts/Entities/Interfaces/IHealthBarController.cs) | An interface defining the basic methods for health bar controllers. |
| [AutoHideHealthBarController](https://github.com/UrbanskiJuliusz/Space-Shooter-Example/blob/main/Assets/Scripts/Entities/Controllers/AutoHideHealthBarController.cs) | A health bar controller that automatically hides the health bar after a certain time when health does not change. |
| [AlwaysVisibleHealthBarController](https://github.com/UrbanskiJuliusz/Space-Shooter-Example/blob/main/Assets/Scripts/Entities/Controllers/AlwaysVisibleHealthBarController.cs) | A health bar controller that always displays the unit's health bar. |

### ScriptableObjects

| File | Description |
|------|-------------|
| [ShipData](https://github.com/UrbanskiJuliusz/Space-Shooter-Example/blob/main/Assets/Scripts/Entities/ScriptableObjects/ShipData.cs) | A scriptable object storing ship data, such as enemy type, health, speed, and prefab model. |
| [ShipListData](https://github.com/UrbanskiJuliusz/Space-Shooter-Example/blob/main/Assets/Scripts/Entities/ScriptableObjects/ShipListData.cs) | A scriptable object containing a list of different ships (ShipData). Supports selecting a random ship and loading ships from a folder. |

### Movement

| File | Description |
|------|-------------|
| [IMovement](https://github.com/UrbanskiJuliusz/Space-Shooter-Example/blob/main/Assets/Scripts/Movement/IMovement.cs) | An interface defining a method to calculate a new object position based on its current position and speed. |
| [InputMovement](https://github.com/UrbanskiJuliusz/Space-Shooter-Example/blob/main/Assets/Scripts/Movement/InputMovement.cs) | A class implementing player-controlled movement, allowing movement along the horizontal axis. |
| [ConstantForwardMovement](https://github.com/UrbanskiJuliusz/Space-Shooter-Example/blob/main/Assets/Scripts/Movement/ConstantForwardMovement.cs) | A class implementing constant forward movement, mainly used by enemies in the game. |

### Utilities

| File | Description |
|------|-------------|
| [ObjectPool<T>](https://github.com/UrbanskiJuliusz/Space-Shooter-Example/blob/main/Assets/Scripts/Utilities/ObjectPool.cs) | A class implementing an object pool, allowing efficient management of the lifecycle of objects such as projectiles and enemies. |

### Weapons

| File | Description |
|------|-------------|
| [IWeaponStrategy](https://github.com/UrbanskiJuliusz/Space-Shooter-Example/blob/main/Assets/Scripts/Weapons/Interfaces/IWeaponStrategy.cs) | An interface defining shooting strategies for different types of weapons in the game. |
| [WeaponController](https://github.com/UrbanskiJuliusz/Space-Shooter-Example/blob/main/Assets/Scripts/Weapons/Controllers/WeaponController.cs) | A controller responsible for managing weapons, selecting shooting strategies, and handling the projectile pool. |
| [SingleShotStrategy](https://github.com/UrbanskiJuliusz/Space-Shooter-Example/blob/main/Assets/Scripts/Weapons/Strategies/SingleShotStrategy.cs) | A strategy for shooting a single projectile. |
| [SideShotStrategy](https://github.com/UrbanskiJuliusz/Space-Shooter-Example/blob/main/Assets/Scripts/Weapons/Strategies/SideShotStrategy.cs) | A strategy for shooting two projectiles spreading to the sides. |

## Preview

https://github.com/user-attachments/assets/1d96543f-1587-4f14-a0df-48cf657831cd



