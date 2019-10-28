using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapManager : MonoBehaviour
{
    [SerializeField]
    private float rescorceRed;
    [SerializeField]
    private float rescorceGreen;

    [SerializeField]
    Text greens;

    [SerializeField]
    Text reds;

    [SerializeField]
    Text win;

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
        greens.text = "Green's Resources:\n" + RescorceGreen;
        reds.text = "Red's Resources: " + RescorceRed;
    }

    // Update is called once per frame
    void Update()
    {
        greens.text = "Green's Resources: " + RescorceGreen;
        reds.text = "Red's Resources: " + RescorceRed;
        CheckUnits();
    }

    void CheckUnits()
    {
        if (GameObject.FindGameObjectsWithTag("GreenTeam")==null)
        {
            win.text = "RED WINS!";
        }
        else if (GameObject.FindGameObjectsWithTag("RedTeam") == null)
        {
            win.text = "GREEN WINS!";
        }


    }
}
