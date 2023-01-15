using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBoxHandler : MonoBehaviour
{
    
    [SerializeField] float pAttack;


    private void OnTriggerEnter2D(Collider2D collision)
    {   
        Debug.Log("COLLIDED");
        if (collision.gameObject.TryGetComponent(out HurtBoxHandler hurtbox))
        {
            if(hurtbox.owner.TryGetComponent(out HealthController health))
            {
                health.takeDamage(pAttack);
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log("I am not hurt anymore.");
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log("ow plz stop");
    }
}
