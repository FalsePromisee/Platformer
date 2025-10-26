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
        private Queue<GameObject> spawnedObjects;
        private int offsetToSpawn = 1;
        private int maxAmountOfPlatforms = 5;
        GameManager gameManager;

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
                GameObject platform = Instantiate(platformPrefabToSpawn[randomIndex], new Vector2(Random.Range(-6.5f, 6.5f), 9f + offsetToSpawn), Quaternion.identity);
                offsetToSpawn += 2;
                
                spawnedObjects.Enqueue(platform);
                if (spawnedObjects.Count >= maxAmountOfPlatforms)
                {
                    Debug.Log("Max amount of platforms reached");
                    Destroy(spawnedObjects.Peek());
                    spawnedObjects.Dequeue();
                    
                }
                yield return new WaitForSeconds(1f);
            }
        }

    }
}
