using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSpawnController : MonoBehaviour {

    [SerializeField]
    GameObject particle;
    [SerializeField]
    int particleMax;
    [SerializeField]
    GameObject control;
    //GameController gc;

    float spawnTimer;

    List<GameObject> particleList;

	// Use this for initialization
	void Start () {
        //gc = control.GetComponent<GameController>();
        particleList = new List<GameObject>();
        spawnTimer = 0.0f;
	}

    // Update is called once per frame
    void Update () {
        // if the spawner is paused, spawn particles up to max each frame;
        if (EventSystem.GameRunning())
        {
            spawnTimer += Time.deltaTime;
            if (spawnTimer > .1f)
            {
                spawnTimer = 0.0f;
                if (particleList.Count < particleMax)
                {
                    // spawn an object
                    BoxCollider2D bc = GetComponent<BoxCollider2D>();
                    float halfsize = bc.size.x / 2;
                    float x = Random.Range(-halfsize, halfsize);
                    Vector3 spawnPosition = new Vector3(x, transform.position.y);

                    GameObject px = Instantiate(particle, spawnPosition, Quaternion.identity);
                    px.GetComponent<ParticleBehavior>().SetGameControl(control);
                    particleList.Add(px);
                }
            }

            //check to remove particles from list
            for (int i = 0; i < particleList.Count; ++i)
            {
                if (particleList[i] == null)
                {
                    particleList.RemoveAt(i--);
                }
            }
        }
        else
        {
            for (int i = 0; i < particleList.Count; ++i)
            {
                particleList.RemoveAt(i--);
            }
        }
	}
}
