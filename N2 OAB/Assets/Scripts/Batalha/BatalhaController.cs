using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Sprites : MonoBehaviour
{
    //public EnemyPanelController enemyPanelController;
    //public NPCInteract npcInteract;

    //Sprite dos pokemons
    public Image enemyPokemon;
    public Image playerPokemon;

    //Pokemons com o treinador
    public Sprite[] enemyPokes;
    public Sprite[] playerPokes;

    //Sprite do player
    public Object[] spritePlayer;

    //Pokemons que o treinador ta carregando
    public string[] pokemons = { "Alakazam", "Gengar", "Hitmonlee", "Hypno", "Snorlax", "Squirtle" };

    //Pokemon selecionado
    public int pokemonChoose;

    public TextMeshProUGUI textPokePlayer;
    public TextMeshProUGUI textPokeEnemy;

    // Start is called before the first frame update
    void Start()
    {
        //Pega os scripts ajudantes
        //npcInteract = GameObject.Find("Player").GetComponent<NPCInteract>();
        //enemyPanelController = GameObject.Find("PanelEnemy").GetComponent<EnemyPanelController>();

        textPokePlayer = GameObject.Find("NomePlayer").GetComponent<TextMeshProUGUI>();
        textPokeEnemy = GameObject.Find("NomeEnemy").GetComponent<TextMeshProUGUI>();

        enemyPokemon = GameObject.Find("SpriteEnemy").GetComponent<Image>();    //Localiza o elemento que representara o pokemon inimigo
        playerPokemon = GameObject.Find("SpritePlayer").GetComponent<Image>();    //Localiza o elemento que representara o pokemon aliado

        enemyPokes = new Sprite[pokemons.Length];   //Pokemons que o inimigo esta carregando
        playerPokes = new Sprite[pokemons.Length];  //Pokemons que o jogador esta carregando

        for (int i = 0; i < pokemons.Length; i++)   //Pegando as sprites dos pokemons pelas assets
        {
            enemyPokes[i] = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Sprites/" + pokemons[i] + " frente.png");
            playerPokes[i] = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Sprites/" + pokemons[i] + " costas.png");
        }

        //pokemon = Random.Range(0, pokemons.Length);
        //pokemonChoose = enemyPanelController.pokemon;

        //Definir os pokemons que iniciarao a batalha
        enemyPokemon.sprite = enemyPokes[pokemonChoose];
        playerPokemon.sprite = playerPokes[0];



        //Recebendo as sprites do treinador
        spritePlayer = AssetDatabase.LoadAllAssetsAtPath("Assets/Sprites/PlayerMovement.png");

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void EscolherPokemon(int poke)
    {
        playerPokemon.sprite = playerPokes[poke];   //Modificar o sprite para o pokemon escolhido

        textPokePlayer.text = pokemons[poke].FirstCharacterToUpper();     //Modificar o nome para o pokemon escolhido, deixando ele com a primeira letra maiuscula
    }
}
