using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game
{
    private GameObject _losePanle;
    private GameObject _winPanle;

    public Game(GameObject losePanle, GameObject winPanle)
    {
        _losePanle = losePanle;
        _winPanle = winPanle;
        BonusCollector.OnPlayerWin += Win;
        HealthCounter.OnPlayerDeath += Lose;
    }

    private void Lose()
    {
        _losePanle.SetActive(true);
        HealthCounter.OnPlayerDeath -= Lose;
    }

    private void Win()
    {
        _winPanle.SetActive(true);
        BonusCollector.OnPlayerWin -= Win;
    }
}
