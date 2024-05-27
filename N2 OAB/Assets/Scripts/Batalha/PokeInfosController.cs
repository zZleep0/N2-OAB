using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokeInfosController : MonoBehaviour
{
    //Script do pokemon
    public Pokemon statusPoke;

    //Pokemon selecionado
    public int pokemonChoose;
    public int enemyPokemonChoose;

    //Pokemons possiveis na batalha
    public string[] poke = { "Bulbasaur", "Charmander", "Squirtle", "Pidgey", "Haunter", "Jigglypuff" };



    // Start is called before the first frame update
    void Start()
    {
        statusPoke = GetComponent<Pokemon>();

        statusPoke.pokemon = poke[1];

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            Debug.Log(statusPoke.pokemon);
        }
    }
}
