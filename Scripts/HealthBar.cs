using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Health))]

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Health _player;

    private bool isCoroutineWorking = false;

    private void OnEnable()
    {
        _player.Changed += OnChanged;
    }

    private void OnDisable()
    {
        _player.Changed -= OnChanged;
    }

    private void OnChanged()
    {
        if (isCoroutineWorking == false)
        {
            var changerJob = StartCoroutine(ChangeSlider());
        }
    }

    private IEnumerator ChangeSlider()
    {
        isCoroutineWorking = true;

        while (_slider.value != _player.Current)
        {
            float maxDelta = 20f;
            _slider.value = Mathf.MoveTowards(_slider.value, _player.Current, maxDelta * Time.deltaTime);
            yield return null;
        }

        isCoroutineWorking = false;
    }
}
