using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsController : MonoBehaviour
{
    [SerializeField] float health;
    [SerializeField] float primaryAttack;
    [SerializeField] float specialAttack;
    // Start is called before the first frame update

    public void decrementHP(float damage)
    {
        health -= damage;
    }

    //updating state after reaching zero health
}
