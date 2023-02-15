using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bootstraper : MonoBehaviour
{
    [SerializeField] private InputListener inputListener;
    [SerializeField] private GameObject player;
    [SerializeField] private float speed;

    void Start()
    {
        inputListener.Construct(player, speed);
    }

    void Update()
    {
        
    }
}
