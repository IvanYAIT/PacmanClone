using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private BonusCollector _bonusCollector;
    private HealthCounter _healthCounter;

    void Start()
    {
        
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
        if(collision.gameObject.tag == "Enemy")
        {
            _healthCounter.DecreaseHealth();
        }
    }

    public void Construct(BonusCollector bonusCollector, HealthCounter healthCounter)
    {
        _bonusCollector = bonusCollector;
        _healthCounter = healthCounter;
    }
}
