using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game
{
    private GameObject _losePanle;
    private GameObject _winPanle;
    private AudioSource _musicSourece;

    public Game(GameObject losePanle, GameObject winPanle, AudioSource musicSource)
    {
        _losePanle = losePanle;
        _winPanle = winPanle;
        _musicSourece = musicSource;
        BonusCollector.OnPlayerWin += Win;
        HealthCounter.OnPlayerDeath += Lose;
    }

    public void StartGame()
    {
        Time.timeScale = 1;
    }

    private void Lose()
    {
        _musicSourece.Stop();
        _losePanle.SetActive(true);
        Time.timeScale = 0;
        HealthCounter.OnPlayerDeath -= Lose;
        BonusCollector.OnPlayerWin -= Win;
    }

    private void Win()
    {
        _musicSourece.Stop();
        _winPanle.SetActive(true);
        Time.timeScale = 0;
        BonusCollector.OnPlayerWin -= Win;
        HealthCounter.OnPlayerDeath -= Lose;
    }
}
