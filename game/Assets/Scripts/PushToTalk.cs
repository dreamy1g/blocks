using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Voice.Unity;
using Photon.Voice.PUN;

public class PushToTalk : MonoBehaviourPun
{
    public KeyCode PushButton = KeyCode.V;
    public Recorder VoiceRecorder;
    private PhotonView view;

    void Start()
    {
        view = photonView;
        VoiceRecorder.TransmitEnabled = false;

    }

    void Update()
    {
        if(Input.GetKeyDown(PushButton))
        {
            if(view.IsMine)
            {
                VoiceRecorder.TransmitEnabled = true;
            }
        }
        else if (Input.GetKeyUp(PushButton))
        {
            if (view.IsMine)
            {
                VoiceRecorder.TransmitEnabled = false;
            }
        }
        
    }

}
