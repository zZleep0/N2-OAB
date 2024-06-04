using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moves : MonoBehaviour
{

    [SerializeField]
    public Pokemon pokemon;
    [SerializeField]
    public Pokemon enemy;

    public BatalhaController batalhaController;
    
    public EnemyInfosController enemyInfosController;
    public PokeInfosController pokeInfosController;

    public bool atacou = false;

    private void Start()
    {
        batalhaController = GameObject.Find("ScriptBatalha").GetComponent<BatalhaController>();

        pokemon = GameObject.Find("PanelPlayer").GetComponent<Pokemon>();
        enemy = GameObject.Find("PanelEnemy").GetComponent<Pokemon>();

        pokeInfosController = GameObject.Find("PanelPlayer").GetComponent<PokeInfosController>();
        enemyInfosController = GameObject.Find("PanelEnemy").GetComponentInChildren<EnemyInfosController>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.A)/* || atacou == true*/)
        {
            pokemon.FixarInfos(); //Fixar os status do pokemon (o ataque estava ficando 0 sem isso)
            Debug.Log("ataque do " + pokemon.PokeName + " e " + pokemon.Attack);
            PhysicalDamage(enemy);

            enemyInfosController.AtualizaVidaE();
        }

    }
    //Dano Físico
    public void PhysicalDamage(Pokemon target)
    {
        int damage = pokemon.Attack - target.Defense/2;
        Debug.Log(pokemon.Attack + "-" + target.Defense/2);
        if (damage < 0) damage = 0;
        target.CurrentHP -= damage;
        Debug.Log($"{pokemon.PokeName} caused {damage} physical damage to {target.PokeName}!");

        if (enemyInfosController.statusPokeE.CurrentHP >= 0)
            batalhaController.textoBatalha.text = pokeInfosController.statusPoke.PokeName + " causou " + damage.ToString() + " a " + enemyInfosController.statusPokeE.PokeName;

        atacou = false;
        
        enemyInfosController.hpEnemy.StartCoroutine(enemyInfosController.hpEnemy.HpDown(enemyInfosController.hpEnemy.hpChange));
    }

    // Dano Especial
    public void SpecialDamage(Pokemon target)
    {
        int damage = pokemon.SpecialAttack - target.SpecialDefense;
        if (damage < 0) damage = 0;
        target.CurrentHP -= damage;
        Debug.Log($"{pokemon.PokeName} caused {damage} special damage to {target.PokeName}!");
        // Chance to burn the target
        if(UnityEngine.Random.Range(0, 100) < 10) // 10% chance
        {
            target.IsBurned = true;
            Debug.Log($"{target.PokeName} was burned!");
        }
    }

    // Cura
    public void Heal()
    {
        int healAmount = pokemon.CurrentHP / 2;
        pokemon.CurrentHP += healAmount;
        Debug.Log($"{pokemon.PokeName} healed {healAmount} HP!");
    }

    // Aumento de Atributos
    public void IncreaseAttributes()
    {
        pokemon.Attack += 1;
        pokemon.SpecialAttack += 1;
        Debug.Log($"{pokemon.PokeName} increased its Attack and Special Attack!");
    }

    //// Redução de Atributos
    //public void DecreaseAttributes(Pokemon target)
    //{
    //    pokemon.Attack -= 1;
    //    Debug.Log($"{this.Name} decreased {target.Name}'s Attack!");
    //}

    //// Status
    //public void InflictStatus(Pokemon target)
    //{
    //    target.IsParalyzed = true;
    //    Debug.Log($"{this.Name} inflicted paralysis on {target.Name}!");
    //}

    //// Alteração de Campo
    //public void ChangeFieldConditions()
    //{
    //    Debug.Log($"{this.Name} changed the field conditions!");
    //    // Implement specific field condition effects
    //}

    //// Proteção/Desvio
    //public void Protect()
    //{
    //    this.IsProtected = true;
    //    Debug.Log($"{this.Name} used Protect, avoiding damage for one turn!");
    //}

    //// Troca
    //public void ForceSwitch(Pokemon target)
    //{
    //    Debug.Log($"{this.Name} forced {target.Name} to switch out!");
    //    // Implement switch logic
    //}

    //// Debuff de Campo
    //public void ApplyFieldDebuff()
    //{
    //    Debug.Log($"{this.Name} applied a debuff to the opposing field!");
    //    // Implement field debuff effects
    //}

    //// Movimentos de Recarga
    //public void RechargeAttack(Pokemon target)
    //{
    //    int damage = this.SpecialAttack * 2 - target.SpecialDefense;
    //    if (damage < 0) damage = 0;
    //    target.HP -= damage;
    //    Debug.Log($"{this.Name} caused {damage} damage to {target.Name} and needs to recharge next turn!");
    //    // Implement recharge logic
    //}

    //// Movimentos de Vingança
    //public void RevengeAttack(Pokemon target)
    //{
    //    int damage = this.Attack - target.Defense;
    //    if (this.HP < this.HP / 2) // If HP is below half
    //    {
    //        damage *= 2; // Double the damage
    //    }
    //    if (damage < 0) damage = 0;
    //    target.HP -= damage;
    //    Debug.Log($"{this.Name} used a revenge attack on {target.Name}, causing {damage} damage!");
    //}

    //// Movimentos de Cura de Status
    //public void CureStatus()
    //{
    //    this.IsBurned = false;
    //    this.IsParalyzed = false;
    //    this.IsAsleep = false;
    //    Debug.Log($"{this.Name} cured all its status conditions!");
    //}

    //// Movimentos de Aumento de Status de Campo
    //public void IncreaseFieldDefense()
    //{
    //    Debug.Log($"{this.Name} increased the team's Defense!");
    //    // Implement field defense increase effects
    //}

    //// Movimentos de Substituição
    //public void CreateSubstitute()
    //{
    //    int substituteHP = this.HP / 4;
    //    this.HP -= substituteHP;
    //    Debug.Log($"{this.Name} created a substitute with {substituteHP} HP!");
    //    // Implement substitute logic
    //}

    //ATAQUES DO INIMIGO
    //Dano Físico
    public void PhysicalDamageI(Pokemon target)
    {
        int damage = enemy.Attack - target.Defense / 2;
        Debug.Log(enemy.Attack + "-" + target.Defense / 2);
        if (damage < 0) damage = 0;
        target.CurrentHP -= damage;
        Debug.Log($"{enemy.PokeName} caused {damage} physical damage to {target.PokeName}!");

        //if (enemyInfosController.statusPokeE.CurrentHP >= 0)
        //    batalhaController.textoBatalha.text = pokeInfosController.statusPoke.PokeName + " causou " + damage.ToString() + " a " + enemyInfosController.statusPokeE.PokeName;

        //atacou = false;

        //enemyInfosController.hpEnemy.StartCoroutine(enemyInfosController.hpEnemy.HpDown(enemyInfosController.hpEnemy.hpChange));
    }
}
