using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Bootstraper : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] private InputListener inputListener;
    [SerializeField] private GameObject playerObject;
    [SerializeField] private float speed;
    [SerializeField] private Player player;
    [SerializeField] private Animator playerAnimator;
    [SerializeField] private AudioSource deathAudioSource;
    [Header("Bonus")]
    [SerializeField] private int pointsForOneBonus;
    [SerializeField] private GameObject bonusPool;
    [SerializeField] private TextMeshProUGUI textOfBonus;
    [SerializeField] private AudioSource bonusAudioSource;
    [SerializeField] private int bigBonusDuration;
    [SerializeField] private int bonusesForEnemy;
    [Header("Health Counter")]
    [SerializeField] private GameObject[] healthObjects;
    [Header("Other")]
    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject losePanel;
    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] private AudioSource musicSource;

    private BonusCollector bonusCollector;
    private HealthCounter healthCounter;
    private Game game;

    void Start()
    {
        bonusCollector = new BonusCollector(textOfBonus, bonusPool.transform.childCount, pointsForOneBonus, bonusAudioSource);
        healthCounter = new HealthCounter(healthObjects, playerAnimator, deathAudioSource, musicSource);
        inputListener.Construct(playerObject, speed);
        player.Construct(bonusCollector, healthCounter, enemyLayer, bigBonusDuration, bonusesForEnemy);
        game = new Game(losePanel, winPanel, musicSource);
        game.StartGame();
    }

    void Update()
    {
        
    }
}
