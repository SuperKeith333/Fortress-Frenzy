using System.Collections;
using System.Collections.Generic;
using Photon.VR;
using UnityEngine;
using UnityEngine.UI;

public class UInetworking : MonoBehaviour
{
    private int JoinGameClick = 0;

    public InputField JoinGameTXT;

    public GameObject JoinGameOBJ;
    public GameObject LoadGameBT;
    public GameObject LeaveGameBT;
    public GameObject BackBT;

    void Start()
    {
        PhotonVRManager.Connect();
    }

    private void Update()
    {
        if(JoinGameClick == 2)
        {
            JoinPublicRoom();
        }
    }

    public void BT_JoinGame()
    {
        LoadGameBT.SetActive(false);
        LeaveGameBT.SetActive(false);
        JoinGameOBJ.SetActive(true);
        BackBT.SetActive(true);
        JoinGameClick += 1;
    }

    public void BT_Back()
    {
        LoadGameBT.SetActive(true);
        LeaveGameBT.SetActive(true);
        JoinGameOBJ.SetActive(false);
        BackBT.SetActive(false);
        JoinGameClick = 0;
    }

    public void JoinPublicRoom()
    {
        // This should take you to the payload game with the roomname you created
        PhotonVRManager.JoinPrivateRoom(JoinGameTXT.text);
        PhotonVRManager.SwitchScenes(2);
        Debug.Log("worked!");
    }

    public void JoinPrivateRoom()
    {
        PhotonVRManager.SwitchScenes(1);
    }

    public void BT_LeaveGame()
    {
        Application.Quit();
    }
}
