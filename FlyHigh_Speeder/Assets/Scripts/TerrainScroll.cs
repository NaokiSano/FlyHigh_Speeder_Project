using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainScroll : MonoBehaviour {

    public float speed;
    float size = 500;

    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, speed);

        if (this.transform.position.z + size < -500)
        {
            Debug.Log("out of display");
            this.transform.Translate(0, 0, size * 2);
        }
    }
}
