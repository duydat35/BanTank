using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class TankFire : MonoBehaviour
{
    [SerializeField] Rigidbody shell;
    [SerializeField] Rigidbody rocket;
    [SerializeField] Transform fireTransform;
    [SerializeField] float launchForce = 10f;
    [SerializeField] float rocketLaunchForce = 20f;
    [SerializeField] float timeBetweenFire = 0.5f;
    [SerializeField] float timeBetweenFireRocket = 3f;

    bool canFire = true;
    bool canFireRocket = true;
    PhotonView photonView;

    void Start()
    {
        photonView = gameObject.GetComponent<PhotonView>();
    }
    void Update()
    {
        GetKey();
    }
    void GetKey()
    {
        if (Input.GetMouseButton(0) && canFire)
        {
            StartCoroutine(Fire());
        }
        if (Input.GetKeyDown(KeyCode.Space) && canFireRocket)
        {
            StartCoroutine(FireRocket());
        }
    }

    IEnumerator Fire()
    {
        if (photonView.IsMine)
        {
            canFire = false;
            GameObject shellInstance = PhotonNetwork.Instantiate("Shell", fireTransform.position, fireTransform.rotation, 0);
            shellInstance.GetComponent<Rigidbody>().velocity = launchForce * fireTransform.forward;
            yield return new WaitForSeconds(timeBetweenFire);
            canFire = true;
        }
    }

    IEnumerator FireRocket()
    {
        if (photonView.IsMine)
        {
            canFireRocket = false;
            GameObject rocketInstance = PhotonNetwork.Instantiate("Rocket", fireTransform.position, fireTransform.rotation, 0);
            rocketInstance.GetComponent<Rigidbody>().velocity = rocketLaunchForce * fireTransform.forward;
            yield return new WaitForSeconds(timeBetweenFireRocket);
            canFireRocket = true;
        }

    }
}
