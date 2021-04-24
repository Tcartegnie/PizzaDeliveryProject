using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienAttack : Attack
{
    void Start()
    {
        timer.onBeat += CallAttack;
    }

}
