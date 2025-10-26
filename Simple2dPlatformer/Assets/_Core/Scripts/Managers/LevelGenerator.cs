using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Core.Scripts.Managers
{
    public class LevelGenerator : MonoBehaviour
    {
        [SerializeField] private List<GameObject> platformPrefabToSpawn;
        [SerializeField] private GameObject startedPlatform;
        [SerializeField] private Transform platformKeeper;
        private GameManager gameManager;
        private Queue<GameObject> spawnedObjects;
        

        private float offsetToSpawn = 1;
        private float borderRange = 6f;
        private int maxAmountOfPlatforms = 50; 

        private void Start()
        {
            gameManager = GameManager.Instance;
            spawnedObjects = new Queue<GameObject>();
            spawnedObjects.Enqueue(startedPlatform);
            
            StartCoroutine(PlatformGenerator());
        }


        private IEnumerator PlatformGenerator()
        {
            while (true)
            {
                int randomIndex = Random.Range(0, platformPrefabToSpawn.Count);
                GameObject platform = Instantiate(platformPrefabToSpawn[randomIndex], new Vector2(Random.Range(-borderRange, borderRange), 7f + offsetToSpawn), Quaternion.identity, platformKeeper);
                offsetToSpawn += 1.8f;

                spawnedObjects.Enqueue(platform);
                if (spawnedObjects.Count >= maxAmountOfPlatforms)
                {
                    Destroy(spawnedObjects.Peek());
                    spawnedObjects.Dequeue();
                    
                }
                yield return new WaitForSeconds(1f);
            }
        }

        
    }
}
