using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PokemonChoose : MonoBehaviour
{
    public PlayerController playerController;
    public Sprites spritesScript;
    public PokeInfosController pokeInfosController;

    private GameObject panelPokeChoose;
    //private TextMeshProUGUI nomePokePlayer;

    //Pokemons que o treinador ta carregando
    //public string[] pokemons = { "Bulbasaur", "Charmander", "Squirtle", "Pidgey", "Haunter", "Jigglypuff" };

    // Start is called before the first frame update
    void Start()
    {
        panelPokeChoose = GameObject.Find("PanelPokeChoose");
        spritesScript = GameObject.Find("ScriptSprites").GetComponent<Sprites>();
        pokeInfosController = GameObject.Find("PanelPlayer").GetComponent<PokeInfosController>();
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        

        for (int i = 0; i < pokeInfosController.poke.Length; i++)
        {
            GameObject pokes = GameObject.Find("PokeChoose" + (i + 1));
            pokes.GetComponentInChildren<TextMeshProUGUI>().text = pokeInfosController.poke[i];
            string pokemon = pokes.GetComponentInChildren<TextMeshProUGUI>().text;
            pokes.GetComponent<Button>().onClick.AddListener(delegate { Invoke(pokemon, 0f); });
        }

        panelPokeChoose.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            panelPokeChoose.SetActive(true);
            playerController.canMove = false;
        }
    }

    public void EscolherPoke(int poke)
    {
        //spritesScript.playerPokemon.sprite = pokeInfosController.statusPoke.pokemonBase.BackSprite;
        spritesScript.playerPokemon.sprite = spritesScript.playerPokes[poke];   //Modificar o sprite para o pokemon escolhido

        spritesScript.textPokePlayer.text = pokeInfosController.poke[poke].FirstCharacterToUpper();     //Modificar o nome para o pokemon escolhido, deixando ele com a primeira letra maiuscula
    }

    public void CancelarMenu()
    {
        playerController.canMove = true;
    }
}
