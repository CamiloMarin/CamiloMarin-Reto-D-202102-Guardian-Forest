using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthMaster : MonoBehaviour
{
    public float health;
    public static HealthMaster Instance;
    void Start()
    {
        Instance = this;
    }
}
