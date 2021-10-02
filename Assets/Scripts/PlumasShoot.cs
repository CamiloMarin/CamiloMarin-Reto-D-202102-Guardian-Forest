using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlumasShoot : MonoBehaviour
{
    public Transform PlumaSpawner;
    public GameObject PlumaPrefab;
    //public AudioSource disparoplayerSource;
    //public ParticleSystem ps;
    //public Animator anim;
    public float fireRate;
    private float nextfire;

    private void PlayerShooting()
    {
        if (Input.GetMouseButtonUp(0) && Time.time > nextfire)
        {
            nextfire = Time.time + fireRate;
            Instantiate(PlumaPrefab, PlumaSpawner.position, PlumaSpawner.rotation);
            
            //disparoplayerSource.Play();



            //if (ps != null)
            //{
            //  Instantiate<ParticleSystem>(ps, transform.position, ps.transform.rotation).Play();
            //anim.SetTrigger("New Trigger");
            //}
        }

    }

    void Start()
    {

        //disparoplayerSource = GetComponent<AudioSource>();
        //anim = GetComponent<Animator>();
    }
    void Update()
    {

        PlayerShooting();

    }
}
