using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] public Vector3 RotationSpeed;

    void Update()
    {
        transform.Rotate(RotationSpeed * Time.deltaTime);
    }
}
