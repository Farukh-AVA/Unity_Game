using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PresistentData : MonoBehaviour
{
    public static PresistentData control; 
    [SerializeField] TextMeshProUGUI scoreTextScore; 
    [SerializeField] TextMeshProUGUI  scoreTextHP; 
    [SerializeField] BaloonSize size;

    public static int  HPScore = 100;
    public static int score = 0; 
    private float timer;
    private void Awake(){

        scoreTextScore.text = score.ToString();
        scoreTextHP.text = HPScore.ToString();  
         
        if(control == null){
            control = this;
            DontDestroyOnLoad(gameObject);
        } else if (control != this){
            Destroy(gameObject); 
        }
    }

    public void AddScoreHP(int i){

        HPScore -= i;

        scoreTextHP.text = HPScore.ToString();  

    }

    public void AddScore(){

        timer = size.GetComponent<BaloonSize>().timer; 
            
        if(timer<=5){
            score+=100;
        }else if(timer <= 10 && timer >= 5){
            
            score+=75;
        }else if(timer >= 10 && timer < 15){
            score+=50;
        }else{
            score+=0;  
        }
            scoreTextScore.text = score.ToString(); 
    }

    public int GetScore(){
    
        return score;
    }
}
