using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class BonusCollector
{
    private int _amountOfPoints;
    private TextMeshProUGUI _textOfBonus;
    private int _maxAmoutOfBonuses;
    private int _pointsForOneBonus;
    private int _collectedBonuses;
    private AudioSource _audioSource;

    public static Action OnPlayerWin;

    public BonusCollector(TextMeshProUGUI textOfBonus, int maxAmoutOfBonuses, int pointsForOneBonus, AudioSource audioSource)
    {
        _textOfBonus = textOfBonus;
        _maxAmoutOfBonuses = maxAmoutOfBonuses;
        _pointsForOneBonus = pointsForOneBonus;
        _audioSource = audioSource;
    }

    public void AddBonus()
    {
        _amountOfPoints += _pointsForOneBonus;
        _collectedBonuses++;
        _textOfBonus.text = $"{_amountOfPoints}";
        _audioSource.Play();
        if (_maxAmoutOfBonuses == _collectedBonuses)
            OnPlayerWin?.Invoke();
    }

    public void AddBonus(int points)
    {
        _amountOfPoints += points;
        _textOfBonus.text = $"{_amountOfPoints}";
    }
}
