using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InteractionController : MonoBehaviour
{
    public PlayerController playerScript;

    public TextMeshProUGUI textoNpc;
    public GameObject panelDialogue;
    public GameObject panelVendedor;

    [Header("vendedor")]
    public string[] itens = { "Pocao", "Pokebola", "Repelente" };

    //public GameObject pokemon;

    // Start is called before the first frame update
    void Start()
    {
        textoNpc = GameObject.Find("TextoDialogo").GetComponent<TextMeshProUGUI>();
        panelDialogue = GameObject.Find("PanelDialogo");
        panelVendedor = GameObject.Find("PanelVenda");

        panelDialogue.SetActive(false);

        playerScript = GameObject.Find("Player").GetComponent<PlayerController>();

        //opcoes do vendedor
        for (int i = 0; i < itens.Length; i++)
        {
            GameObject move = GameObject.Find("Item" + (i + 1));
            move.GetComponentInChildren<TextMeshProUGUI>().text = itens[i];
            string item = move.GetComponentInChildren<TextMeshProUGUI>().text;
            move.GetComponent<Button>().onClick.AddListener(delegate { Invoke(item, 0f); });
        }
        
        panelVendedor.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Pocao()
    {
        Debug.Log("comprou pocao");
    }

    public void Pokebola()
    {
        Debug.Log("comprou pokebola");
    }

    public void Repelente()
    {
        Debug.Log("comprou repelente");
    }

    

}
