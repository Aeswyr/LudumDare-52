using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 0.1f;
    [SerializeField] private GameObject noiceu;
    private SpriteRenderer sprite = null;
    [SerializeField] private InputHandler input; 
    // Start is called before the first frame update
    void Start()
    {
        sprite = this.GetComponent<SpriteRenderer>();
    }

    // Update is called once per RENDER frame
    void FixedUpdate() //why is this not defaulted
    {
        this.transform.position += new Vector3(speed * input.dir.x, 0, 0);
    }
}
