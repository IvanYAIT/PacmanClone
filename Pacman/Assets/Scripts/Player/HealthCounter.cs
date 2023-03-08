using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCounter
{
    private int _amountOfHealth = 3;
    private GameObject[] _healthObjects;
    private Animator _animator;
    private AudioSource _deathAudioSource;
    private AudioSource _musicSourece;

    public static Action OnPlayerDeath;

    public HealthCounter(GameObject[] healthObjects, Animator animator, AudioSource deathAudioSource, AudioSource musicSourece)
    {
        _healthObjects = healthObjects;
        _animator = animator;
        _deathAudioSource = deathAudioSource;
        _musicSourece = musicSourece;
    }

    public void DecreaseHealth()
    {
        _animator.SetTrigger("Death");
        _deathAudioSource.Play();
        _amountOfHealth--;
        _healthObjects[_amountOfHealth].SetActive(false);
        //if (_animator.GetCurrentAnimatorStateInfo(0).IsName("Death"))
        //{
        //    Time.timeScale = 0;
            
        //    _musicSourece.Pause();
            
        //} 
        
        
        if (_amountOfHealth <= 0)
            OnPlayerDeath?.Invoke();
    }
}
