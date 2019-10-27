using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBound : MonoBehaviour
{

    public Color GizmosColor = new Color(0.5f, 0.5f, 0.5f, 0.2f);
    [SerializeField]
    private int spawnNumber;

    [SerializeField]
    private GameObject unitType;

    private void OnDrawGizmos()
    {
        Gizmos.color=GizmosColor;
        Gizmos.DrawCube(transform.position, transform.localScale);
    }


    private void Start()
    {
        Vector3 origin = transform.position;
        Vector3 range = transform.localScale;
        
        for (int i = 0; i <= spawnNumber; i++)
        {
            Vector3 randomRange = new Vector3(Random.Range(-range.x, range.x),
                                  Random.Range(-range.y, range.y),
                                  Random.Range(-range.z, range.z));

            Instantiate(unitType, origin + randomRange, Quaternion.identity);
        }
    }
}
