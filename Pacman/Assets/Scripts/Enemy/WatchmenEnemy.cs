using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WatchmenEnemy : MonoBehaviour, IEatable
{
    [SerializeField] private float speed;
    [SerializeField] private GameObject[] points;
    [SerializeField] private int deathDelay;

    public bool IsEatan { get; private set; }

    private NavMeshAgent _agent;
    private int pointCounter;
    private Color _enemyColor;
    private Color _startColor;
    private bool _isEatable;
    private Vector3 _startPosition;

    void Start()
    {
        Player.OnBigBonusCollect += DeathMode;
        _enemyColor = GetComponent<SpriteRenderer>().color;
        _startColor = GetComponent<SpriteRenderer>().color;
        _startPosition = transform.position;
        pointCounter = 0;
        _agent = GetComponent<NavMeshAgent>();
        _agent.updateRotation = false;
        _agent.updateUpAxis = false;
        _agent.speed = speed;
        Player.OnGetDamage += PlayerGetDamage;
    }

    void Update()
    {
        if (Time.timeScale == 0)
        {
            Player.OnGetDamage -= PlayerGetDamage;
            Player.OnBigBonusCollect -= DeathMode;
        }

        GetComponent<SpriteRenderer>().color = _enemyColor;

        if (!_agent.hasPath && IsEatan)
            StartCoroutine(Death());

        if (!IsEatan)
        {
            _agent.SetDestination(points[pointCounter].transform.position);
            if (!_agent.hasPath)
                pointCounter++;

            if (pointCounter == points.Length)
                pointCounter = 0;
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && _isEatable)
        {
            _agent.SetDestination(_startPosition);
            _enemyColor = Color.grey;
            IsEatan = true;
        }
    }

    private void DeathMode(int duration)
    {
        _enemyColor = Color.blue;
        _isEatable = true;
        StartCoroutine(DeathModeTimer(duration));
    }

    private IEnumerator DeathModeTimer(int duration)
    {
        yield return new WaitForSeconds(duration);
        if (!IsEatan)
        {
            _isEatable = false;
            _enemyColor = _startColor;
        }

    }

    private IEnumerator Death()
    {
        yield return new WaitForSeconds(deathDelay);
        IsEatan = false;
        _isEatable = false;
        _enemyColor = _startColor;
        transform.rotation = new Quaternion();
    }

    private void PlayerGetDamage()
    {
        transform.position = _startPosition;
        transform.rotation = new Quaternion();
    }
        
}
