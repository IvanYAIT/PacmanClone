using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float radius;

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

    private void FixedUpdate()
    {
        if (Vector2.Distance(transform.position, _player.position) > radius)
            transform.Translate(new Vector3(0, 1, 0) * Time.fixedDeltaTime);
        else
            _agent.SetDestination(_player.position);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Turn"))
        {
            Quaternion rotation = transform.rotation;
            if (collision.GetComponent<Turn>().GetRegularTurn())
            {
                rotation.z += 90;
            }
            else
            {
                if (!collision.GetComponent<Turn>().GetThreeSides())
                {
                    _rnd = Random.Range(1, 2);
                    if (_rnd == 1)
                        rotation.z += 90;
                }
                else
                {
                    _rnd = Random.Range(1, 3);
                    if (_rnd == 1)
                        rotation.z += 90;
                    else if (_rnd == 2)
                        rotation.z -= 90;
                }
            }
            
            transform.rotation = rotation;
        }
    }
}
