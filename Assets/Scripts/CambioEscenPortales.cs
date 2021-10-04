using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioEscenPortales : MonoBehaviour
{
    public Animator transitionsAnimPortal;
    public Animator transitionsAnim;
    public string sceneName;
    public AudioSource portalSound;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {


            StartCoroutine(LoadPortal());


        }
    }

    IEnumerator LoadPortal()
    {
        transitionsAnimPortal.SetTrigger("isTeletransport");
        portalSound.Play();
        yield return new WaitForSeconds(1.5f);
        StartCoroutine(LoadScene());
    }
    IEnumerator LoadScene()
    {
        
        transitionsAnim.SetTrigger("end");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(sceneName);
    }
}
