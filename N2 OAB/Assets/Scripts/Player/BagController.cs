using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BagController : MonoBehaviour
{
    public string[] itens = { "Pocao", "Pokebola", "Repelente" };

    public Slider playerSlider;
    public int hpchange;
    public GameObject panelMochila;

    public PlayerHp playerHP;
    public BatalhaController batalhaController;

    [Header("Quantidade de items")]
    public int qtdePocao;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < itens.Length; i++)
        {
            GameObject move = GameObject.Find("ItemBag" + (i + 1));
            move.GetComponentInChildren<TextMeshProUGUI>().text = itens[i];
            string item = move.GetComponentInChildren<TextMeshProUGUI>().text;
            move.GetComponent<Button>().onClick.AddListener(delegate { Invoke(item, 0f); });
        }

        playerHP = GameObject.Find("HpPlayer").GetComponent<PlayerHp>();
        batalhaController = GameObject.Find("ScriptBatalha").GetComponentInChildren<BatalhaController>();
        playerSlider = GameObject.Find("HpPlayer").GetComponent<Slider>();

        panelMochila = GameObject.Find("PanelMochila");
        panelMochila.SetActive(false);

        qtdePocao = 2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Pocao()
    {
        if (qtdePocao > 0)
        {
            //Para teste
            //playerSlider.value += 10;

            hpchange = (int)playerHP.hp.value;
            hpchange += 10;
            if (hpchange < 0)
            {
                hpchange = 0;
            }
            StartCoroutine(playerHP.HpUp(hpchange));
            qtdePocao--;
            Debug.Log("Usou pocao, agora tem " + qtdePocao);
            StartCoroutine(UsarPocao());
        }
        else
        {
            Debug.Log("acabou as pocoes");
        }
        
    }

    public void Pokebola()
    {
        Debug.Log("Jogou a pokebola");
    }

    public IEnumerator UsarPocao()
    {
        batalhaController.textoBatalha.text = "Seu pokemon curou " + hpchange;
        yield return new WaitForSeconds(1);
        batalhaController.textoBatalha.text = batalhaController.padrao;
    }
}
