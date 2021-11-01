using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Health))]

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Health _health;
    [SerializeField] private float _maxDelta;

    private bool _isCoroutineWorking = false;

    private void OnEnable()
    {
        _health.Changed += OnChanged;
    }

    private void OnDisable()
    {
        _health.Changed -= OnChanged;
    }

    private void OnChanged()
    {
        if (_isCoroutineWorking == false)
        {
            var changerJob = StartCoroutine(ChangeSlider());
        }
    }

    private IEnumerator ChangeSlider()
    {
        _isCoroutineWorking = true;

        while (_slider.value != _health.Current)
        {           
            _slider.value = Mathf.MoveTowards(_slider.value, _health.Current / _health.MaxValue, _maxDelta * Time.deltaTime);
            yield return null;
        }

        _isCoroutineWorking = false;
    }
}
