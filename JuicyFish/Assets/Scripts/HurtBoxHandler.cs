using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtBoxHandler : MonoBehaviour
{   [SerializeField] StatsController player;
    void Start() 
    {
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log("I am not hurt anymore.");
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        EnemyStats enemy = collision.transform.parent.GetComponent<EnemyStats>();
        float damage = enemy.attack ;
        player.decrementHP(damage);
    }
}
