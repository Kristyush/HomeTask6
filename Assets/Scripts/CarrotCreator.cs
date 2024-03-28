using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarrotCreator : MonoBehaviour
{
    [SerializeField] public GameObject CarrotPrefab;
    [SerializeField] public Transform Spawn;
    public void Create()
    {
        Instantiate(CarrotPrefab, Spawn.position, Quaternion.identity);

    }
}
