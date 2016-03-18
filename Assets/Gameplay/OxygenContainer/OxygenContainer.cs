﻿using UnityEngine;
using System.Collections;

public class OxygenContainer : MonoBehaviour {
    private JetPack jet;
    public MeshRenderer text_mesh;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        text_mesh.enabled = true;
        jet = other.gameObject.GetComponent<JetPack>();
    }

    void OnTriggerStay(Collider other)
    {
        if (Input.GetKey(KeyCode.E))
        {
            if (jet.img.fillAmount < 1.0f)
                jet.img.fillAmount += 0.01f;
        }
    }

    void OnTriggerExit(Collider other)
    {
        text_mesh.enabled = false;
        jet = null;
    }
}