﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class PlayerSync : NetworkBehaviour {
    [Command]
	public void CmdSync1()
    {
        GameObject[] lights = GameObject.FindGameObjectsWithTag("SyncLight1");
        GameObject door = GameObject.FindGameObjectWithTag("SyncDoor1");
        for (int i = 0; i < lights.Length; i++)
        {
            lights[i].GetComponentInChildren<Light>().enabled = true;
        }
        door.GetComponentInChildren<HorizontalAnim>().locked = false;
    }

    [Command]
    public void CmdChangeScene(string scene)
    {
        GameObject.Find("NetworkManager").GetComponent<NetworkManager>().ServerChangeScene(scene);
    }

    [Command]
    public void CmdSyncRover()
    {
        GameObject rover = GameObject.FindGameObjectWithTag("Rover");

        rover.GetComponentInChildren<Light>().enabled = true;
        rover.GetComponent<RoverDisplace>().battery = true;
    }

    [Command]
    public void CmdSyncRoverPos(float x, float y, float z)
    {
        GameObject rover = GameObject.FindGameObjectWithTag("Rover");
        rover.GetComponent<RoverDisplace>().Translate(x, y, z);
    }

    [Command]
    public void CmdSyncRoverRot(float x, float y, float z)
    {
        GameObject rover = GameObject.FindGameObjectWithTag("Rover");
        rover.GetComponent<RoverDisplace>().Rotate(x, y, z);
    }

    [Command]
    public void CmdSyncDoor2()
    {
        GameObject.FindGameObjectWithTag("SyncDoor2").GetComponentInChildren<HorizontalAnim>().locked = false;
    }

    [Command]
    public void CmdSyncDoorPos(float x, float y, float z, int n)
    {
        string tag = "";
        switch (n)
        {
            case 0:
                tag = "DoorRed";
                break;
            case 1:
                tag = "DoorBlue";
                break;
            case 2:
                tag = "DoorGreen";
                break;
            case 3:
                tag = "DoorYellow";
                break;
        }
        GameObject[] doors = GameObject.FindGameObjectsWithTag(tag);
        doors[0].transform.Translate(-x, -y, -z);
        doors[1].transform.Translate(x, y, z);
    }
}
