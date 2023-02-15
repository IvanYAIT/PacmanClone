using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class BonusCollector
{
    private int _amountOfBonuses;
    private TextMeshProUGUI _textOfBonus;
    private int _maxAmoutOfBonuses;

    public static Action OnPlayerWin;

    public BonusCollector(TextMeshProUGUI textOfBonus, int maxAmoutOfBonuses)
    {
        _textOfBonus = textOfBonus;
        _maxAmoutOfBonuses = maxAmoutOfBonuses;
    }

    public void AddBonus()
    {
        _amountOfBonuses++;
        _textOfBonus.text = $"{_amountOfBonuses}";
        if (_amountOfBonuses == _maxAmoutOfBonuses)
            OnPlayerWin?.Invoke();
    }
}
