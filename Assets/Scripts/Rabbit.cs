using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rabbit : MonoBehaviour
{
    [SerializeField] public float AttackPeriod = 7f;
    [SerializeField] public Animator Animator;
    [SerializeField] private float _timer;


    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;
        if (_timer > AttackPeriod)
        {
            _timer = 0;
            Animator.SetTrigger("Attack");
        }
        
    }
}
