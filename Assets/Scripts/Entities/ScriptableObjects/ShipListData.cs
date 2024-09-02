using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace SpaceShooter.Entities.ScriptableObjects
{
    [CreateAssetMenu(fileName = "NewShipListData", menuName = "SpaceShooter/Ship List Data", order = 2)]
    public class ShipListData : ScriptableObject
    {
        public List<ShipData> ships;

        /// <summary>
        /// Returns a random ship from the list.
        /// </summary>
        public ShipData GetRandomShip()
        {
            if (ships == null || ships.Count == 0)
            {
                Debug.LogError("Ship list is empty or not assigned!");
                return null;
            }

            int randomIndex = Random.Range(0, ships.Count);
            return ships[randomIndex];
        }

#if UNITY_EDITOR

        [ContextMenu("Load All Ships From Folder")]
        private void LoadAllShipsFromFolder()
        {
            string path = AssetDatabase.GetAssetPath(this);
            if (string.IsNullOrEmpty(path))
            {
                Debug.LogError("Could not find the path for this ScriptableObject.");
                return;
            }

            string directory = System.IO.Path.GetDirectoryName(path);

            string[] guids = AssetDatabase.FindAssets("t:ShipData", new[] { directory });
            ships = new List<ShipData>();

            foreach (string guid in guids)
            {
                string assetPath = AssetDatabase.GUIDToAssetPath(guid);
                ShipData shipData = AssetDatabase.LoadAssetAtPath<ShipData>(assetPath);
                if (shipData != null)
                {
                    ships.Add(shipData);
                }
            }

            EditorUtility.SetDirty(this);

            Debug.Log($"Loaded {ships.Count} ships from folder: {directory}");
        }

#endif
    }
}