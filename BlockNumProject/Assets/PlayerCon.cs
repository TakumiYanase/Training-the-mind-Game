using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCon : MonoBehaviour {


    GameObject player;
	// Use this for initialization
	void Start () {
        //this.player = GameObject.Find("player");
	}
	
	// Update is called once per frame
	void Update () {

        //if (Input.GetKeyDown(KeyCode.RightArrow)key = 1;
	}
    void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        transform.Translate(x, 0, z);
    }

}
