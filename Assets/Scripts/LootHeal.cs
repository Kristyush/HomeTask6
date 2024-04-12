using UnityEngine;

public class LootHeal : MonoBehaviour
{
    [SerializeField] private int _healthValue = 1;

    private void OnTriggerEnter(Collider other)
    {
        PlayerHealth playerHealth = other.GetComponentInParent<PlayerHealth>();
        if (playerHealth)
        {
            playerHealth.AddHealth(_healthValue);
            Destroy(gameObject);
        }
    }
}
