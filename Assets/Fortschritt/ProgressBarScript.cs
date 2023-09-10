using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressBarScript : MonoBehaviour
{
    // Start is called before the first frame update
    static int maxProgress = 30;
    static int currentCrossProgress = 0;
    static int currentPlayerProgress = 6;
    static float size;
    static float stepSize;
    static Transform cross;
    static Transform player;


    void Start()
    {
        Transform bar = transform.Find("bar");
        cross = transform.Find("cross");
        player = transform.Find("person");
        size = bar.GetComponent<BoxCollider2D>().bounds.size.x;
        stepSize = size / maxProgress;

        cross.Translate( currentCrossProgress * stepSize, 0, 0);
        player.Translate(currentPlayerProgress * stepSize, 0, 0);
    }

    // Update is called once per frame
    private void Update()
    {
       
    }


    public static GameStateManager.gameState updateProgressBar( int crossUpdate, int playerUpdate)
    {
        currentCrossProgress += crossUpdate;
        currentPlayerProgress += playerUpdate;
        
        cross.Translate(crossUpdate * stepSize, 0, 0);
        player.Translate(playerUpdate * stepSize, 0, 0);

        if (currentCrossProgress >= currentPlayerProgress)
            return GameStateManager.gameState.GAMEOVERCAUGHT;
        if (currentPlayerProgress >= maxProgress)
            return GameStateManager.gameState.GAMEOVERESCAPED;
        return GameStateManager.gameState.RUNNING;
    }

    public void Reset()
    {
        cross.Translate(-1 * currentCrossProgress * stepSize, 0, 0);
        player.Translate(-1 * currentPlayerProgress * stepSize, 0, 0);
        currentCrossProgress = 0;
        currentPlayerProgress = 6;

        Start();
    }

}
