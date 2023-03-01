using System;
using UnityEngine;

public class Turn : MonoBehaviour
{
    [SerializeField] private bool up;
    [SerializeField] private bool down;
    [SerializeField] private bool left;
    [SerializeField] private bool right;

    private bool _isTurned;

    public void TurnEnemy(Transform enemy)
    {
        int rnd = UnityEngine.Random.Range(1,5);
        
        if (up && rnd==1 && enemy.eulerAngles.z != 180)
        {
            enemy.rotation = new Quaternion();
            enemy.Rotate(new Vector3(0, 0, 1), 0f);
            _isTurned = true;
        }
        else if (right && rnd == 2 && enemy.eulerAngles.z != 90)
        {
            enemy.rotation = new Quaternion();
            enemy.Rotate(new Vector3(0, 0, 1), -90);
            _isTurned = true;
        }
        else if (left && rnd == 3 && enemy.eulerAngles.z != 270)
        {
            enemy.rotation = new Quaternion();
            enemy.Rotate(new Vector3(0, 0, 1), 90);
            _isTurned = true;
        }
        else if (down && rnd == 4 && enemy.eulerAngles.z != 0)
        {
            enemy.rotation = new Quaternion();
            enemy.Rotate(new Vector3(0, 0, 1), 180);
            _isTurned = true;
        }
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") && !_isTurned)
        {
            try
            {
                if (!collision.GetComponent<KillerEnemy>().IsFollowPlayer)
                {
                    collision.transform.position = transform.position;
                    TurnEnemy(collision.transform);
                }
            } catch (Exception)
            {
                collision.transform.position = transform.position;
                TurnEnemy(collision.transform);
            }
            
        }
            
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
            _isTurned = false;
    }
}