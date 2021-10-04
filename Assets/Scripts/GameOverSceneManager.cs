using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverSceneManager : MonoBehaviour
{
    public Animator transitionsAnim;
    
    public void CambiarEscena()
    {
        StartCoroutine(LoadScene());
    }
    public void ReStart()
    {
        StartCoroutine(LoadRestart());
    }

    IEnumerator LoadScene()
    {
        transitionsAnim.SetTrigger("end");
        SoundManager.Playsound("on");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("MainMenu");

    }

    IEnumerator LoadRestart()
    {
        transitionsAnim.SetTrigger("end");
        SoundManager.Playsound("on");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(3);
    }
}
