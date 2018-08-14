using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdSpawnControl : MonoBehaviour {

    [SerializeField]
    private GameObject bird;

    private void OnEnable()
    {
        if (this.name == "RightSpawn")
        {
            EventSystem.spawnBirdRight += EventSystem_spawnBirdRight;
        }
        else
        {
            EventSystem.spawnBirdLeft += EventSystem_spawnBirdLeft;
        }

        EventSystem.spawnBird += EventSystem_spawnBird;
    }

    private void OnDisable()
    {
        if (this.name == "RightSpawn")
        {
            EventSystem.spawnBirdRight -= EventSystem_spawnBirdRight;
        }
        else
        {
            EventSystem.spawnBirdLeft -= EventSystem_spawnBirdLeft;
        }

        EventSystem.spawnBird -= EventSystem_spawnBird;
    }

    private void EventSystem_spawnBird()
    {
        if (this.name == "RightSpawn")
        {
            EventSystem_spawnBirdRight();
        }
        else
        { 
            EventSystem_spawnBirdLeft();
        }
    }

    private void EventSystem_spawnBirdLeft()
    {
        // spawn an object
        BoxCollider2D bc = GetComponent<BoxCollider2D>();
        float halfsize = bc.size.y / 2;
        float y = Random.Range(-halfsize, halfsize);
        Vector3 spawnPosition = new Vector3(transform.position.x, y);

        GameObject spawn = Instantiate(bird, spawnPosition, Quaternion.identity);
        spawn.GetComponent<BirdController>().dir.x = 1;
        spawn.GetComponent<SpriteRenderer>().flipX = true;
        Debug.Log("spawnBirdLeft()");
    }

    private void EventSystem_spawnBirdRight()
    {
        // spawn an object
        BoxCollider2D bc = GetComponent<BoxCollider2D>();
        float halfsize = bc.size.y / 2;
        float y = Random.Range(-halfsize, halfsize);
        Vector3 spawnPosition = new Vector3(transform.position.x, y);

        GameObject spawn = Instantiate(bird, spawnPosition, Quaternion.identity);
        Debug.Log("spawnBirdRight()");
    }
}
