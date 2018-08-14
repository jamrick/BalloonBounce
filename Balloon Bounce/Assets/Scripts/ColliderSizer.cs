using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderSizer : MonoBehaviour {

    BoxCollider2D boxCollider;
    public bool x;
    public bool y;

	// Use this for initialization
	void Start () {
        boxCollider = GetComponent<BoxCollider2D>();
        Vector2 size = boxCollider.size;
        if (x)
        {
            size.x = Camera.main.orthographicSize * Camera.main.aspect * 2;
        }
        if (y)
        {
            size.y = Camera.main.orthographicSize * 2;
        }

        boxCollider.size = size;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
