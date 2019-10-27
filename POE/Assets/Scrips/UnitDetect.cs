using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitDetect : MonoBehaviour
{
    [SerializeField]
    private int speed;

    [SerializeField]
    private float range;

    [SerializeField]
    private float damage;

    [SerializeField]
    private bool onGround;

    GameObject closest;

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Floor"))
        {
            onGround = true;
        }
    }

    private void OnCollisionExit(Collision col)
    {
        if (col.gameObject.CompareTag("Floor"))
        {
            onGround = false;

        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        List<GameObject> enemies = new List<GameObject>();



        if(!gameObject.CompareTag("Wizard"))
        {
            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Wizard"))
            {
                enemies.Add(go);
            }
        }
        if (!gameObject.CompareTag("GreenTeam"))
        {
            foreach (GameObject go in GameObject.FindGameObjectsWithTag("GreenTeam"))
            {
                enemies.Add(go);
            }    
        }
        if (!gameObject.CompareTag("RedTeam"))
        {
            foreach (GameObject go in GameObject.FindGameObjectsWithTag("RedTeam"))
            {
                enemies.Add(go);
            }
        }


        closest = gameObject;
        float closestDistance= float.MaxValue;


        foreach (GameObject go in enemies)
        {
            if (Vector3.Distance(gameObject.transform.position,go.transform.position)<closestDistance)
            {
                closestDistance = Vector3.Distance(gameObject.transform.position, go.transform.position);
                closest = go;
            }
        }
        if (!closest.Equals(gameObject))
        {
            transform.LookAt(closest.transform.position);
            if (closestDistance>range && onGround)
            {
                transform.Translate(transform.forward * speed * Time.deltaTime);
            }
            else if (closestDistance<range)
            {
                Attack(closest);
            }


        }
        
    }

    void Attack(GameObject enemy)
    {
        Target target = enemy.GetComponent<Target>();
        if (target !=null)
        {
            target.Damage(damage*Time.deltaTime);
        }
    }
}
