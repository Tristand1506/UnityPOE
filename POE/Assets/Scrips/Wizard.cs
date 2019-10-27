using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wizard : Unit
{
    // Start is called before the first frame update
    //GLOBALS
    Slider healthSlider;
    public List<GameObject> inRadius = new List<GameObject>();
    float attIntermission;

    //constructor 

    public Wizard(float health, float speed, float attDamage, float attRange, int team) : base(health, speed, attDamage, attRange, team)
    {
        Health = health;
        MAX_HEALTH = health;
        Speed = speed;
        AttDamage = attDamage;
        AttRange = attRange;
        Team = team;
    }

    private void Start()
    {
        Health = 20;
        MAX_HEALTH = health;
        Speed = 5;
        AttDamage = 5;
        AttRange = 3;
        Team = team;

        //initialising health slider

        healthSlider = (gameObject.GetComponentInChildren<Canvas>()).GetComponentInChildren<Slider>();
        healthSlider.value = 1;
    }

    private void Update()
    {
        Move();
    }

    //Methods

    public override void Move()
    {
        // creates list of enemies by comparing tags
        List<GameObject> enemies = new List<GameObject>();

        // if not wizard wizards are enemy
        if (!gameObject.CompareTag("Wizard"))
        {
            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Wizard"))
            {
                enemies.Add(go);
            }
        }

        // if not wizard GreenTeam are enemy
        if (!gameObject.CompareTag("GreenTeam"))
        {
            foreach (GameObject go in GameObject.FindGameObjectsWithTag("GreenTeam"))
            {
                enemies.Add(go);
            }
        }

        // if not wizard RedTeam are enemy
        if (!gameObject.CompareTag("RedTeam"))
        {
            foreach (GameObject go in GameObject.FindGameObjectsWithTag("RedTeam"))
            {
                enemies.Add(go);
            }
        }

        // Sets default comparison values
        closest = null;
        float closestDistance = float.MaxValue;


        foreach (GameObject go in enemies)
        {
            if (Vector3.Distance(gameObject.transform.position, go.transform.position) < closestDistance)
            {
                closestDistance = Vector3.Distance(gameObject.transform.position, go.transform.position);
                closest = go;
            }
        }
        if (closest!=null)
        {
            transform.LookAt(closest.transform.position);
            attIntermission += Time.deltaTime;
            if (closestDistance > AttRange && onGround)
            {
                transform.Translate(Vector3.forward * Speed * Time.deltaTime);
                
            }
            else if (inRadius.Count>0)
            {
                if (attIntermission>=2)
                { 
                    FireBall();
                }
                
            }
        }
    }


    public override void Attack(GameObject target)
    {
        Unit u = target.GetComponent<Unit>();
        if (u != null)
        {
            u.Damage(AttDamage);
        }
    }

    

    public void FireBall()
    {
        foreach (GameObject go in inRadius)
        {
            if (go!=null)
            {
                Attack(go);
            }
            
            
        }
        attIntermission = 0;
    }

    public override void Damage(float amount)
    {
        healthSlider = (gameObject.GetComponentInChildren<Canvas>()).GetComponentInChildren<Slider>();
        health -= amount;
        if (healthSlider != null)
        {
            healthSlider.value = health / MAX_HEALTH;
        }

        if (health <= 0)
        {
            Death();
        }
    }

    private void Death()
    {
        Destroy(gameObject);
    }
}
