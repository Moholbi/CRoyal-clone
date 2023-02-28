using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UdpKit;
using Photon.Bolt;
using Photon.Bolt.Matchmaking;

public class StartMenu : GlobalEventListener
{
    public static int cameraChoice;
    int openSlots = 2;

    public void StartServer()
    {
        BoltLauncher.StartServer();
        PlayerPrefs.SetInt("CameraChoice", cameraChoice);
        cameraChoice = 1;
        Debug.Log("camera " + cameraChoice);
    }

    public override void BoltStartDone()
    {
        BoltMatchmaking.CreateSession(sessionID: "test", sceneToLoad: "GameScene");
    }

    public void StartClientBlue()
    {
        BoltLauncher.StartClient();
        PlayerPrefs.SetInt("CameraChoice", cameraChoice);
        cameraChoice = 2;
        Debug.Log("camera " + cameraChoice);
        openSlots--;
    }

    public void StartClientRed()
    {
        BoltLauncher.StartClient();
        PlayerPrefs.SetInt("CameraChoice", cameraChoice);
        cameraChoice = 3;
        Debug.Log("camera " + cameraChoice);
        openSlots--;
    }

    public override void SessionListUpdated(Map<Guid, UdpSession> sessionList)
    {
        foreach (var session in sessionList)
        {
            UdpSession photonSession = session.Value as UdpSession;

            if (photonSession.Source == UdpSessionSource.Photon)
            {
                BoltMatchmaking.JoinSession(photonSession);
            }
        }
    }
}