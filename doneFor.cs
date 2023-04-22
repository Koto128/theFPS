using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doneFor : MonoBehaviour
{
    bool PlayerDeath;

    public ParticleSystem Blast;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerDeath)
        {
            Blast.Play();
            Debug.Log("done for");
            PlayerDeath = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "villan")
        {
            PlayerDeath = true;
        }
    }
}
