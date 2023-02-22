using UnityEngine;

public class Turn : MonoBehaviour
{
    [SerializeField] private bool regularTurn;
    [SerializeField] private bool threeSides;

    public bool GetThreeSides() => threeSides;
    public bool GetRegularTurn() => regularTurn;
}