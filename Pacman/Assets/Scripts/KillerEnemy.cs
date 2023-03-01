using UnityEngine;
using UnityEngine.AI;

public class KillerEnemy : MonoBehaviour
{
    [SerializeField] private float radius;
    [SerializeField] private float speed;

    public bool IsFollowPlayer { get; private set; }

    private Transform _player;
    private NavMeshAgent _agent;

    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _agent.updateRotation = false;
        _agent.updateUpAxis = false;
        _agent.speed = speed;
        _player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
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
