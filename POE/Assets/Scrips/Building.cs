using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Building : MonoBehaviour
{
    protected float health;
    protected float MAX_HEALTH;
    protected int team;

    

    //constructor
    public Building(float health, int team)
    {
        Health = health;
        MAX_HEALTH = Health;
        Team = team;
    }

    //properties
    protected float Health { get => health; set => health = value; }
    protected int Team { get => team; set => team = value; }

    public abstract void Damage(float amount);
}
