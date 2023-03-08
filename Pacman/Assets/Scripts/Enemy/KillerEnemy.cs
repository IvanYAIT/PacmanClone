using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class KillerEnemy : MonoBehaviour, IEatable
{
    [SerializeField] private float radius;
    [SerializeField] private float speed;
    [SerializeField] private int deathDelay;

    public bool IsFollowPlayer { get; private set; }
    public bool IsEatan { get; private set; }

    private Transform _player;
    private NavMeshAgent _agent;
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
        _agent = GetComponent<NavMeshAgent>();
        _agent.updateRotation = false;
        _agent.updateUpAxis = false;
        _agent.speed = speed;
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        Player.OnGetDamage += PlayerGetDamage;
    }

    private void Update()
    {
        if(Time.timeScale == 0)
        {
            Player.OnGetDamage -= PlayerGetDamage;
            Player.OnBigBonusCollect -= DeathMode;
        }

        GetComponent<SpriteRenderer>().color = _enemyColor;

        if (!_agent.hasPath && IsEatan)
        {
            _agent.enabled = false;
            StartCoroutine(Death());
        }
        if (!IsEatan)
        {
            if (Vector2.Distance(transform.position, _player.position) > radius)
            {
                _agent.enabled = false;
                IsFollowPlayer = false;
                transform.Translate(new Vector3(0, 1, 0) * speed * Time.deltaTime);
            }
            else
            {
                _agent.enabled = true;
                IsFollowPlayer = true;
                _agent.SetDestination(_player.position);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && _isEatable)
        {
            _agent.enabled = true;
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
