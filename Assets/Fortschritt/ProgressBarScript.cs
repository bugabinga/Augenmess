using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressBarScript : MonoBehaviour
{
    // Start is called before the first frame update
    int maxProgress = 30;
    int currentCrossProgress = 0;
    int currentPlayerProgress = 6;
    float size;
    float stepSize;
    Transform cross;
    Transform player;


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
        //TODO: REMOVE, das ist nur als Test da drin
        if (Time.frameCount % 200 == 0)
        {
            updateProgressBar(2, 1);
        }
       
    }


    public GameStateManager.gameState updateProgressBar( int crossUpdate, int playerUpdate)
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

}
