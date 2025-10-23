using UnityEngine;

namespace _Core.Scripts.Plyaer
{
    public class PlayerStats : MonoBehaviour
    {
        private int _applesCollected;
        private int _playerHealth = 5;


        public void ApplesCollected()
        {
            _applesCollected++;
            Debug.Log("Apples amount: " + _applesCollected);
        }
        
        public void TakeDamage()
        {
            _playerHealth--;
            Debug.Log(_playerHealth);
            if (_playerHealth <= 0)
            {
                Debug.Log("Player dead");
            }
        }
    }
}
