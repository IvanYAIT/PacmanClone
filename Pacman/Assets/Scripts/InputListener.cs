using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputListener : MonoBehaviour
{
    private GameObject _player;
    private float _speed;
    private float _axisX;
    private float _axisY;

    void Start()
    {
        
    }

    void Update()
    {
        _axisX = Input.GetAxis("Horizontal");
        _axisY = Input.GetAxis("Vertical");
        if(_axisX == 1)
            _player.transform.position += new Vector3(_axisX * _speed * Time.deltaTime, 0);
        else if(_axisX == -1)
            _player.transform.position += new Vector3(_axisX * _speed * Time.deltaTime, 0);
        else if(_axisY == 1)
            _player.transform.position += new Vector3(0, _axisY * _speed * Time.deltaTime);
        else if(_axisY == -1)
            _player.transform.position += new Vector3(0, _axisY * _speed * Time.deltaTime);
    }

    public void Construct(GameObject player, float speed)
    {
        _player = player;
        _speed = speed;
    }
}
