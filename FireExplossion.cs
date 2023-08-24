using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireExplossion : MonoBehaviour
{
    public float explosionRadius = 10f;
    public float explosionForce = 1000f;
    public GameObject explossionMain;
    public GameObject explossionMain2;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            GameObject firstExplossion = Instantiate(explossionMain) as GameObject;
            firstExplossion.transform.position = transform.position;
        }
    }

}
