using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    private int _health;

    void Start()
    {
        _health = 5;
        Debug.Log("health = " + _health);
    }

    public void Hurt(int damage)
    {
        _health -= damage;
        Debug.Log("health = " + _health);
    }
}
