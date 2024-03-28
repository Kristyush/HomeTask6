using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carrot : MonoBehaviour
{
    [SerializeField] public Rigidbody Rigidbody;
    [SerializeField] public float Speed;
    void Start()
    {
        Transform playerTransform = FindObjectOfType<PlayerMove>().transform;
        Vector3 toPlayer = (playerTransform.position - transform.position).normalized;
        Rigidbody.velocity = toPlayer * Speed;
    }
}
