using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float radius;
    [SerializeField] private float speed;

    private Transform _player;
    private NavMeshAgent _agent;
    private int _rnd;

    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _agent.updateRotation = false;
        _agent.updateUpAxis = false;
        _player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        transform.Translate(new Vector3(0, 1, 0) * speed * Time.deltaTime);
    }


    private void FixedUpdate()
    {
        
        //if (Vector2.Distance(transform.position, _player.position) > radius)
            
        //else
        //    _agent.SetDestination(_player.position);
    }
}
