using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    [SerializeField]
    Transform playerStart;
    [SerializeField]
    GameObject player;
    [SerializeField]
    private Vector3 windDir;
    [SerializeField]
    private int maxWindSpeed;
    [SerializeField]
    private int minWindSpeed;

    private int windSpeed;

    float windTimer;
    float windTimeChange;

    float singleBirdSpawnTimer;
    float singleBirdSpawnTimeChange;
    float doubleBirdSpawnTimer;
    float doubleBirdSpawnTimeChange;
    // Use this for initialization
    private void OnEnable () {
        EventSystem.startGame += EventSystem_startGame;
        EventSystem.gameOver += EventSystem_gameOver;
	}

    private void OnDisable()
    {
        EventSystem.startGame -= EventSystem_startGame;
        EventSystem.gameOver -= EventSystem_gameOver;
    }

    private void EventSystem_gameOver()
    {
        EventSystem.SetGameRunning(false);
        player.transform.position = playerStart.position;
        player.GetComponent<Rigidbody2D>().simulated = false;
        player.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
    }

    private void EventSystem_startGame()
    {
        // start game stuff
        EventSystem.SetGameRunning(true);
        windTimeChange = Random.Range(3.0f, 7.0f);
        windTimer = 0.0f;
        windDir.x = Random.Range(-1.0f, 1.0f);
        windDir.Normalize();
        windSpeed = Random.Range(minWindSpeed, maxWindSpeed);

        singleBirdSpawnTimer = doubleBirdSpawnTimer = 0.0f;
        singleBirdSpawnTimeChange = 7.0f;
        doubleBirdSpawnTimeChange = 25.0f;

        player.GetComponent<Rigidbody2D>().simulated = true;
    }

    // Update is called once per frame
    void Update () {
		if (EventSystem.GameRunning())
        {
            windTimer += Time.deltaTime;
            if (windTimer > windTimeChange)
            {
                windTimeChange = Random.Range(3.0f, 7.0f);
                windTimer = 0.0f;
                windDir.x = Random.Range(-1.0f, 1.0f);


                windSpeed = Random.Range(minWindSpeed, maxWindSpeed);
            }

            singleBirdSpawnTimer += Time.deltaTime;
            if (singleBirdSpawnTimer > singleBirdSpawnTimeChange)
            {
                singleBirdSpawnTimer = 0.0f;
                if (Random.Range(1, 3) == 1)
                    EventSystem.SpawnBirdObstacleLeft();
                else
                    EventSystem.SpawnBirdObstacleRigt();
            }
            doubleBirdSpawnTimer += Time.deltaTime;
            if (doubleBirdSpawnTimer > doubleBirdSpawnTimeChange)
            {
                doubleBirdSpawnTimer = 0.0f;
                EventSystem.SpawnBirdObstacle();
            }
        }
	}

    public Vector3 GetWind()
    {
        return windDir * windSpeed;
    }
}
