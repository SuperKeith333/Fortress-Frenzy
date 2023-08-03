using System.Collections;
using System.Collections.Generic;
using Photon.VR;
using UnityEngine;

public class UInetworking : MonoBehaviour
{
    private int JoinGameClick = 0;

    private string RoomCode;

    public GameObject LoadGameBT;
    public GameObject JoinGameTXT;
    public GameObject LeaveGameBT;
    public GameObject BackBT;

    void Start()
    {

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
        JoinGameTXT.SetActive(true);
        BackBT.SetActive(true);
        JoinGameClick += 1;
    }

    public void BT_Back()
    {
        LoadGameBT.SetActive(true);
        LeaveGameBT.SetActive(true);
        JoinGameTXT.SetActive(false);
        BackBT.SetActive(false);
        JoinGameClick = 0;
    }

    public void GetRoomCode(string code)
    {
        RoomCode = code;
        Debug.Log(code);
    }


    public void JoinPublicRoom()
    {
        // This should take you to the payload game with the roomname you created
        PhotonVRManager.JoinPrivateRoom(RoomCode);
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
