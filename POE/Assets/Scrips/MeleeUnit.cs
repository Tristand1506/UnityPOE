using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MeleeUnit : Unit
{
    //GLOBALS
    Slider healthSlider;

    float healIntermission;


    //constructor 

    public MeleeUnit(float health, float speed, float attDamage, float attRange, int team) : base(health, speed, attDamage, attRange, team)
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
        Health = 50;
        MAX_HEALTH = health;
        Speed = 5;
        AttDamage = 5;
        AttRange = 4;
        Team = team;

        
        //initialising health slider
        
        healthSlider = (gameObject.GetComponentInChildren<Canvas>()).GetComponentInChildren<Slider>();
        healthSlider.value = 1;
    }

    private void Update()
    {
        healIntermission += Time.deltaTime;
        OutOfBounds();
       
        Move();
    }

    public void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Wizard"))
        {
            Wizard wiz = col.gameObject.GetComponent<Wizard>();
            wiz.inRadius.Add(gameObject);
        }
    }
    public void OnTriggerExit(Collider col)
    {
        if (col.gameObject.CompareTag("Wizard"))
        {
            Wizard wiz = col.gameObject.GetComponent<Wizard>();
            wiz.inRadius.Remove(gameObject);
        }
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
        closest = gameObject;
        float closestDistance = float.MaxValue;


        foreach (GameObject go in enemies)
        {
            if (Vector3.Distance(gameObject.transform.position, go.transform.position) < closestDistance)
            {
                closestDistance = Vector3.Distance(gameObject.transform.position, go.transform.position);
                closest = go;
            }
        }
        if (closest != gameObject)
        {
            transform.LookAt(closest.transform.position);
            if (Health<=MAX_HEALTH*0.75f && closestDistance > AttRange && onGround)
            {
                if (healIntermission >= 2.0f)
                {
                    Health += 5;
                    healthSlider = (gameObject.GetComponentInChildren<Canvas>()).GetComponentInChildren<Slider>();

                    if (healthSlider != null)
                    {
                        healthSlider.value = health / MAX_HEALTH;
                    }
                    healIntermission = 0;
                }
                if (Health <= MAX_HEALTH * 0.55f)
                {
                    transform.Translate(Vector3.forward * (2.5f * Speed) * Time.deltaTime);
                }
                else
                {
                    transform.Translate(Vector3.forward * Speed * Time.deltaTime);
                }
                
            }
            else if (closestDistance > AttRange && onGround)
            {
                transform.Translate(Vector3.forward * Speed * Time.deltaTime);
            }
            else if (closestDistance < AttRange)
            {
                Attack(closest);
            }


        }
    }

    public override void Attack(GameObject target)
    {
        Unit u = target.GetComponent<Unit>();
        Building b = target.GetComponent<Building>();
        if (u != null)
        {
            if (health<=MAX_HEALTH*0.55f)
            {
                u.Damage((AttDamage*2.5f)* Time.deltaTime);
            }
            else
            {
                u.Damage(AttDamage * Time.deltaTime);
            }
            
        }
        else if (b != null)
        {
            b.Damage(AttDamage * Time.deltaTime);
        }
        
    }

    public override void Damage(float amount)
    {
        health -= amount;
        healthSlider = (gameObject.GetComponentInChildren<Canvas>()).GetComponentInChildren<Slider>();
        
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

    private void OutOfBounds()
    {
        if (gameObject.transform.position.y<-1)
        {
            Death();
        }
    }
}
