using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerGame : MonoBehaviour
{
    public Animator transitionsAnim;
    public string sceneName;
    public AudioSource buttonSound;
    public void CambiarEscena()
    {
        StartCoroutine(LoadScene());
    }
    public void ReStart()
    {
        StartCoroutine(LoadScene());
    }

    public void Play()
    {
        StartCoroutine(LoadScene());
    }

    IEnumerator LoadScene()
    {
        transitionsAnim.SetTrigger("end");
        buttonSound.Play();
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(sceneName);
    }

}
