using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Bootstraper : MonoBehaviour
{
    [Header("Player Movement")]
    [SerializeField] private InputListener inputListener;
    [SerializeField] private GameObject playerObject;
    [SerializeField] private float speed;
    [Header("Bonus Collector")]
    [SerializeField] private int pointsForOneBonus;
    [SerializeField] private GameObject bonusPool;
    [SerializeField] private TextMeshProUGUI textOfBonus;
    [SerializeField] private AudioSource bonusAudioSource;
    [Header("Health Counter")]
    [SerializeField] private GameObject[] healthObjects;
    [Header("Other")]
    [SerializeField] private Player player;
    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject losePanel;
    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] private int bigBonusDuration;
    [SerializeField] private int bonusesForEnemy;

    private BonusCollector bonusCollector;
    private HealthCounter healthCounter;
    private Game game;

    void Start()
    {
        bonusCollector = new BonusCollector(textOfBonus, bonusPool.transform.childCount, pointsForOneBonus, bonusAudioSource);
        healthCounter = new HealthCounter(healthObjects);
        inputListener.Construct(playerObject, speed);
        player.Construct(bonusCollector, healthCounter, enemyLayer, bigBonusDuration, bonusesForEnemy);
        game = new Game(losePanel, winPanel);
        game.StartGame();
    }

    void Update()
    {
        
    }
}
