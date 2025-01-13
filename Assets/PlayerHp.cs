using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHp : MonoBehaviour
{
    public int hp;

    public void Damage(int damageAmount)
    {
        hp = hp-damageAmount;
    }
    
}
