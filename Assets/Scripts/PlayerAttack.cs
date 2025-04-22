/*****************************************************************************
// File Name : PlayerAttack.cs
// Author : Austin Nelson
// Creation Date : March 25, 2025
//
// Brief Description : This Controls The Vertical and Horizontal attacks the player can use, it was made with the help 
of a tutorial from YouTube
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    private bool _isAttacking;

    [SerializeField]
    private float HorizontalDamageAfterTime;

    [SerializeField]
    private float VerticalDamageAfterTime;

    [SerializeField]
    private int Damage;

    [SerializeField]
    private AttackArea _attackArea;

    private Animator playerAnimator;

    private void Start()
    {
        playerAnimator = GetComponent<Animator>();
    }

    //Controls what happens with Horizontal Attacks
    public void OnHorizontalAttack(InputValue value)
    {
        if (_isAttacking) return;
        Debug.Log(message: "HorizontalAttack");
        StartCoroutine(routine: Hit(false));
        //animation
        playerAnimator.Play("HorizontalAttack");
    }

    //Controls what happens with Vertical Attacks
    public void OnVerticalAttack(InputValue value)
    {
        if (_isAttacking) return;
        Debug.Log(message: "VerticalAttack");
        StartCoroutine(routine: Hit(true));
        //animation
        playerAnimator.Play("VerticalAttack");

    }

    //Controls Cooldown
    private IEnumerator Hit(bool vertical)
    {
        _isAttacking = true;
        yield return new WaitForSeconds(vertical ? VerticalDamageAfterTime : HorizontalDamageAfterTime);
        foreach (GameObject attackAreaDamageable in _attackArea.Damageables)
        {
            attackAreaDamageable.GetComponent<IDamageable>().Damage(Damage * (vertical ? 1 : 1));
            attackAreaDamageable.GetComponent<Health>().Damage(Damage * (vertical ? 1 : 1));
        }
        yield return new WaitForSeconds(vertical ? VerticalDamageAfterTime : HorizontalDamageAfterTime);
        _isAttacking = false;
    }
}
