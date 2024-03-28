using UnityEngine;

public class Head : MonoBehaviour
{
    [SerializeField] public Transform Target;
    void Update()
    {
        transform.position = Target.position;
    }
}
