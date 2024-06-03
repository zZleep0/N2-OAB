using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.UI;

public class EnemyInfosController : MonoBehaviour
{
    public EnemyHP hpEnemy;
    public Sprites scriptSprites;
    public PlayerController playerController;
    //Script do pokemon
    public Pokemon statusPokeE;

    public bool fimBatalha = false;

    //Pokemons possiveis na batalha
    public string[] poke = { "Bulbasaur", "Charmander", "Squirtle", "Pidgey", "Haunter", "Jigglypuff" };
    public int pokeChoose;


    // Start is called before the first frame update
    void Start()
    {
        statusPokeE = GetComponent<Pokemon>();
        scriptSprites = GameObject.Find("ScriptSprites").GetComponent<Sprites>();
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        hpEnemy = GameObject.Find("HpEnemy").GetComponent<EnemyHP>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //Mudar as sprites do inimigo aleatoriamente quando achar batalha
        if (scriptSprites.playerScript.inimigoAleatorio == true)
        {
            Inimigo();
            scriptSprites.playerScript.inimigoAleatorio = false;
        }
        if (scriptSprites.playerScript.batalhaMoment == true)
            DefinirVida();
        
            

    }

    public void Inimigo()
    {
        //aleatorizar o pokemon inimigo
        pokeChoose = Random.Range(0, poke.Length);
        statusPokeE.pokemon = poke[pokeChoose];

        //aleatorizar o nivel do inimigo
        statusPokeE.Level = Random.Range(2, 10);

        //Pegar as infos no Pokemon que pega o PokemonBase
        statusPokeE.FixarInfos();

        //Definir a vida do pokemon com base no status (nao faco ideia de que acidente ocorreu aqui)
        hpEnemy.hp.maxValue = statusPokeE.MaxHP;
        statusPokeE.MaxHP = (int)hpEnemy.hp.value; // Definir MaxHP com base no slider
        Debug.Log("a vida é " + hpEnemy.hp.value);
        hpEnemy.hp.value = statusPokeE.CurrentHP;
        statusPokeE.CurrentHP = (int)hpEnemy.hp.maxValue; // Definir CurrentHP como MaxHP

        //Colocar as infos no Canvas
        scriptSprites.textPokeEnemy.text = statusPokeE.PokeName;
        scriptSprites.enemyPokemon.sprite = statusPokeE.pokemonBase.FrontSprite;
        scriptSprites.textLvlEnemy.text = "Lv " + statusPokeE.Level;


    }

    

    public void DefinirVida()
    {
        //Atualizar o slider da vida
        hpEnemy.hp.value = statusPokeE.CurrentHP;
    }

    public void AtualizaVidaE()
    {
        //Para teste
        //hpEnemy.hp.value = statusPokeE.CurrentHP;

        if (statusPokeE.CurrentHP <= 0)
        {
            fimBatalha = true;
            statusPokeE.CurrentHP = 0;
            Debug.Log("Zerou a vida");
            hpEnemy.batalhaController.textoBatalha.text = "O inimigo foi derrotado";
            hpEnemy.isAlive = false;
            scriptSprites.playerScript.batalhaMoment = false;
            hpEnemy.StartCountDown();
        }

        else
        {
            hpEnemy.hpChange = statusPokeE.CurrentHP;
            hpEnemy.StartCoroutine(hpEnemy.HpDown(hpEnemy.hpChange));
            Debug.Log("A vida do pokemon inimigo agora é " + statusPokeE.CurrentHP);
        }

    }

}
