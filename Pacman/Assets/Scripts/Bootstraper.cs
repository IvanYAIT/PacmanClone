using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Bootstraper : MonoBehaviour
{
    [Header("Player Movement")]
    [SerializeField] private InputListener inputListener;
    [SerializeField] private Rigidbody2D playerRb;
    [SerializeField] private float speed;
    [Header("Bonus Collector")]
    [SerializeField] private int maxAmountOfBonuses;
    [SerializeField] private TextMeshProUGUI textOfBonus;
    [Header("Health Counter")]
    [SerializeField] private GameObject[] healthObjects;
    [Header("Other")]
    [SerializeField] private Player player;
    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject losePanel;

    private BonusCollector bonusCollector;
    private HealthCounter healthCounter;
    private Game game;

    void Start()
    {
        game = new Game(losePanel, winPanel);
        bonusCollector = new BonusCollector(textOfBonus, maxAmountOfBonuses);
        healthCounter = new HealthCounter(healthObjects);
        inputListener.Construct(playerRb, speed);
        player.Construct(bonusCollector, healthCounter);
    }

    void Update()
    {
        
    }
}
