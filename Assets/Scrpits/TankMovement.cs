using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Photon;
using Photon.Pun;
using UnityStandardAssets.Utility;

public class TankMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10;
    [SerializeField] float turnSpeed = 100;

    private string playerName = "";
    private Rigidbody rb;

    PhotonView photonView;
    Camera cam;


    void Start()
    {
        photonView = gameObject.GetComponent<PhotonView>();
        //playerName = photonView.Owner.NickName;
        //gameObject.name = playerName;
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rb = gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (photonView.IsMine)
        {
            cam.GetComponent<SmoothFollow>().target = gameObject.transform;
            Move();
            Turn();
        }
        //if (FindObjectOfType<GameManager>().count == 1)
        //{
        //    Debug.Log("you win");
        //}

    }


    private void Move()
    {
        float movementInput = Input.GetAxis("Vertical");
        Vector3 movement = transform.forward * movementInput * moveSpeed * Time.deltaTime;
        rb.MovePosition(rb.position + movement);
    }

    private void Turn()
    {
        float rotationInput = Input.GetAxis("Horizontal");
        float turn = rotationInput * turnSpeed * Time.deltaTime;
        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
        rb.MoveRotation(rb.rotation * turnRotation);
    }
}
