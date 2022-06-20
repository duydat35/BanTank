using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Realtime;
using Photon.Pun;
using Photon.Pun.Demo.PunBasics;

public class GameManager : MonoBehaviourPunCallbacks
{
    [SerializeField] GameObject gameWin;


    private GameObject player1;
    private GameObject player2;


    void Start()
    {
        if (!PhotonNetwork.IsConnected)
        {
            SceneManager.LoadScene("JoinGame");
            return;
        }

        if (PlayerManager.LocalPlayerInstance == null)
        {
            if (PhotonNetwork.IsMasterClient)
            {
                player1 = PhotonNetwork.Instantiate("Tank",
                    new Vector3(Random.Range(-40.0f, 40.0f), 0, Random.Range(-40.0f, 40.0f)),
                    Quaternion.identity,
                    0);

            }
            else
            {
                player2 = PhotonNetwork.Instantiate("Tank",
                    new Vector3(Random.Range(-40.0f, 40.0f), 0, Random.Range(-40.0f, 40.0f)),
                    Quaternion.identity,
                    0);
            }
        }

    }

    void Update()
    {
        //if(PhotonNetwork.CountOfPlayers>0)
        //{
        //    Debug.Log(PhotonNetwork.CurrentRoom.PlayerCount);
        //}
        //if (PhotonNetwork.CountOfPlayers==1)
        //{
        //    WinGame();
        //}
    }

    public void PlayAgain()
    {
        //photonView = GameObject.FindGameObjectWithTag("Player").GetComponent<PhotonView>();
        //if (photonView.IsMine)
        //{
        //    SceneManager.LoadScene("JoinGame");
        //}
        PhotonNetwork.LoadLevel("JoinGame");
        //FindObjectOfType<Launcher>().Start();
    }

    public void WinGame()
    {
        gameWin.SetActive(true);
    }

    //public override void OnPlayerLeftRoom(Player other)
    //{
    //    if (PhotonNetwork.IsMasterClient)
    //    {
    //        PhotonNetwork.LoadLevel("JoinGame");
    //    }
    //}
}
