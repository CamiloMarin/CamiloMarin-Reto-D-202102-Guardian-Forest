using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCharacterSystem : MonoBehaviour
{
    public GameObject character1, character2, character3;
    [SerializeField] private Transform characterPosition;
    [SerializeField] private Transform character1Position;
    [SerializeField] private Transform character2Position;
    private int selectedCharacter = 1;
    private Transform lastCharacter = null;


    void Start()
    {
        lastCharacter = character1.transform;
        character1.SetActive(true);
        character2.SetActive(false);
        character3.SetActive(false);
    }

    public void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            character1.SetActive(true);
            character2.SetActive(false);
            character3.SetActive(false);
            selectedCharacter = 1;
            ChangePosition(selectedCharacter, lastCharacter);
            lastCharacter = character1.transform;
        }

        if (Input.GetKeyDown("2"))
        {
            character1.SetActive(false);
            character2.SetActive(true);
            character3.SetActive(false);  
            selectedCharacter = 2;
            ChangePosition(selectedCharacter, lastCharacter);
            lastCharacter = character2.transform;
        }

        if (Input.GetKeyDown("3"))
        {
            character1.SetActive(false);
            character2.SetActive(false);
            character3.SetActive(true);
            selectedCharacter = 3;
            ChangePosition(selectedCharacter,lastCharacter);
            lastCharacter = character3.transform;
        }
    }
   
    private void ChangePosition(int characterNumber, Transform lastCharacter)
    {
        switch (characterNumber)
        {
            case 1:
                character1.transform.position = lastCharacter.transform.position;
                break;

            case 2:
                character2.transform.position = lastCharacter.transform.position;

                break;

            case 3:
                character3.transform.position = lastCharacter.transform.position;
                break;
            default:
                break;
        }
    }
    
}
