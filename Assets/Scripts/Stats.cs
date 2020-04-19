using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public int strength = 1;

    public int speed = 26;
    public int HP;
    public int MaxHP=2;
    void Start()
    {
        HP=MaxHP;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
