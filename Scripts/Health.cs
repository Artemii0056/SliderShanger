using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private float _max;
    [SerializeField] private float _min;

    private float _current = 0;

    public float Current => _current;
    public float MaxValue => _max;

    public event UnityAction Changed;

    public void TakeDamage(float damage)
    {
        _current -= damage; 

        if (_current < _min)
        {
            _current = _min;     
        }

        Changed?.Invoke();
    }

    public void TakeHealth(float health)
    {
        _current += health;

        if (_current > _max)
        {
            _current = _max;
        }

        Changed?.Invoke();
    }
}
