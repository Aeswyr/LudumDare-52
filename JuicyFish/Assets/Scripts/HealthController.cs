using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthController : MonoBehaviour
{
    [SerializeField] float health;
    [SerializeField] float maxHealth;
    [SerializeField] UnityEvent onDeath;
    // Start is called before the first frame update
    public void takeDamage(float damage) {
        health -= damage;
        Debug.Log("HEALTH:" + health);
        if (health <= 0.0f)
        {
            onDeath.Invoke();
        }
    } 

    void dedge(){
        health = maxHealth; 
    }
}
