﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBonusPunch : MonoBehaviour {

    public float DestroyTime = 3f;
    public Vector3 offset = new Vector3(0, 2, 0);
	// Use this for initialization
	void Start () {
        Destroy(gameObject, DestroyTime);

        transform.localPosition += offset;
       
	}
	
}
