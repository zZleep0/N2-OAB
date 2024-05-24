using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PokemonChoose : MonoBehaviour
{
    public Sprites spritesScript;

    private GameObject panelPokeChoose;
    //private TextMeshProUGUI nomePokePlayer;
    


    //Pokemons que o treinador ta carregando
    public string[] pokemons = { "Bulbasaur", "Charmander", "Squirtle", "Pidgey", "Haunter", "Jigglypuff" };

    // Start is called before the first frame update
    void Start()
    {
        panelPokeChoose = GameObject.Find("PanelPokeChoose");
        spritesScript = GameObject.Find("ScriptSprites").GetComponent<Sprites>();
        

        for (int i = 0; i < pokemons.Length; i++)
        {
            GameObject pokes = GameObject.Find("PokeChoose" + (i + 1));
            pokes.GetComponentInChildren<TextMeshProUGUI>().text = pokemons[i];
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
        }
    }

    public void EscolherPoke(int poke)
    {
        spritesScript.playerPokemon.sprite = spritesScript.playerPokes[poke];   //Modificar o sprite para o pokemon escolhido

        spritesScript.textPokePlayer.text = pokemons[poke].FirstCharacterToUpper();     //Modificar o nome para o pokemon escolhido, deixando ele com a primeira letra maiuscula
    }
}
