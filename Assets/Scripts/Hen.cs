using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hen : MonoBehaviour
{
    [SerializeField] public Rigidbody Rigidbody;
    [SerializeField] private Transform _playerTransform;

    [SerializeField] public float Speed = 3f;
    [SerializeField] public float TimeToReachSpeed = 1f;

    private void Start()
    {
        _playerTransform = FindObjectOfType<PlayerMove>().transform;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 toPlayer = (_playerTransform.position - transform.position).normalized;
        Vector3 force = Rigidbody.mass * (toPlayer * Speed - Rigidbody.velocity) / TimeToReachSpeed;

        Rigidbody.AddForce(force);

    }
}
