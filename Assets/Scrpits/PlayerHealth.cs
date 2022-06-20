using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Pun.Demo.PunBasics;


public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float playerHealth = 100;
    [SerializeField] Slider slider;
    [SerializeField] float timeToRevial = 2;

    float currentHealth;
    public bool isDead = false;
    PhotonView photonView;

    void Start()
    {
        setCurrentHealth();
        photonView = gameObject.GetComponent<PhotonView>();
    }

    void Update()
    {
        SetHealthUI();
        //StartCoroutine(Revial());
    }

    public void setCurrentHealth()
    {
        slider.maxValue = playerHealth;
        currentHealth = playerHealth;
    }

    public void TakeDamage(float amout)
    {
        currentHealth -= amout;
        if (currentHealth <= 0)
        {
            Dead();
        }
    }

    void SetHealthUI()
    {
        slider.value = currentHealth;
    }

    void Dead()
    {
        isDead = true;
        GetComponent<TankMovement>().enabled = false;
        GetComponent<TankFire>().enabled = false;
        if(photonView.IsMine)
        {
            PhotonNetwork.Destroy(gameObject);
            PhotonNetwork.LeaveRoom();
        }
    }

}