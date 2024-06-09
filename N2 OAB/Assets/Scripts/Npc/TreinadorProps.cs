using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreinadorProps : MonoBehaviour
{
    public bool lutaNPC;
    public bool isNpcDefeated = false;
    public bool vsNPC = false;
    public int pokeNPC;
    
    PlayerController playerController;
    EnemyInfosController enemyInfosController;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        enemyInfosController = GameObject.Find("PanelEnemy").GetComponent<EnemyInfosController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NPCState()
    {
        if (isNpcDefeated == false)
        {
            vsNPC = true;
            lutaNPC = true;
            playerController.interactController.textoNpc.text = "Voce se meteu em encrenca";
            playerController.canMove = false;
            playerController.StartCountdown();
        }
        else if (isNpcDefeated == true)
        {
            playerController.interactController.textoNpc.text = "Eu fui derrotado, droga!";
        }
    }

    public void PokeNPC()
    {
        switch (pokeNPC)
        {
            case 0: enemyInfosController.pokeChoose = 0;
                break;
            case 1: enemyInfosController.pokeChoose = 1;
                break;
            case 2: enemyInfosController.pokeChoose = 2;
                break;
            case 3: enemyInfosController.pokeChoose = 3;
                break;
            case 4: enemyInfosController.pokeChoose = 4;
                break;
            case 5: enemyInfosController.pokeChoose = 5;
                break;
        }
    }
}
