/*****************************************************************************
// File Name : BossAttack.cs
// Author : Austin Nelson
// Creation Date : April 14, 2025
//
// Brief Description : This is the code for the boss attacking the player
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    [SerializeField] private int damage;
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<Health>(out Health player))
        {
            player.Damage(damage);
        }
    }
}
