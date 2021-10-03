using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue_Manager : MonoBehaviour
{
    public Dialogue dialogue;
    Queue<string> sentences;
    Queue<Sprite> images;
    [SerializeField] Image characterImage;
    [SerializeField] Button closeDialogBtn;
    [SerializeField] bool closeDialog = false;
    [SerializeField] bool activeActions = false;
    public GameObject portal;

    public GameObject dialoguePanel;
    public Text displayText;

    Sprite activeNextCharacterImage;
    string activeSentence;
    public float typingSpeed;
 
    AudioSource myAudio;
    public AudioClip speakSound;

    void Start()
    {
        //closeDialogBtn.onClick.AddListener(CloseTheDialog);
        sentences = new Queue<string>();
        images = new Queue<Sprite>();
        myAudio = GetComponent<AudioSource>();
        portal.SetActive(false);

    }

    void StartDialogue()
    {
        
        sentences.Clear();
        images.Clear();

        foreach (string sentence in dialogue.sentenceList)
        {
            sentences.Enqueue(sentence);

        }
        foreach (Sprite image in dialogue.imagesList)
        {
            images.Enqueue(image);

        }

        DisplayNextSentence();
    }

    void CloseTheDialog()
    {
        if (activeActions == true)
        {
            this.closeDialog = true;

        }
    }
    void DisplayNextSentence()
    {
        if (closeDialog == false && activeActions == true)
        {


            if (sentences.Count <= 0)
            {
                displayText.text = activeSentence;
                
                return;
            }
            activeNextCharacterImage = images.Dequeue();
            activeSentence = sentences.Dequeue();
            displayText.text = activeSentence;
            StopAllCoroutines();
            StartCoroutine(TypeTheSentence(activeSentence));
        }
        else
        {
            CloseCharacterDialog();
        }
    }
    void CloseCharacterDialog()
    {
        dialoguePanel.SetActive(false);
        myAudio.Stop();
        
    }
    IEnumerator TypeTheSentence(string sentence)
    {
        characterImage.sprite = activeNextCharacterImage;
        displayText.text = "";

        foreach (char letter in sentence.ToCharArray())
        {

            if (closeDialog == false && activeActions == true)
            {

                displayText.text += letter;
                myAudio.PlayOneShot(speakSound);

            }
            else if (closeDialog == true && activeActions == true)
            {
                displayText.text = activeSentence;
                break;

            }
            yield return new WaitForSeconds(typingSpeed);
        }


    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            activeActions = true;
            dialoguePanel.SetActive(true);
            StartDialogue();
            
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.F) && displayText.text == activeSentence)
            {
                if (closeDialog == false && activeActions == true)
                {
                    DisplayNextSentence();
                }
                else
                {
                    CloseCharacterDialog();
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D obj)
    {

        if (obj.CompareTag("Player"))
        {
            this.closeDialog = false;

            activeActions = false;
            
            dialoguePanel.SetActive(false);
            portal.SetActive(true);

        }
    }

   
}
