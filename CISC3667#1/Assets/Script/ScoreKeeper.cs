using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 
public class ScoreKeeper : MonoBehaviour
{
    int score  = 0; 
    [SerializeField] TextMeshProUGUI scoreText; 
    [SerializeField] BaloonSize size;
    [SerializeField] Balloon balloon;
    
    private float timer;
    
 public void AddScore(){

 
   
   timer = size.GetComponent<BaloonSize>().timer; 
   
   print(timer); 
   
   if(timer<=5){
    score+=100;
   }else if(timer <= 10 && timer >= 5){
      //balloon.DestroyBaloon();
      score+=75;
   }else if(timer >= 10 && timer < 15){
      score+=50;
   }else{
      score+=0;
      //balloon.DestroyBaloon();  
   }
    scoreText.text = score.ToString(); 
 }
}
