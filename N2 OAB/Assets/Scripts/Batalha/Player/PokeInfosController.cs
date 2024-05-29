using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PokeInfosController : MonoBehaviour
{
    public PlayerHp hpPlayer;
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
        scriptSprites = GameObject.Find("ScriptSprites").GetComponent<Sprites>();
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        hpPlayer = GameObject.Find("HpPlayer").GetComponent<PlayerHp>();

        pokeChoose = 1;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerController.entrarBatalha == true || Input.GetKeyDown(KeyCode.I))
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
        statusPoke.CurrentHP = (int)hpPlayer.hp.value;

        //Colocar as infos no Canvas
        scriptSprites.textPokePlayer.text = statusPoke.PokeName;
        scriptSprites.playerPokemon.sprite = statusPoke.pokemonBase.BackSprite;

        //statusPoke.Level = Random.Range(2, 10);
        statusPoke.Level = 2;
        //scriptSprites.textLvlPlayer.SetText("Lv" + statusPoke.Level); ////nao funciona
        //Debug.Log(statusPoke.Level);
    }

    //Feito no script PlayerHp
    public void AtualizarVida()
    {
        statusPoke.CurrentHP = (int)hpPlayer.hp.value;
        Debug.Log("A vida do pokemon agora é " + statusPoke.CurrentHP);
    }

}
