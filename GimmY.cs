using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GimmY : MonoBehaviour
{
    public Transform player;
    public float speed;
    public int ammo;
    public GameObject blob;
    public float retreatLim;
    public GameObject blobSpot;
    public Transform retreatPos;
    public float Distant; 
 
    
    private void Start()
    { 
        StartCoroutine("bubbles");
    }
    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player);
        Destroy(GameObject.Find("Bubbles Variant(Clone)"), 4f);
        Distant = Vector3.Distance(transform.position, player.position);
        if (ammo > 0 && Distant >= 6)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        if (ammo == 0)
        {
            StopCoroutine("bubbles");
            transform.position = new Vector3(0,4,0);
            // new script, endless spawn
            endlessSpawn();
        }

    }

    IEnumerator bubbles()
    {
        for (int i = ammo; i >= 0; ammo--)
        {
            Instantiate(blob, blobSpot.transform.position, transform.rotation);
            FindObjectOfType<projectile>().StartCoroutine("bubblesMove");
            yield return new WaitForSeconds(4f);
        }
        
    }

    void endlessSpawn()
    {

    }

}
