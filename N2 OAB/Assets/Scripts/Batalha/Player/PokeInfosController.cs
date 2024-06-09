using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Experimental.Rendering;
using UnityEngine;
using UnityEngine.UI;

public class PokeInfosController : MonoBehaviour
{
    public PlayerHp hpPlayer;
    public PokemonChoose choosePokemon;
    public Sprites scriptSprites;
    public PlayerController playerController;
    public AtaqueController ataqueController;
    //Script do pokemon
    public Pokemon statusPoke;
    

    //Pokemons possiveis na batalha
    public string[] poke = { "Bulbasaur", "Charmander", "Squirtle", "Pidgey", "Haunter", "Jigglypuff" };
    public int pokeChoose;



    void Start()
    {
        statusPoke = GetComponent<Pokemon>();
        scriptSprites = GameObject.Find("ScriptSprites").GetComponent<Sprites>();
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        hpPlayer = GameObject.Find("HpPlayer").GetComponent<PlayerHp>();
        ataqueController = GameObject.Find("ScriptAtaque").GetComponent <AtaqueController>();

        pokeChoose = 1;

        //Definir o nivel inicial do pokemon
        statusPoke.Level = 4;

        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerController.batalhaMoment == true)
            DefinirVida();
        if (playerController.entrarBatalha == true)
        {            
            Player();
        }
        
    }

    public void Player()
    {
        //Escolha de pokemon no script pokemonChoose
        statusPoke.pokemon = poke[pokeChoose];

        //pegar os status no script pokemon
        statusPoke.FixarInfos();

        //Definir a vida do pokemon com base no status
        hpPlayer.hp.maxValue = statusPoke.MaxHP;
        statusPoke.MaxHP = (int)hpPlayer.hp.value;
        hpPlayer.hp.value = statusPoke.CurrentHP;
        statusPoke.CurrentHP = (int)hpPlayer.hp.maxValue;

        //Colocar as infos no Canvas
        scriptSprites.textPokePlayer.text = statusPoke.PokeName;
        scriptSprites.playerPokemon.sprite = statusPoke.pokemonBase.BackSprite;
        scriptSprites.textLvlPlayer.text = "Lv" + statusPoke.Level;

        //Atribuir os movimentos
        //ataqueController.MovimentosSetup();
    }

    public void DefinirVida()
    {
        hpPlayer.hp.value = statusPoke.CurrentHP;
    }

    //Feito no script PlayerHp
    public void AtualizarVida()
    {
        hpPlayer.hpChange = statusPoke.CurrentHP;
        //hpPlayer.StartCoroutine(hpPlayer.HpDown(hpPlayer.hpChange));
        //Debug.Log("A vida do pokemon agora é " + statusPoke.CurrentHP);
    }

}
