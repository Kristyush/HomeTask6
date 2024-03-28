using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] public int Health = 5;
    [SerializeField] public int MaxHealth = 8;

    [SerializeField] private bool _invulnerable = false;

    //public AudioSource TakeDamageSound;
    [SerializeField] public AudioSource AddHealthSound;
    [SerializeField] public HealthUI HealthUI;

    //public DamageScreen DamageScreen;
    //public Blink Blink;

    [SerializeField] public UnityEvent EventOnTakeDamage;

    private void Start()
    {
        HealthUI.Setup(MaxHealth);
        HealthUI.DisplayHealth(Health);
    }
    public void TakeDamage(int damageValue)
    {
        if (_invulnerable == false)
        {
            Health -= damageValue;

            if (Health <= 0)
            {
                Health = 0;
                Die();
            }
            _invulnerable = true;
            Invoke("StopInvulnerable", 1f);
            //TakeDamageSound.Play();
            HealthUI.DisplayHealth(Health);
            //DamageScreen.StartEffect();
            //Blink.StartBlink();

            EventOnTakeDamage.Invoke();
        }
    }

   void StopInvulnerable()
    {
        _invulnerable = false;
    }

    public void AddHealth(int healthValue)
    {
        Health += healthValue;
        if (Health > MaxHealth)
        {
            Health = MaxHealth;
        }
        AddHealthSound.Play();
        HealthUI.DisplayHealth(Health);

    }

    void Die()
    {
        Debug.Log("You Lose");
    }
}
