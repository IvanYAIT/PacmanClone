using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private BonusCollector _bonusCollector;
    private HealthCounter _healthCounter;
    private LayerMask _enemyLayer;
    private int _enemyLayerMask;

    void Start()
    {
        _enemyLayerMask = (int)Mathf.Log(_enemyLayer.value, 2);
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
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == _enemyLayerMask)
        {
            _healthCounter.DecreaseHealth();
        }
    }

    public void Construct(BonusCollector bonusCollector, HealthCounter healthCounter, LayerMask enemyLayer)
    {
        _bonusCollector = bonusCollector;
        _healthCounter = healthCounter;
        _enemyLayer = enemyLayer;
    }
}
