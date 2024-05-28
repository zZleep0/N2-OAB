using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PokeInfosController : MonoBehaviour
{
    public PokemonChoose choosePokemon;
    public Sprites scriptSprites;
    public PlayerController playerController;
    //Script do pokemon
    public Pokemon statusPoke;


    //Pokemons possiveis na batalha
    public string[] poke = { "Bulbasaur", "Charmander", "Squirtle", "Pidgey", "Haunter", "Jigglypuff" };



    // Start is called before the first frame update
    void Start()
    {
        statusPoke = GetComponent<Pokemon>();
        scriptSprites = GameObject.Find("ScriptSprites").GetComponent<Sprites>();
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();

        statusPoke.pokemon = poke[1];
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            
            Player();
        }
    }

    public void Player()
    {
        scriptSprites.textPokePlayer.text = statusPoke.pokemonBase.name;
        scriptSprites.playerPokemon.sprite = statusPoke.pokemonBase.BackSprite;

        //statusPoke.Level = Random.Range(2, 10);
        statusPoke.Level = 2;
        //scriptSprites.textLvlPlayer.SetText("Lv" + statusPoke.Level); ////nao funciona
        //Debug.Log(statusPoke.Level);
    }

}
