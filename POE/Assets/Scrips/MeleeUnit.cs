using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeUnit : Unit
{

    //constructor 
    public MeleeUnit(float health, float speed, float attDamage, float attRange, int team) : base(health, speed, attDamage, attRange, team)
    {
        MAX_HEALTH = health;
        Health = health;
        Speed = speed;
        AttDammage = attDamage;
        AttRange = attRange;
        Team = team;
    }

    //Methods

    public override void Move()
    {
        
    }

    public override void Attack(GameObject target)
    {
        
    }

    public override void Target()
    {
        
    }
}
