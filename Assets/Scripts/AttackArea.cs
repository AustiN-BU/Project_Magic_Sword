/*****************************************************************************
// File Name : AttackArea.cs
// Author : Austin Nelson
// Creation Date : March 25, 2025
//
// Brief Description : This is the code for the area that is counted for attacks, it was made with the help of a tutorial
*****************************************************************************/
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    //Makes IDamageable public
    public List<GameObject> Damageables = new List<GameObject>();
   
    //Checks if the Object has the IDamageable script
    public void OnTriggerEnter(Collider other)
    {
        var damagable = other.GetComponent<IDamageable>();
        if (damagable != null)
        {
            Damageables.Add(other.gameObject);
        }
    }


    public void OnTriggerExit(Collider other)
    {
        var damagable = other.GetComponent<IDamageable>();
        if (damagable != null && Damageables.Contains(other.gameObject))
        {
            Damageables.Remove(other.gameObject);
        }
    }


}
