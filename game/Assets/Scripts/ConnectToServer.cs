using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ConnectToServer : MonoBehaviourPunCallbacks
{
    public InputField usernameInputy;
    public Text buttonText;

    private void Start()
    {

    }

    public void OnClickConnect()
    {
        if (usernameInputy.text.Length >=1)
        {
            PhotonNetwork.NickName = usernameInputy.text;
            buttonText.text = "Connecting...";
            PhotonNetwork.AutomaticallySyncScene = true;
            PhotonNetwork.ConnectUsingSettings();

        }
    }

    public override void OnConnectedToMaster()
    {
        SceneManager.LoadScene("lobby");
    }
}
