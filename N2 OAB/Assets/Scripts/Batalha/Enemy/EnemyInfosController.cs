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
        if (scriptSprites.playerScript.inimigoAleatorio == true || Input.GetKeyDown(KeyCode.U))
        {
            Inimigo();
            scriptSprites.playerScript.inimigoAleatorio = false;
        }

    }

    public void Inimigo()
    {
        //aleatorizar o pokemon inimigo
        pokeChoose = Random.Range(0, poke.Length);
        statusPokeE.pokemon = poke[pokeChoose];

        //Pegar as infos no Pokemon que pega o PokemonBase
        statusPokeE.FixarInfos();

        //Definir a vida do pokemon com base no status
        hpEnemy.hp.maxValue = statusPokeE.MaxHP;
        //hpEnemy.hp.value = statusPokeE.CurrentHP;

        //Colocar as infos no Canvas
        scriptSprites.textPokeEnemy.text = statusPokeE.PokeName;
        scriptSprites.enemyPokemon.sprite = statusPokeE.pokemonBase.FrontSprite;

        ////Define o pokemon do inimigo na batalha
        //scriptSprites.enemyPokemon.sprite = scriptSprites.enemyPokes[scriptSprites.enemyPokemonChoose];
        //scriptSprites.textPokeEnemy.SetText(poke[scriptSprites.enemyPokemonChoose]);

        
    }


    
}
