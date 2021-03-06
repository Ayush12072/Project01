﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BallController : MonoBehaviour {

    public GameObject extrapunch;
    public GameObject particle;
    [SerializeField]
    private float Speed;
    bool started;
    Rigidbody rb;
    bool gameOver;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Use this for initialization
    void Start () {
        started = false;
        gameOver = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (!started)
        {
            if (Input.GetMouseButtonDown(0))
            {
                rb.velocity = new Vector3(Speed, 0, 0);
                started = true;
                GameManager.instance.StartGame();
            }
        }
        //Debug.DrawRay(transform.position, Vector3.down, Color.red);
        if(!Physics.Raycast(transform.position, Vector3.down, 1f))
        {
            gameOver = true;
            rb.velocity = new Vector3(0, -25f, 0);

            Camera.main.GetComponent<CameraFollow> ().gameOver = true;
            GameManager.instance.GameOver();
        }
        if (Input.GetMouseButtonDown(0) && !gameOver)
        {
            SwitchDirection();
        }
        

    }

    void SwitchDirection()
    {
        if (rb.velocity.z > 0)
        {
            rb.velocity = new Vector3(Speed, 0, 0);
        }
        else if (rb.velocity.x > 0)
        {
            rb.velocity = new Vector3(0, 0, Speed);
        }
    }
    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Diamond")
        {
            PlayExtraPunch();
            GameObject part = Instantiate(particle, col.gameObject.transform.position, Quaternion.identity) as GameObject;
            ScoreManager.instance.score += 5;
            Destroy(col.gameObject);
            Destroy(part, 1f);
        }
    }
    void PlayExtraPunch()
    {
        GameObject punch = (GameObject)Instantiate(extrapunch, transform.position, Quaternion.AngleAxis(45,Vector3.up),transform) as GameObject;
    }

}
