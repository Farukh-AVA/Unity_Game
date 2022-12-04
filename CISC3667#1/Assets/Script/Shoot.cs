using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
//[SerializeField] Rigidbody2D rigid;

	[SerializeField] GameObject arrowPrefab; 
	[SerializeField] Vector3 arrowForce;
	[SerializeField] SoundManager soundManager;
	
	[SerializeField] Transform firePoint;
	 

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    //good for user input
    void Update()
    {

		if(Input.GetKeyDown(KeyCode.LeftControl)){
			ShootArrow(); 
		}	
		
    }

 

	void ShootArrow(){
		soundManager.PlaySound(); 
		GameObject arrow  = Instantiate(arrowPrefab, firePoint.transform.position, firePoint.transform.rotation); 
		
		Destroy(arrow, 2f);
	}
}
