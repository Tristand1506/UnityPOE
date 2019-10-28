using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    [SerializeField]
    private float rescorceRed;
    [SerializeField]
    private float rescorceGreen;

    private int unitsRed;
    private int unitsGreen;

    private int buldingsRed;
    private int buildingsGreen;

    private int wizards;

    // preoperties
    public float RescorceRed { get => rescorceRed; set => rescorceRed = value; }
    public float RescorceGreen { get => rescorceGreen; set => rescorceGreen = value; }
    public int UnitsRed { get => unitsRed; set => unitsRed = value; }
    public int UnitsGreen { get => unitsGreen; set => unitsGreen = value; }
    public int BuldingsRed { get => buldingsRed; set => buldingsRed = value; }
    public int BuildingsGreen { get => buildingsGreen; set => buildingsGreen = value; }
    public int Wizards { get => wizards; set => wizards = value; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
