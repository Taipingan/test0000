using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScript : MonoBehaviour
{
    public GameObject WalkingMode;
    public GameObject CombatMode;

    // Start is called before the first frame update
    void Start()
    {
        CombatMode.SetActive(false);
        WalkingMode.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        SwitchMode();
    }
    void SwitchMode()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            CombatMode.transform.position = WalkingMode.transform.position;
            CombatMode.transform.rotation = WalkingMode.transform.rotation;
            CombatMode.SetActive(true);
            WalkingMode.SetActive(false);
        }
        else if (Input.GetKey(KeyCode.E))
        {
            CombatMode.SetActive(false);
            WalkingMode.SetActive(true);
        }

    }
}
