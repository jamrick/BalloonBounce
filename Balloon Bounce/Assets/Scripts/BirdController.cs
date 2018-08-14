using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour {

    public float minSpeed;
    public float maxSpeed;

    private float speed;
    public Vector3 dir;
	// Use this for initialization
	void Start () {
        speed = Random.Range(minSpeed, maxSpeed);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        this.transform.Translate(dir * (speed * Time.deltaTime));
        if (!EventSystem.GameRunning())
        {
            Destroy(this.gameObject);
        }
	}

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Border")
            Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Destroy(this.gameObject);
            // gameover event happens
            EventSystem.GameOver();
        }
    }
}
