using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    [SerializeField] Transform cam;

    private void Awake()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>().transform;
    }
    private void LateUpdate()
    {
        transform.LookAt(transform.position + cam.forward);
    }
}
