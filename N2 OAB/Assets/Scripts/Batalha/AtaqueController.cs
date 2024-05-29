using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueController : MonoBehaviour
{
    public GameObject panelAtaques;

    // Start is called before the first frame update
    void Start()
    {

        panelAtaques = GameObject.Find("PanelAtaques");

        panelAtaques.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
