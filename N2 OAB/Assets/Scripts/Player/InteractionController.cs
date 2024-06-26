using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InteractionController : MonoBehaviour
{
    [Header("Scripts")]
    public PlayerController playerScript;
    public BagController bagController;
    public PlayerHp playerHp;

    [Header("Npcs gerais")]
    public TextMeshProUGUI textoNpc;
    public GameObject txtProximo;
    public GameObject panelDialogue;
    //public string[] infoNpc = { "Nada", "Informante", "Ajudante" };
    
    [Header("Curadora")]
    public GameObject panelCuradora;
    public Slider playerSlider;

    [Header("vendedor")]
    public string[] itens = { "Pocao", "Pokebola", "Repelente" };
    public GameObject panelVendedor;

    //[Header("Inimigo")]
    //public int[] idInimigo = { 1, 2, 3, 4, 5, 6};

    // Start is called before the first frame update
    void Start()
    {
        textoNpc = GameObject.Find("TextoDialogo").GetComponent<TextMeshProUGUI>();
        txtProximo = GameObject.Find("TxtProximo");
        panelDialogue = GameObject.Find("PanelDialogo");
        panelVendedor = GameObject.Find("PanelVenda");
        panelCuradora = GameObject.Find("PanelCuradora");
        playerSlider = GameObject.Find("HpPlayer").GetComponent<Slider>();

        panelDialogue.SetActive(false);

        playerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        bagController = GameObject.Find("BagController").GetComponent<BagController>();

        //opcoes do vendedor
        for (int i = 0; i < itens.Length; i++)
        {
            GameObject move = GameObject.Find("Item" + (i + 1));
            move.GetComponentInChildren<TextMeshProUGUI>().text = itens[i];
            string item = move.GetComponentInChildren<TextMeshProUGUI>().text;
            move.GetComponent<Button>().onClick.AddListener(delegate { Invoke(item, 0f); });
        }
        
        panelVendedor.SetActive(false);
        panelCuradora.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Pocao()
    {
        bagController.qtdePocao++;
        Debug.Log("comprou pocao, agora tem " + bagController.qtdePocao);
    }

    public void Pokebola()
    {
        Debug.Log("comprou pokebola");
    }

    public void Repelente()
    {
        Debug.Log("comprou repelente");
    }

    public void CurarNPC()
    {
        playerSlider.value = playerSlider.maxValue;
        Debug.Log("Curou seus pokemons");
    }

}
