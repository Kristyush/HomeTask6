using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int _health = 5;
    [SerializeField] private int _maxHealth = 8;

    private bool _invulnerable = false;

    [SerializeField] private AudioSource _addHealthSound;
    [SerializeField] private HealthUI _healthUI;

    [SerializeField] private UnityEvent _eventOnTakeDamage;

    private void Start()
    {
        _healthUI.Setup(_maxHealth);
        _healthUI.DisplayHealth(_health);
    }
    public void TakeDamage(int damageValue)
    {
        if (_invulnerable == false)
        {
            _health -= damageValue;

            if (_health <= 0)
            {
                _health = 0;
                Die();
            }
            _invulnerable = true;
            Invoke(nameof(StopInvulnerable), 1f);

            _healthUI.DisplayHealth(_health);

            _eventOnTakeDamage.Invoke();
        }
    }

   void StopInvulnerable()
    {
        _invulnerable = false;
    }

    public void AddHealth(int healthValue)
    {
        _health += healthValue;
        if (_health > _maxHealth)
        {
            _health = _maxHealth;
        }
        _addHealthSound.Play();
        _healthUI.DisplayHealth(_health);

    }

    void Die()
    {
        Debug.Log("You Lose");
    }
}
