using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EventSystem {
    public delegate void StartGameEvent();
    public static event StartGameEvent startGame;

    public delegate void SpawnBirdEvent();
    public static event SpawnBirdEvent spawnBird;
    public static event SpawnBirdEvent spawnBirdLeft;
    public static event SpawnBirdEvent spawnBirdRight;

    public delegate void GameOverEvent();
    public static event GameOverEvent gameOver;

    public static void GameOver()
    {
        if (gameOver != null)
        {
            gameOver();
        }
    }

    public static void SpawnBirdObstacle()
    {
        if (spawnBird != null)
        {
            spawnBird();
        }
    }
    public static void SpawnBirdObstacleLeft()
    {
        if (spawnBird != null)
        {
            spawnBirdLeft();
        }
    }
    public static void SpawnBirdObstacleRigt()
    {
        if (spawnBird != null)
        {
            spawnBirdRight();
        }
    }

    public static void Start()
    {
        if (startGame != null)
        {
            startGame();
        }
    }

    static bool gameRun = false;
    public static bool GameRunning()
    {
        return gameRun;
    }
    public static void SetGameRunning(bool run)
    {
        gameRun = run;
    }
}
