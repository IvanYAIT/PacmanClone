using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private BonusCollector _bonusCollector;
    private HealthCounter _healthCounter;
    private LayerMask _enemyLayer;
    private int _enemyLayerMask;
    private bool _isBuffed;
    private int _bigBonusDuration;
    private int _enemyCounter;
    private int _bonusesForEnemy;

    public static Action<int> OnBigBonusCollect;

    void Start()
    {
        _enemyLayerMask = (int)Mathf.Log(_enemyLayer.value, 2); // это -бесконечность
        _enemyCounter = 0;
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bonus"))
        {
            _bonusCollector.AddBonus();
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("BigBonus"))
        {
            _isBuffed = true;
            StartCoroutine(BuffTimer(_bigBonusDuration));
            OnBigBonusCollect?.Invoke(_bigBonusDuration);
            Destroy(collision.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == (int)Mathf.Log(_enemyLayer.value, 2) && !_isBuffed) // а это -3
        {
            _healthCounter.DecreaseHealth();
        } else if (collision.gameObject.layer == (int)Mathf.Log(_enemyLayer.value, 2) && _isBuffed)
        {
            if (!collision.gameObject.GetComponent<IEatable>().IsEatan)
            {
                _enemyCounter++;
                _bonusCollector.AddBonus(_bonusesForEnemy * _enemyCounter);
            }
                
        }
    }

    public void Construct(BonusCollector bonusCollector, HealthCounter healthCounter, LayerMask enemyLayer, int bigBonusDuration, int bonusesForEnemy)
    {
        _bonusCollector = bonusCollector;
        _healthCounter = healthCounter;
        _enemyLayer = enemyLayer;
        _bigBonusDuration = bigBonusDuration;
        _bonusesForEnemy = bonusesForEnemy;
    }

    private IEnumerator BuffTimer(int duration)
    {
        yield return new WaitForSeconds(duration);
        _isBuffed = false;
        _enemyCounter = 0;
    }
}
