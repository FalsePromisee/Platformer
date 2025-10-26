using System.Collections;
using UnityEngine;

public class PlatformMover : MonoBehaviour
{
    public static float _speed = 1f;
    private float _maxSpeed = 100f;

    private void Start()
    {
        StartCoroutine(IncreaseSpeedPlatform());
    }

    private void Update()
    {
        transform.Translate(Vector2.down * _speed * Time.deltaTime);
    }

    public void IncreasedSpeed()
    {
        _speed += 0.2f;
        if (_speed >= _maxSpeed)
        {
            _speed = _maxSpeed;
        }
    }

    private IEnumerator IncreaseSpeedPlatform()
    {

        while (true)
        {
            IncreasedSpeed();
            yield return new WaitForSeconds(10f);
        }
    }


}
