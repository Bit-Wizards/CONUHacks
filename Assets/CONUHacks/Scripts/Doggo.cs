﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doggo : Soilder
{
    new void Awake()
    {
        speed = 0.3f;
        SetTeam();
        FindEnemyTeam();
        dead = false;
        health = 85; //inital health
        SetColor();

    }
    protected void SetColor()
    {
        if (gameObject.tag == "Red_Team")
        {
            gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
        }
    }
    new private void Attack()
    {
        if (isAttacking)
        {
            float damageAmount = UnityEngine.Random.Range(50, 60);
            try
            {
                targetedEnemy.GetComponent<Doggo>().RecieveDamage(damageAmount);
                if (targetedEnemy.GetComponent<Doggo>().IsDead())
                {
                    isAttacking = false;
                    LookForNewTarget();
                }
            }
            catch (MissingReferenceException e)
            {
                LookForNewTarget();
            }
        }
    }
}
