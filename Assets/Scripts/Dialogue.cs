﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class Dialogue : MonoBehaviour
{
    public new string name;

    [TextArea(3, 10)]
    public string[] sentenceList;
    public Sprite[] imagesList;
}
