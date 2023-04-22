using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trident : MonoBehaviour
{
    public ParticleSystem Thud;
    private bool fire;
    [SerializeField] Transform player;
    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            fire = true;
        }
        if (fire)
        {
            Thud.Play();
        }
    }
}
