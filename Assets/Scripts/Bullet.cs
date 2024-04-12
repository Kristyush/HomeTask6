using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private GameObject _effectPrefab;
    [SerializeField] private float _bulletSpeed = 10;

    private void Awake()
    {
        gameObject.GetComponent<Rigidbody>().velocity = transform.forward * _bulletSpeed;
    }

    private void Start()
    {
        Destroy(gameObject, 4f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(_effectPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);

    }
}
