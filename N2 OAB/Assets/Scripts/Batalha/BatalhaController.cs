using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class BatalhaController : MonoBehaviour
{
    public PlayerController playerScript;
    public Moves movesScript;
    public PokeInfosController pokeInfosController;
    public EnemyInfosController enemyInfosController;
    
    //public List<TextMeshProUGUI> moveTexts;
    //[SerializeField] public MoveBase[] movesBase;
    //public string[] moveNames = { "Charm", "Confuse Ray", "Covert", "Echoed Voice", "Ember", "Growl", "Gust", "Mean Look", "Payback", "Sand Attack", "Scratch", "Spite", "Tackle", "Vine Whip", "Water Gun", "Withdraw" };
    //public List<string> nomes;

    public GameObject panelInteract;
    public TextMeshProUGUI textoBatalha;
    public string padrao = "O que pokemon vai fazer?";

    public bool turnoPlayer; // se true = player, se false = inimgo
    public bool ataqueInimigo = false;

    // Start is called before the first frame update
    void Start()
    {
        pokeInfosController = GameObject.Find("PanelPlayer").GetComponent<PokeInfosController>();
        enemyInfosController = GameObject.Find("PanelEnemy").GetComponent<EnemyInfosController>();

        playerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        movesScript = GetComponent<Moves>();

        panelInteract = GameObject.Find("PanelInteracao");
        textoBatalha = GameObject.Find("TextoBatalha").GetComponent<TextMeshProUGUI>();

        textoBatalha.text = "O que pokemon vai fazer?";
        turnoPlayer = true;
    }

    // Update is called once per frame
    void Update()
    {

        //if (Input.GetKeyDown(KeyCode.L))
        //{
        //    turnoPlayer = false;
        //}

        if (turnoPlayer == false)
        {
            TrocaTurno();
        }

        if (playerScript.entrarBatalha == true)
        {
            panelInteract.SetActive(true);
            textoBatalha.SetText(padrao);
            MoveNames();
        }
    }

    public void TrocaTurno()
    {
         StartCoroutine(TurnoInimigo());
    }

    public IEnumerator TurnoInimigo()
    {
        turnoPlayer = true; //Para nao repetir a corrotina durante ela mesma
        panelInteract.SetActive(false);

        yield return new WaitForSeconds(2); //espera a corrotina de diminuir a vida

        if (enemyInfosController.scriptSprites.playerScript.batalhaMoment == true)
        {
            //Ataque do inimigo
            textoBatalha.SetText(enemyInfosController.statusPokeE.PokeName + " usou Ataque");

            movesScript.PhysicalDamageI(movesScript.pokemon);
            movesScript.pokeInfosController.AtualizarVida();
            yield return new WaitForSeconds(1);
            Debug.Log("Ataque");

            yield return new WaitForSeconds(1);
            textoBatalha.text = "A vida do seu pokemon é " + pokeInfosController.statusPoke.CurrentHP;

            //fim do turno do inimigo
            yield return new WaitForSeconds(1);
            panelInteract.SetActive(true);
            textoBatalha.SetText(padrao);
        }
        
    }

    //public void Movimentos()
    //{
    //    for (int i = 0; i < movesBase.Length; i++)
    //    {
    //        movesBase[i] = AssetDatabase.LoadAssetAtPath<MoveBase>("Assets/Game/Resources/Moves/" + moveNames[i] + ".assets");
    //    }
    //}

    public void MoveNames()
    {
        //for (int i = 0; i < moveTexts.Count; i++)
        //{
        //    GameObject moves = GameObject.Find("Ataque" + (i + 1));
        //    moves.GetComponentInChildren<TextMeshProUGUI>().text = "" + moveTexts[i];
        //    string ataque = moves.GetComponentInChildren<TextMeshProUGUI>().text;
        //    moves.GetComponent<Button>().onClick.AddListener(delegate { Invoke(ataque, 0f); });
        //}


        //nomes = new List<string>();

        //foreach (var move in pokeInfosController.statusPoke.LearnableMoves)
        //{
        //    nomes.Add(move.ToString());
        //}


        //for (int i = 0; i < nomes.Count; i++)
        //{
        //    GameObject moves = GameObject.Find("Ataque" + (i + 1));
        //    moves.GetComponentInChildren<TextMeshProUGUI>().text = nomes[i];
        //    string ataque = nomes[i];
        //    moves.GetComponent<Button>().onClick.AddListener(delegate { Invoke(ataque, 0f); });
        //}
        //Debug.Log(nomes[1]);


    }

    public void AtaqueBotao()
    {
        textoBatalha.enabled = false;
        
    }

    public void Atacar()
    {
        textoBatalha.enabled = true;
        movesScript.atacou = true;
        //Depois colocar para o turno ser falso para começar o turno do inimigo
        turnoPlayer = false;
    }

    public void Fugir()
    {
        playerScript.sairBatalha = true;
    }

    
}
