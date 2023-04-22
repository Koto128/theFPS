using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class projectile : MonoBehaviour
{

    public float time;
    public float i;
    public float pace;
    public Transform player;
    public Text timmer;  

    float currentTime = 0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (currentTime == time)
        {
            StopCoroutine("bubblesMove");
        }
    }

    IEnumerator bubblesMove()
    {
        for (int time = 1; time <= i; time++)
        {
            timmer.text = time.ToString();
            if (time <= i)
            {
                currentTime++;
            }
            yield return new WaitForSeconds(1f);
        }

    }
}
