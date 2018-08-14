using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleBehavior : MonoBehaviour {
    //[SerializeField]
    //GameObject controller;
    GameController gc;
    public float maxLifeTime;
    float startLife;
    float currentLife;

    private void Start()
    {
        
        //gc = controller.GetComponent<GameController>();
        startLife = Random.Range(1.0f, maxLifeTime);
        currentLife = startLife;
    }

    public void SetGameControl(GameObject control)
    {
        gc = control.GetComponent<GameController>();
    }
    // Update is called once per frame
    void Update () {
        if (currentLife < 0 || !EventSystem.GameRunning())
            Destroy(this.gameObject);

        currentLife -= Time.deltaTime;
        Color c = GetComponent<SpriteRenderer>().color;
        c.a = currentLife / startLife;
        GetComponent<SpriteRenderer>().color = c;

        GetComponent<Rigidbody2D>().AddForce(gc.GetWind());
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Border")
            Destroy(this.gameObject);
    }
}
