using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCounter
{
    private int _amountOfHealth = 3;
    private GameObject[] _healthObjects;

    public static Action OnPlayerDeath;

    public HealthCounter(GameObject[] healthObjects)
    {
        _healthObjects = healthObjects;
    }

    public void DecreaseHealth()
    {
        _amountOfHealth--;
        _healthObjects[_amountOfHealth].SetActive(false);
        if (_amountOfHealth <= 0)
            OnPlayerDeath?.Invoke();
    }
}
