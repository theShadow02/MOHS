﻿using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using System.Collections.Generic;

public class ActivateSwitch : MonoBehaviour {
    private bool moving = false;
    private float displace = 0;
    private bool activated = false;
    public List<Light> lights_to_switch;
    public HorizontalAnim door;

    void Start()
    {
    }

    void Update()
    {
        if (moving)
            Activate();
    }

    void Activate()
    {
        if (displace < 180)
        {
            transform.Rotate(-2, 0, 0);
            displace += 2;
        }
        else
        {
            moving = false;
            activated = true;
            door.Locked = false;
            for (int i = 0; i < lights_to_switch.Count; i++)
                lights_to_switch[i].enabled = true;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (Input.GetKey(KeyCode.E))
            moving = true;
    }
}
