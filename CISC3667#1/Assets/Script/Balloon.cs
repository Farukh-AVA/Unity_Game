using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Balloon : MonoBehaviour
{
    [SerializeField] Vector3 force; 
    [SerializeField] Sprite[] balloonSprites; 

    //[SerializeField] ScoreKeeper score;
    [SerializeField] PresistentData pr;
    [SerializeField] Scenemanager scenemanager; 

    //[SerializeField] BaloonSize size;

    private Rigidbody2D rb; 
    private SpriteRenderer spriteRenderer; 
    Vector3 LastVelocity;
    //[SerializeField] BaloonSize size;
     
    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>(); 
        force = new Vector3(Random.Range(-100,100),Random.Range(150,250),0); 
        rb.AddForce(force); 
        //DestroyBaloon(size); 
        
    }

    // Update is called once per frame
    void Update()
    {
        // Finding the last velocity of the balloon
        LastVelocity = rb.velocity;
        //Destroy(this.gameObject,15f);  
    
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

/**
    public void DestroyBaloon(){
            Destroy(this.gameObject);
    }

**/    
    private void OnTriggerEnter2D(Collider2D collison){

        int sceneIndex = SceneManager.GetActiveScene().buildIndex; 
         
        if(collison.gameObject.tag == "arrow"){
            pr.AddScore();
            //PresistentData.control.AddScore(); 
            Destroy(this.gameObject); 
            Destroy(collison.gameObject);
            
            if(sceneIndex == 3){
            scenemanager.LoadScene(0);
            }else{
                scenemanager.LoadScene(sceneIndex + 1);
            }
             
        }
    }
}
