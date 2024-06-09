using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class AtaqueController : MonoBehaviour
{
    public GameObject panelAtaques;
    public EnemyInfosController enemyInfosController;
    public PokeInfosController pokeInfosController;

    public Pokemon poke;
    public Moves moveAction;
    public MoveBase[] moveBase;
    public string[] moveNames = { "Ember", "Growl", "Scratch" }; //0

    // Start is called before the first frame update
    void Start()
    {
        //moveNames = new string[4];
        
        moveBase = new MoveBase[3];

        moveAction = GameObject.Find("ScriptBatalha").GetComponent<Moves>();
        enemyInfosController = GameObject.Find("PanelEnemy").GetComponent<EnemyInfosController>();
        pokeInfosController = GameObject.Find("PanelPlayer").GetComponent<PokeInfosController>();

        panelAtaques = GameObject.Find("PanelAtaques");
        panelAtaques.SetActive(false);

        
        //for (int i = 0; i < moveNames.Length; i++)
        //{
        //    moveNames[i] = poke.pokemonBase.LearnableMoves[i].Base.Name;
        //}
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            MovimentosSetup();
        }
    }

    public void MovimentosSetup()
    {
        for (int i = 0; i < moveBase.Length; i++)
        {
            moveBase[i] = AssetDatabase.LoadAssetAtPath<MoveBase>("Assets/Game/Resources/Moves/" + moveNames[i] + ".asset");
        }

        for (int i = 0; i < moveBase.Length; i++)
        {
            GameObject move = GameObject.Find("Ataque" + (i + 1));
            move.GetComponentInChildren<TextMeshProUGUI>().text = moveNames[i];
            string ataque = move.GetComponentInChildren<TextMeshProUGUI>().text;
            move.GetComponent<Button>().onClick.AddListener(delegate { Invoke(ataque, 0f); });
        }
    }

    public void Ember()
    {
        Debug.Log("Usou ember");

        moveAction.SpecialDamage(moveAction.enemy);
    }

    public void Growl()
    {
        Debug.Log("Upou o ataque");
    }

    public void Scratch()
    {
        moveAction.PhysicalDamage(moveAction.enemy);
        
    }
}
