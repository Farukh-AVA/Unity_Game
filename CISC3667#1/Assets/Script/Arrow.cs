using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    
    [SerializeField] float arrowSpeed = 3f;

   
    Rigidbody2D rb;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // Find the current local position and apply force
        Vector2 force = transform.right * arrowSpeed;
        rb.AddForce(force, ForceMode2D.Impulse);


    }
    // Update is called once per frame

 void Update()
    {
        
    }

    //Destroy the bullet on collision
    private void OnCollisionEnter2D(Collision2D collision)
        
    {
        Destroy(gameObject); 
    }

}
