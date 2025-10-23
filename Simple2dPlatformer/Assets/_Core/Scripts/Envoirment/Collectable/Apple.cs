using _Core.Scripts.Plyaer;
using UnityEngine;

namespace _Core.Scripts.Envoirment.Collectable
{
    public class Apple : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            PlayerStats playerStats = other.GetComponent<PlayerStats>();
            if (other.GetComponent<PlayerStats>() != null)
            {
                playerStats.ApplesCollected();
                Destroy(gameObject);
            }
        }
    }
}
