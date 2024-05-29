using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BatalhaController : MonoBehaviour
{
    public PlayerController playerScript;

    public List<TextMeshProUGUI> moveTexts;
    

    public GameObject panelInteract;
    public TextMeshProUGUI textoBatalha;

    public bool turnoPlayer; // se true = player, se false = inimgo

    // Start is called before the first frame update
    void Start()
    {
        playerScript = GameObject.Find("Player").GetComponent<PlayerController>();

        panelInteract = GameObject.Find("PanelInteracao");
        textoBatalha = GameObject.Find("TextoBatalha").GetComponent<TextMeshProUGUI>();

        textoBatalha.SetText("O que pokemon vai fazer?");
        turnoPlayer = true;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.L))
        {
            turnoPlayer = false;
        }

        if (turnoPlayer == false)
        {
            StartCoroutine(TurnoInimigo());
        }
        
    }

    public IEnumerator TurnoInimigo()
    {
        turnoPlayer = true; //Para nao repetir a corrotina durante ela mesma
        panelInteract.SetActive(false);

        //Ataque do inimigo
        textoBatalha.SetText("inimigo usou tal");
        yield return new WaitForSeconds(1);
        Debug.Log("Ataque");
        yield return new WaitForSeconds(1);
        textoBatalha.SetText("seu pokemon tomou tal");

        //fim do turno do inimigo
        yield return new WaitForSeconds(1);
        panelInteract.SetActive(true);
        textoBatalha.SetText("O que pokemon vai fazer?");
    }

    public void MoveNames(List<LearnableMove> moves)
    {
        if (playerScript.entrarBatalha == true)
        {
            for (int i = 0; i < moveTexts.Count; i++)
            {

                if (i < moves.Count)
                    moveTexts[i].text = moves[i].Base.Name;
                else
                    moveTexts[i].text = "-";
            }
        }
    }

    public void AtaqueBotao()
    {
        textoBatalha.enabled = false;
    }

    public void Atacar()
    {
        textoBatalha.enabled = true;
        //Depois colocar para o turno ser falso para começar o turno do inimigo
    }

    public void Fugir()
    {
        playerScript.sairBatalha = true;
    }
}
