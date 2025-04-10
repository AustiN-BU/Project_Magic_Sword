/*****************************************************************************
// File Name : TestBoss.cs
// Author : Austin Nelson
// Creation Date : March 25, 2025
//
// Brief Description : This prints a statement showing how much damage was dealt
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBoss : MonoBehaviour, IDamageable
{
    public void Damage(int damageAmount)
    {
        print("That Dealt " + damageAmount);
    }
}
