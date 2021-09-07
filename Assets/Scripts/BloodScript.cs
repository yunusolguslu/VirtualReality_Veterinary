using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodScript : MonoBehaviour
{
    private ParticleSystem bloodParticle;

    public GameObject infoArea;
    void Start()
    {
        bloodParticle = GetComponentInChildren<ParticleSystem>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "scalp" || collision.gameObject.name == "scissors")
        {
            bloodParticle.Play();
            infoArea.SetActive(true);
        }       
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "scalp" || collision.gameObject.name == "scissors")
        {
            bloodParticle.Stop();
        }
    }
}
