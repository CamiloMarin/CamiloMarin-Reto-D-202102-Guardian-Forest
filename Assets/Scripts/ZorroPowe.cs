using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZorroPowe : MonoBehaviour
{

    public float multiplier = 0.8f;
    public float duration = 4f;
    public GameObject player;
    public float powerRate;
    private float nextpower;

    void Start()
    {


    }

    public void Update()
    {
         if (Input.GetMouseButtonDown(0) && Time.time > nextpower) {
            nextpower = Time.time + powerRate;
            player.transform.localScale *= multiplier;

        }
    }

    


}
