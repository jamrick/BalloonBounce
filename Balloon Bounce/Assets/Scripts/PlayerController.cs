using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    [SerializeField]
    float speed;
    [SerializeField]
    float windResistance;

    [SerializeField]
    Transform center;

    [SerializeField]
    GameObject controller;
    GameController gc;

    CircleCollider2D cc;
    Rigidbody2D rb;
	// Use this for initialization
	void Start () {
        //gravity = Vector3.zero;
        //wind = Vector3.zero;
        gc = controller.GetComponent<GameController>();
        cc = GetComponent<CircleCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        rb.simulated = false;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if (EventSystem.GameRunning())
        {

            rb.AddForce(gc.GetWind(), ForceMode2D.Force);

            Vector3 mousePoint = Vector3.zero;
            if (Input.GetButtonDown("Fire1"))
            {
                mousePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }
            else if ((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
            {
                mousePoint = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            }
            mousePoint.z = 0;

            if (mousePoint != Vector3.zero)
            {
                if (cc.bounds.Contains(mousePoint))
                {
                    Vector3 dir = center.position - mousePoint;
                    dir.Normalize();
                    dir.z = 0;

                    rb.velocity = (dir * speed);
                }
            }
        }
        else
        {
            Vector3 mousePoint = Vector3.zero;
            if (Input.GetButtonDown("Fire1"))
            {
                mousePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }
            else if ((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
            {
                mousePoint = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            }
            mousePoint.z = 0;

            if (mousePoint != Vector3.zero)
            {
                if (cc.bounds.Contains(mousePoint))
                {
                    EventSystem.Start();
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Border")
        {
            // gameover event happens
            EventSystem.GameOver();
        }
    }
}
