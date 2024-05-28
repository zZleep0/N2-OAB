using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Pokemon : MonoBehaviour
{
    public PlayerController playerScript;
    public PokemonChoose pokemonChoose;

    public string pokemon;
    public PokemonBase pokemonBase;
    // Atributos privados
    private string pokeName;
    private int level;
    private int maxHP;
    private int currentHP;
    private int baseHP;
    private int incrementHP;
    private int attack;
    private int baseAttack;
    private int incrementAttack;
    private int defense;
    private int baseDefense;
    private int incrementDefense;
    private int specialAttack;
    private int baseSpecialAttack;
    private int incrementSpecialAttack;
    private int specialDefense;
    private int baseSpecialDefense;
    private int incrementSpecialDefense;
    private int speed;
    private int baseSpeed;
    private int incrementSpeed;
    private PokemonType type1;
    private PokemonType type2;

    // Adicione mais atributos conforme necessário...

    // Variáveis temporárias para controle durante as batalhas
    private bool isProtected;
    private bool isBurned;
    private bool isParalyzed;
    private bool isFrozen;
    private bool isAsleep;
    private bool isConfused;
    private bool isPoisoned;
    // Adicione mais variáveis temporárias conforme necessário...

    // Construtor
    private void Awake()
    {
        // Atributos iniciais
        UpdateAttributes();
    }

    // Propriedades públicas para acesso aos atributos privados
    public string PokeName
    {
        get { return pokeName; }
        set { pokeName = value; }
    }

    public int Level
    {
        get { return level; }
        set
        {
            level = value;
            UpdateAttributes(); // Atualiza os atributos ao subir de nível
        }
    }

    public int MaxHP
    {
        get { return maxHP; }
        set { maxHP = value; }
    }

    public int CurrentHP
    {
        get { return currentHP; }
        set { currentHP = value; }
    }

    public int Attack
    {
        get { return attack; }
        set { attack = value; }
    }

    public int Defense
    {
        get { return defense; }
        set { defense = value; }
    }

    public int SpecialAttack
    {
        get { return specialAttack; }
        set { specialAttack = value; }
    }

    public int SpecialDefense
    {
        get { return specialDefense; }
        set { specialDefense = value; }
    }

    public int Speed
    {
        get { return speed; }
        set { speed = value; }
    }

    public bool IsProtected
    {
        get { return isProtected; }
        set { isProtected = value; }
    }

    public bool IsBurned
    {
        get { return isBurned; }
        set { isBurned = value; }
    }

    public bool IsParalyzed
    {
        get { return isParalyzed; }
        set { isParalyzed = value; }
    }

    public bool IsFrozen
    {
        get { return isFrozen; }
        set { isFrozen = value; }
    }

    public bool IsAsleep
    {
        get { return isAsleep; }
        set { isAsleep = value; }
    }

    public bool IsConfused
    {
        get { return isConfused; }
        set { isConfused = value; }
    }

    public bool IsPoisoned
    {
        get { return isPoisoned; }
        set { isPoisoned = value; }
    }

    // Método para atualizar os atributos ao subir de nível
    private void UpdateAttributes()
    {
        // Ajusta os atributos com base no novo nível e nos incrementos de atributo
        maxHP = baseHP + (incrementHP * level);
        attack = baseAttack + (incrementAttack * level);
        defense = baseDefense + (incrementDefense * level);
        specialAttack = baseSpecialAttack + (incrementSpecialAttack * level);
        specialDefense = baseSpecialDefense + (incrementSpecialDefense * level);
        speed = baseSpeed + (incrementSpeed * level);
        // Adicione mais ajustes de atributos conforme necessário...
    }

    // Método para exibir informações do Pokémon
    public void DisplayInfo()
    {
        Debug.Log($"Name: {pokeName}");
        Debug.Log($"Level: {level}");
        Debug.Log($"Max HP: {maxHP}");
        Debug.Log($"Current HP: {currentHP}");
        Debug.Log($"Attack: {attack}");
        Debug.Log($"Defense: {defense}");
        //Debug.Log($"Attack: {specialAttack}");
        //Debug.Log($"Defense: {specialDefense}");
        //Debug.Log($"Defense: {speed}");
        //if(type2 == PokeType.None)
        //    Debug.Log($"Type: {type1}");
        //else
        //    Debug.Log($"Type: {type1}/{type2}");
        //Debug.Log($"Protected: {isProtected}");
        //Debug.Log($"Burned: {isBurned}");
        //Debug.Log($"Paralyzed: {isParalyzed}");
        //Debug.Log($"Frozen: {isFrozen}");
        //Debug.Log($"Asleep: {isAsleep}");
        //Debug.Log($"Confused: {isConfused}");
        //Debug.Log($"Poisoned: {isPoisoned}");
        // Exiba outros atributos conforme necessário...
    }

    private void Update()
    {
        if(playerScript.entrarBatalha)
        {
            pokemonBase = AssetDatabase.LoadAssetAtPath<PokemonBase>("Assets/Game/Resources/Pokemons/" + pokemon + ".asset");
            this.pokeName = pokemonBase.name;
            this.level = 2;
            this.maxHP = pokemonBase.MaxHp;
            this.attack = pokemonBase.Attack;
            this.defense = pokemonBase.Defense;
            DisplayInfo();
        }
    }

    private void Start()
    {
        playerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        pokemonChoose = GameObject.Find("CanvasControllers").GetComponentInChildren<PokemonChoose>();
    }
}