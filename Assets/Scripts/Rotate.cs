using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] public Vector3 _rotationSpeed;

    void Update()
    {
        transform.Rotate(_rotationSpeed * Time.deltaTime);
    }
}
