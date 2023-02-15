using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputListener : MonoBehaviour
{
    private Rigidbody2D _playerRb;
    private float _speed;
    private float _axisX;
    private float _axisY;

    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        _axisX = Input.GetAxis("Horizontal");
        _axisY = Input.GetAxis("Vertical");

        if (_axisX == 1)
            _playerRb.position += new Vector2(_axisX * _speed * Time.deltaTime, 0);
        else if (_axisX == -1)
            _playerRb.position += new Vector2(_axisX * _speed * Time.deltaTime, 0);
        else if (_axisY == 1)
            _playerRb.position += new Vector2(0, _axisY * _speed * Time.deltaTime);
        else if (_axisY == -1)
            _playerRb.position += new Vector2(0, _axisY * _speed * Time.deltaTime);
        
    }

    public void Construct(Rigidbody2D playerRb, float speed)
    {
        _playerRb = playerRb;
        _speed = speed;
    }
}
