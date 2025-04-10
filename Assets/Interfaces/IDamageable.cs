/*****************************************************************************
// File Name : IDamageable.cs
// Author : Austin Nelson
// Creation Date : March 25, 2025
//
// Brief Description : This makes Damage a parameter, It was made using a YouTube Tutorial As a Guide.
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Makes Damage Amount a Parameter
public interface IDamageable
{
    public void Damage(int damageAmount);
}
