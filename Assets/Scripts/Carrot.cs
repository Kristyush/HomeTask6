
using UnityEngine;

public class Carrot : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _speed;
    void Start()
    {
        Transform playerTransform = FindAnyObjectByType<PlayerMove>().transform;
        Vector3 toPlayer = (playerTransform.position - transform.position).normalized;
        _rigidbody.velocity = toPlayer * _speed;
    }
}
