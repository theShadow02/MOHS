﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class JetPack : MonoBehaviour {
    CharacterController Charc;
    public Image img;
    public float speed;
	// Use this for initialization
	void Start () {
        Charc = GetComponent<CharacterController>();
	}
	
	void FixedUpdate () {
        if (Input.GetKey(KeyCode.A) && img.fillAmount>0)
        {
            Vector3 velocity = new Vector3(Charc.velocity.x / 100, speed, Charc.velocity.z / 100);
            Charc.Move(velocity);
            img.fillAmount -= 0.01f;
        }
        if (Input.GetKey(KeyCode.T) && img.fillAmount <1)
        {
            img.fillAmount += 0.1f;
        }
    }
}
