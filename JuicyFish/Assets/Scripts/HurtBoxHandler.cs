using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtBoxHandler : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(transform.parent.gameObject);
        Debug.Log("I was collided with: HURTBOX LAYER");
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
