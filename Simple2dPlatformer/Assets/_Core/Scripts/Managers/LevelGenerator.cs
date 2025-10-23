using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

namespace _Core.Scripts.Managers
{
    public class LevelGenerator : MonoBehaviour
    {
        [SerializeField] private List<GameObject> platformPrefab;
        private List<GameObject> spawnedObjects;
        private int offsetToSpawn = 1;
        private int maxAmountOfPlatforms = 15;
        GameManager gameManager;

        private void Start()
        {
            gameManager = GameManager.Instance;
            StartCoroutine(PlatformGenerator());
        }


        private IEnumerator PlatformGenerator()
        {
            while (true)
            {
                int randomIndex = Random.Range(0, platformPrefab.Count);
                GameObject platform = Instantiate(platformPrefab[randomIndex], new Vector2(Random.Range(-6.5f, 6.5f), 9f + offsetToSpawn), Quaternion.identity);
                offsetToSpawn += 2;
                spawnedObjects.Add(platform);
                if (spawnedObjects.Count > maxAmountOfPlatforms)
                {
                    
                }
                yield return new WaitForSeconds(1f);
            }
        }

    }
}
