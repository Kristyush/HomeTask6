using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUI : MonoBehaviour
{
    [SerializeField] public GameObject HealthIconPrefab;
    [SerializeField] public List<GameObject> HealthIcons = new List<GameObject>();

    public void Setup(int maxHealth)
    {
        for (int i = 0; i < maxHealth; i++)
        {
            GameObject newIcon = Instantiate(HealthIconPrefab, transform);
            HealthIcons.Add(newIcon);
        }

    }

    public void DisplayHealth(int health)
    {
        for (int i = 0; i < HealthIcons.Count; i++)
        {
            if (i < health)
            {
                HealthIcons[i].SetActive(true);
            } else
            {
                HealthIcons[i].SetActive(false);
            }
        }
    }
}
