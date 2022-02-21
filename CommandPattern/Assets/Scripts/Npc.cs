using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Npc : Unit
{
    public override void Init()
    {
        CurrentPosition = new Vector2(10, 10);
    }
}
