using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Unit : MonoBehaviour
{
    //declare global variables
    private float health;
    protected float MAX_HEALTH;
    private float speed;
    private float attDammage;
    private float attRange;
    private int team;



    //constructor

    public Unit(float health, float speed, float attDamage, float attRange, int team)
    {

    }


    //properties

    public float AttRange { get => attRange; set => attRange = value; }

    protected int Team { get => team; set => team = value; }

    protected float AttDammage
    { get => attDammage; set
        {
            if (value<=0)
            {
                attDammage = 0;
            }
            else
            {
                attDammage = value;
            }
        }
    }

    protected float Speed { get => speed; set => speed = value; }

    protected float Health { get => health; set => health = value; }

    //abstarct methods

    public abstract void Move();

    public abstract void Attack(GameObject target);

    public abstract void Target();


}
