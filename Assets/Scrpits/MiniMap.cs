using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class MiniMap : MonoBehaviour
{
    [SerializeField] Transform player;
    PhotonView photonView;

    private void Start()
    {
        photonView = GameObject.FindGameObjectWithTag("Player").GetComponent<PhotonView>();
        //photonView = gameObject.GetComponent<PhotonView>();
        //if (PhotonNetwork.IsConnected && FindObjectOfType<PlayerHealth>().isDead == false)
        //{
        //    player = FindObjectOfType<TankMovement>().transform;
        //}

    }

    private void LateUpdate()
    {
        if (PhotonNetwork.IsConnected && photonView.IsMine)
        {
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<TankMovement>().transform;
            Vector3 newPosition = player.position;
            newPosition.y = transform.position.y;
            gameObject.transform.position = newPosition;
        }

    }
}
