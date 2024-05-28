using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyInfosController : MonoBehaviour
{
    public PokemonChoose choosePokemon;
    public Sprites scriptSprites;
    public PlayerController playerController;
    //Script do pokemon
    public Pokemon statusPoke;


    //Pokemons possiveis na batalha
    public string[] poke = { "Bulbasaur", "Charmander", "Squirtle", "Pidgey", "Haunter", "Jigglypuff" };
    public int pokeChoose;


    // Start is called before the first frame update
    void Start()
    {
        statusPoke = GetComponent<Pokemon>();
        //scriptSprites = GameObject.Find("ScriptSprites").GetComponent<Sprites>();
        //playerController = GameObject.Find("Player").GetComponent<PlayerController>();

        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            Inimigo();
        }

        //Mudar as sprites do inimigo aleatoriamente quando achar batalha
        //if (scriptSprites.playerScript.inimigoAleatorio == true)
        //{
            //scriptSprites.playerScript.inimigoAleatorio = false;
        //}
    }

    public void Inimigo()
    {
        //aleatorizar o pokemon inimigo
        //pokeChoose = Random.Range(0, poke.Length);
        //statusPoke.pokemon = pokeChoose.ToString();

        statusPoke.pokemon = poke[4];

        scriptSprites.textPokeEnemy.text = statusPoke.pokemonBase.name;
        scriptSprites.enemyPokemon.sprite = statusPoke.pokemonBase.BackSprite;

        ////Define o pokemon do inimigo na batalha
        //scriptSprites.enemyPokemon.sprite = scriptSprites.enemyPokes[scriptSprites.enemyPokemonChoose];
        //scriptSprites.textPokeEnemy.SetText(poke[scriptSprites.enemyPokemonChoose]);

        
    }


    
}
