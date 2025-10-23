using UnityEngine;

public class PlatfromMover : MonoBehaviour
{
    [SerializeField] private float _speed = 1f;
    [SerializeField] private float _maxSpeed = 3f;

    private void Update()
    {
        transform.Translate(Vector2.down * _speed * Time.deltaTime);
    }
}
