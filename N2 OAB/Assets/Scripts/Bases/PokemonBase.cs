using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Pokemon", menuName = "Pokemon/Create new Pokemon")]
public class PokemonBase : ScriptableObject
{
    

    //Classificação
    [SerializeField] string pokemonName;
    [SerializeField] int pokemonID;
    #region pegando variaveis
    public string PokemonName
    {
        get { return pokemonName; }
    }
    public int PokemonID
    {
        get { return pokemonID; }
    }
    #endregion 

    [TextArea]
    [SerializeField] string pokeDescription;
    #region pegando variaveis
    public string PokeDescription
    {
        get { return pokeDescription; }
    }
    #endregion

    [SerializeField] PokeType pokeType1;
    [SerializeField] PokeType pokeType2;
    #region pegando variaveis
    public PokeType PokeType1
    {
        get { return pokeType1; }
    }
    public PokeType PokeType2
    {
        get { return pokeType2; }
    }
    #endregion

    [SerializeField] int maxHP;
    [SerializeField] int attack;
    [SerializeField] int defense;
    [SerializeField] int spAttack;
    [SerializeField] int spDefense;
    [SerializeField] int speed;
    #region pegando variaveis
    public int MaxHP
    {
        get { return maxHP; }
    }
    public int Attack
    {
        get { return attack; }
    }
    public int Defense
    {
        get { return defense; }
    }
    public int SpAttack
    {
        get { return spAttack; }
    }
    public int SpDefense
    {
        get { return spDefense; }
    }
    public int Speed
    {
        get { return speed; }
    }
    #endregion

    [SerializeField] List<LearnableMove> learnableMoves;
    #region pegando variaveis
    public List<LearnableMove> LearnableMoves
    {
        get { return learnableMoves;}
    }
    #endregion


}

[System.Serializable]
public class LearnableMove
{
    [SerializeField] MoveBase moveBase;
    [SerializeField] int level;

    public MoveBase Move
    {
        get { return moveBase; }
    }
    public int Level
    {
        get { return level; }
    }
}

public enum PokeType
{
    Nenhum,
    Normal,
    Fogo,
    Agua,
    Planta,
    Voador,
    Veneno,
    Inseto,
    Eletrico,
    Terra,
    Fada,
    Luta,
    Psiquico,
    Fantasma,
    Pedra,
    Aco,
    Gelo,
    Dragao,
    Noturno
}
