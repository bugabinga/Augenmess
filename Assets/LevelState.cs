using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelState : MonoBehaviour
{
    public LineRenderer referenceLine;
    
    public LineRenderer choiceLineA;
    public LineRenderer choiceLineB;
    public LineRenderer choiceLineC;
    
    private bool anAnswerWasGiven = false;
    private bool correctAnswerGiven = false;
    
    private Gradient correct;
    private Gradient incorrect;
    
    // Start is called before the first frame update
    void Start()
    {
        float alpha = 1.0f;
        
        correct = new Gradient();
        correct.SetKeys(
            new GradientColorKey[] { new GradientColorKey(Color.green, 0.0f), new GradientColorKey(Color.green, 1.0f) },
            new GradientAlphaKey[] { new GradientAlphaKey(alpha, 0.0f), new GradientAlphaKey(alpha, 1.0f) }
            );
        
        incorrect = new Gradient();
        incorrect.SetKeys(
            new GradientColorKey[] { new GradientColorKey(Color.red, 0.0f), new GradientColorKey(Color.red, 1.0f) },
            new GradientAlphaKey[] { new GradientAlphaKey(alpha, 0.0f), new GradientAlphaKey(alpha, 1.0f) }
            );
    }

    // Update is called once per frame
    void Update()
    {
        if(anAnswerWasGiven)
        {
            if(correctAnswerGiven)
            {
                print("you won!");
            }
        }
    }
    
   public void buttonAPressed()
    {
        print("A button was pressed");
        anAnswerWasGiven = true;
        correctAnswerGiven = false;
        
        choiceLineA.colorGradient = incorrect;
    }
   
   public void buttonBPressed()
   {
       print("B button was pressed");
       anAnswerWasGiven = true;
       correctAnswerGiven = true;
       
       choiceLineB.colorGradient = correct;
       referenceLine.colorGradient = correct;
   }
   
   public void buttonCPressed()
   {
       print("C button was pressed");
       anAnswerWasGiven = true;
       correctAnswerGiven = false;
       
       choiceLineC.colorGradient = incorrect;
   }
}
