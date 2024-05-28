using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Sprites : MonoBehaviour
{
    public PlayerController playerScript;
    public PokeInfosController infoController;

    //Sprite dos pokemons
    public Image enemyPokemon;
    public Image playerPokemon;
    //Nome dos pokemons
    public TextMeshProUGUI textPokePlayer;
    public TextMeshProUGUI textPokeEnemy;
    //Level dos pokemons
    public TextMeshProUGUI textLvlPlayer;
    public TextMeshProUGUI textLvlEnemy;

    //Pokemons com o treinador
    public Sprite[] enemyPokes;
    public Sprite[] playerPokes;

    //Pokemon selecionado
    public int pokemonChoose;
    public int enemyPokemonChoose;

    //Pokemons que o treinador ta carregando
    public string[] pokemons = { "Bulbasaur", "Charmander", "Squirtle", "Pidgey", "Haunter", "Jigglypuff" };

    public GameObject panelPokes;

    

    // Start is called before the first frame update
    void Start()
    {


        //Pega os scripts ajudantes
        playerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        infoController = GameObject.Find("PanelPlayer").GetComponent<PokeInfosController>();
        panelPokes = GameObject.Find("PanelPokeList");

        textPokePlayer = GameObject.Find("NomePlayer").GetComponent<TextMeshProUGUI>();
        textPokeEnemy = GameObject.Find("NomeEnemy").GetComponent<TextMeshProUGUI>();

        textLvlPlayer = GameObject.Find("LvlPlayer").GetComponent<TextMeshProUGUI>();
        textLvlPlayer = GameObject.Find("LvlEnemy").GetComponent<TextMeshProUGUI>();

        enemyPokemon = GameObject.Find("SpriteEnemy").GetComponent<Image>();    //Localiza o elemento que representara o pokemon inimigo
        playerPokemon = GameObject.Find("SpritePlayer").GetComponent<Image>();    //Localiza o elemento que representara o pokemon aliado

        enemyPokes = new Sprite[infoController.poke.Length];   //Pokemons que o inimigo esta carregando
        playerPokes = new Sprite[infoController.poke.Length];  //Pokemons que o jogador esta carregando

        //for (int i = 0; i < pokemons.Length; i++)   //Pegando as sprites dos pokemons pelas assets
        //{
        //    enemyPokes[i] = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Sprites/Criaturas/" + pokemons[i] + " frente.png");
        //    playerPokes[i] = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Sprites/Criaturas/" + pokemons[i] + " costas.png");
        //}

        ////Define o pokemon do player na batalha
        //playerPokemon.sprite = playerPokes[0];
        //textPokePlayer.SetText(pokemons[pokemonChoose]);

    }

    // Update is called once per frame
    void Update()
    {
        ////Mudar as sprites do inimigo aleatoriamente quando achar batalha
        //if (playerScript.inimigoAleatorio == true)
        //{
        //    //aleatorizar o pokemon inimigo
        //    enemyPokemonChoose = Random.Range(0, pokemons.Length);

        //    //Define o pokemon do inimigo na batalha
        //    enemyPokemon.sprite = enemyPokes[enemyPokemonChoose];
        //    textPokeEnemy.SetText(pokemons[enemyPokemonChoose]);

        //    playerScript.inimigoAleatorio = false;
        //}
        
    }

    
}
