using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField]
    private TMP_Text TimeText;

    void Update()
    {
        try
        {
            string ActualTime = GameObject.Find("Payload").GetComponent<PayloadScript>().ActualTime;
            TimeText.text = "Time: " + ActualTime;
        }
        catch
        {
            TimeText.text = "Not In Game";
        }
    }
}
