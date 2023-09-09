using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager Instance;
    public int test = 0;

    public enum gameState
    {
        GAMEOVERCAUGHT,
        GAMEOVERESCAPED,
        RUNNING,
    }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void increase()
    {
        test++;
        print(test);
    }

}
