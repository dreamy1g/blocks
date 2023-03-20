using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;


public class LevelComplete : MonoBehaviourPunCallbacks
{
    PhotonView view;


    private void Start()
    {
        view = GetComponent<PhotonView>();
        PhotonNetwork.AutomaticallySyncScene = true;
    }
    public void LoadNextLevel()
    {

        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        PhotonNetwork.LoadLevel(SceneManager.GetActiveScene().buildIndex + 1);
    }


}
