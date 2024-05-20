using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatalhaController : MonoBehaviour
{
    public PlayerController playerScript;

    // Start is called before the first frame update
    void Start()
    {
        playerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Fugir()
    {
        playerScript.sairBatalha = true;
    }
}
