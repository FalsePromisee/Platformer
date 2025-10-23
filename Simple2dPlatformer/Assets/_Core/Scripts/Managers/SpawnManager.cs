using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Core.Scripts.Managers
{
    public class SpawnManager : MonoBehaviour
    {
        [SerializeField] private List<GameObject> objectsToAwoid;
        private int maxObjectsToSpawn = 100;
        private int currentAmountOfObjects = 0;
        private int spawnDelay = 2;

        private void Start()
        {
            StartCoroutine(SpawnFallingObjects());
        }
    
    
        private IEnumerator SpawnFallingObjects()
        {
            while(currentAmountOfObjects < maxObjectsToSpawn)
            {            
                yield return new WaitForSeconds(spawnDelay);
                int randomIndexToSpawn = Random.Range(0, objectsToAwoid.Count);
                float spawnRange = 8.5f;
                float spawnHeight = 8f;
                Vector2 randomSpawnPosition = new Vector2(Random.Range(-spawnRange, spawnRange), spawnHeight);

                Instantiate(objectsToAwoid[randomIndexToSpawn], randomSpawnPosition, Quaternion.identity);
                currentAmountOfObjects++;
            }
        
        }

    }
}
