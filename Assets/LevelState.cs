using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelState : MonoBehaviour
{
    public LineRenderer referenceLine;
    
    public LineRenderer choiceLineA;
    public LineRenderer choiceLineB;
    public LineRenderer choiceLineC;
    public GameObject gameOver;
    public Camera camera1;
    
    private bool anAnswerWasGiven = false;
    private bool correctAnswerGiven = false;
    
    private Gradient correct;
    private Gradient incorrect;
    GameStateManager.gameState gameStatus = GameStateManager.gameState.RUNNING;


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

        gameOver.SetActive(false);

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
        if(gameStatus == GameStateManager.gameState.GAMEOVERCAUGHT)
        {
            Time.timeScale = 0f;
            gameOver.SetActive(true);
            print("GameOver");
        }
    }
    
   public void buttonAPressed()
    {
        print("A button was pressed");
        anAnswerWasGiven = true;
        correctAnswerGiven = false;
        gameStatus = ProgressBarScript.updateProgressBar(1, 0);
        camera1.GetComponent<ShakyCam>().TriggerShake();
        choiceLineA.colorGradient = incorrect;
    }
   
   public void buttonBPressed()
   {
       print("B button was pressed");
       anAnswerWasGiven = true;
       correctAnswerGiven = true;
        gameStatus = ProgressBarScript.updateProgressBar(0, 1);
        choiceLineB.colorGradient = correct;
       referenceLine.colorGradient = correct;
   }
   
   public void buttonCPressed()
   {
       print("C button was pressed");
       anAnswerWasGiven = true;
       correctAnswerGiven = false;
        gameStatus = ProgressBarScript.updateProgressBar(1, 0);
        camera1.GetComponent<ShakyCam>().TriggerShake();

        choiceLineC.colorGradient = incorrect;
   }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void Reload()
    {
        string name1 = SceneManager.GetActiveScene().name;
        SceneManager.UnloadSceneAsync(name1);
        SceneManager.LoadScene(name1);
    }
}
