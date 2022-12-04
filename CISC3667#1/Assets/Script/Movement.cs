using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Movement : MonoBehaviour
{
	[SerializeField] Rigidbody2D rigid;
	[SerializeField] float movement;
	[SerializeField] int speed = 8;
	[SerializeField] bool isFacingRight = true;
	[SerializeField] bool jumpPressed = false;
	[SerializeField] float jumpForce = 10000.0f;
	[SerializeField] bool isGrounded = true;
	 

	public Animator animator; 
	//[SerializeField] GameObject arrowPrefab; 
	//[SerializeField] Vector3 arrowForce;
	//[SerializeField] SoundManager soundManager;

	//[SerializeField] Transform firePoint;


    // Start is called before the first frame update
    void Start()
    {
		if (rigid == null)
			rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    //good for user input
    void Update()
    {
		
		movement = Input.GetAxis("Horizontal") * speed;
		animator.SetFloat("Speed", Mathf.Abs( movement));
        if (Input.GetButtonDown("Jump"))
			jumpPressed = true;
/*
		if(Input.GetButtonDown("Fire1")){
			Shoot(); 
		}	
*/		
    }

    //called potentially multiple times per frame
    //use for physics/movement
    void FixedUpdate()
	{
		rigid.velocity = new Vector2(movement, rigid.velocity.y);
		if ((movement < 0 && isFacingRight) || (movement > 0 && !isFacingRight))
			Flip();
		if (jumpPressed && isGrounded){
			Jump();
		}else{
			animator.SetBool("IsJumping", false);
		}	
			
		
	}

    void Flip()
	{
		transform.Rotate(0, 180, 0);
		isFacingRight = !isFacingRight; 
	}

    void Jump()
	{
		animator.SetBool("IsJumping", true);
		rigid.velocity = new Vector2(rigid.velocity.x, 0);
		rigid.AddForce(new Vector2(0, jumpForce)); 
		jumpPressed = false;
		isGrounded = false;
		
	}

    void OnCollisionEnter2D (Collision2D collision)
	{
		if (collision.gameObject.tag == "Ground"){
			isGrounded = true;
		}else if(collision.gameObject.tag == "ButtomWall"){

			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}	
	}
/**
	void Shoot(){
		soundManager.PlaySound(); 
		GameObject arrow  = Instantiate(arrowPrefab, firePoint.transform.position, firePoint.transform.rotation); 
		arrow.GetComponent<Rigidbody2D>().AddRelativeForce(arrowForce); 
		Destroy(arrow, 2f);
	}
	**/ 
}

