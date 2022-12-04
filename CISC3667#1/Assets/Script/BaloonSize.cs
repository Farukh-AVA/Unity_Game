using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BaloonSize : MonoBehaviour
{
    //public float timer1 = 0f; 
     public float timer = 0f;
    [SerializeField] float growTime = 25f;
    [SerializeField] float maxSize = 1.2f;
    [SerializeField] float scale = 0f;
    [SerializeField] bool isMaxSize = false;
    [SerializeField] Scenemanager scenemanager; 
    void Start()
    {
                if (!isMaxSize == false)
        {
            // Execute the coroutine
            StartCoroutine(Grow());
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = Vector3.one * scale; 
        if(scale > maxSize){
        Destroy(this.gameObject);
            
        }
        if(growTime <= timer){
            scenemanager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        
    }


        public IEnumerator Grow()
    {
        // The starting size of the balloons
        Vector2 startScale = transform.localScale;
        // This is the size the ballons will grow to (maxSize 5f)
        Vector2 maxScale = new Vector2(maxSize, maxSize);

        do
        {
            // Growing the object in a certain amount of time
            // Checks how close the timer is to the grow time
            transform.localScale = Vector3.Lerp(startScale, maxScale, timer / growTime);
            // Increming the timer
            timer += Time.deltaTime;
            // Pausing the execution

            yield return null;
        }
        while (timer < growTime);
        // When the scale is equal to the max size change to true
        isMaxSize = true;
        

    }
}
