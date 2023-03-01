using UnityEngine;
using UnityEngine.AI;

public class OnlookerEnemy : MonoBehaviour
{
    [SerializeField] private float speed;

    private void Update()
    {
        transform.Translate(new Vector3(0, 1, 0) * speed * Time.deltaTime);
    }
}
