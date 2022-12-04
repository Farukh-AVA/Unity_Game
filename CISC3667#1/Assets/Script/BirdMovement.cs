using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdMovement : MonoBehaviour
{
    [SerializeField] Vector3 force; 
    [SerializeField] Sprite[] birdsSprites; 
    //[SerializeField] HPScoreScript Score;
    [SerializeField] PresistentData pr;
    [SerializeField] SoundManager soundManager;

    //[SerializeField] ScoreKeeper score;

    private Rigidbody2D rb; 
    private SpriteRenderer spriteRenderer; 
    Vector3 LastVelocity;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
        force = new Vector3(300,0,0); 
        rb.AddForce(force); 
    }

    // Update is called once per frame
    void Update()
    {
        // Finding the last velocity of the balloon
        LastVelocity = rb.velocity;
    }
        public void OnCollisionEnter2D(Collision2D collision)
    {
        // Finding the speed
        var speed = LastVelocity.magnitude;
        // Finding and applying the direction of the balloons
        var direction = Vector3.Reflect(LastVelocity.normalized, collision.contacts[0].normal);
        // The Maximum value is applied
        rb.velocity = direction * Mathf.Max(speed, 0f);


    }
        private void OnTriggerEnter2D(Collider2D collison){
            if(collison.gameObject.tag == "arrow"){ 
                soundManager.PlaySound();
                Destroy(this.gameObject); 
                Destroy(collison.gameObject); 
            } else if(collison.gameObject.tag == "cannon"){
                soundManager.PlaySound();
                //Score.AddScore(10);
                pr.AddScoreHP(10);
                //PresistentData.control.score++;
                //Debug.Log(PresistentData.control.score);  
                //pr.control++; 
                Destroy(this.gameObject);
            }
       
        }
 

}
