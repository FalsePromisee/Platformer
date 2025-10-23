using System;
using _Core.Scripts.Plyaer;
using UnityEngine;

namespace _Core.Scripts.Envoirment.Box
{
    public class Box : MonoBehaviour
    {
        private float _fallingOffset = 10f;
        private void OnTriggerEnter2D(Collider2D collision)
        {
            PlayerStats playerStats = collision.gameObject.GetComponent<PlayerStats>();
            if (playerStats != null && collision.gameObject.CompareTag("Player"))
            {
                playerStats.TakeDamage();
            }
        }

        private void Update()
        {
            if (gameObject.transform.position.y < Camera.main.transform.position.y - _fallingOffset)
            {
                Destroy(gameObject);
            }
        }
    }
}
