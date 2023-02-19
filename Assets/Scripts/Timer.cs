using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] float timeToCompleteQuestion = 30f;
    [SerializeField] float TimeToShowCorrectAnswer = 10f;

    public bool loadNextQuestion;
    public float fillFraction;
    public bool isAnsweringQuestion;
    
    float timerValue;

    void Update()
    {
        UpdateTimer();
    }

    public void CancelTimer()
    {
        timerValue = 0;
    }


    void UpdateTimer()
    {
        timerValue -= Time.deltaTime;
       // timerValue = timerValue - Time.daltaTime;
       
       if(isAnsweringQuestion)
       {
            if(timerValue > 0 )
            {
                fillFraction = timerValue / timeToCompleteQuestion;  
            }
            else
            {
                isAnsweringQuestion = false;
                timerValue = TimeToShowCorrectAnswer;
            }
       }
       else
       {

            if(timerValue > 0 )
            {
                fillFraction = timerValue / TimeToShowCorrectAnswer; 
            }
            else
            {
                isAnsweringQuestion = true;
                timerValue = timeToCompleteQuestion;
                loadNextQuestion = true;
            }
       }

       Debug.Log(isAnsweringQuestion + ": " + timerValue + " = " + fillFraction);
    }
}
