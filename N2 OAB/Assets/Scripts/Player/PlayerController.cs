using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    

    [Header("Movimento player")]
    public float moveSpeed; //Controle de velocidade
    public bool isMoving; //Indica se o objeto esta se movendo
    public bool isRunning;
    public bool canMove; //Indica se o player pode mover
    public Vector2 startPos;
    public Vector2 endPos;

    [Header("Controle de layers no overworld")]
    public LayerMask grassLayer;
    public LayerMask objectsLayer;
    public LayerMask lojaPortaLayer;
    public LayerMask lojaSaidaLayer;

    [Header("Batalha infos")]
    public bool entrarBatalha;
    public bool sairBatalha;
    public bool inimigoAleatorio;

    [Header("Entrar em estruturas")]
    public bool entrouLoja = false;
    public bool saiuLoja = false;

    [Header("Interacao NPC")]
    public LayerMask npcLayer;
    public LayerMask npcEnemyLayer;
    public LayerMask npcVendedor;
    public LayerMask npcCriatura;
    public LayerMask npcCura;
    public bool isInteracting = false;
    public bool isNPCDefeated;
    public bool vsNPC;
    public bool isCriaDefeated;
    public bool vsCria;
    public InteractionController interactController;
    


    // Start is called before the first frame update
    void Start()
    {
        interactController = GameObject.Find("InteractController").GetComponent<InteractionController>();
        

        moveSpeed = 5;
        canMove = true;

        isCriaDefeated = false;
        isNPCDefeated = false;
    }

    // Update is called once per frame
    void Update()
    {
        #region andar e correr
        //Movimento
        if (!isMoving)
        {
            startPos.x = Input.GetAxisRaw("Horizontal");
            startPos.y = Input.GetAxisRaw("Vertical");

            if (startPos.x != 0)
            {
                startPos.y = 0;
            }
            if (startPos != Vector2.zero)
            {
                endPos = transform.position;
                endPos.x += startPos.x;
                endPos.y += startPos.y;

                if (Walking(endPos))
                {
                    StartCoroutine(Move(endPos));
                }
            }
        }

        //Correr
        isRunning = Input.GetKey(KeyCode.LeftShift);
        if (isRunning)
        {
            moveSpeed = 8;
        }
        else
        {
            moveSpeed = 5;
        }
        #endregion

    }

    #region movimento do player
    IEnumerator Move(Vector3 endPos)
    {
        if (canMove == true)
        {
            isMoving = true;

            //sqrMagniture : � a hipotenusa de um triangulo retangulo
            //Mathf.Epsilon : � o menor valor que um float pode ser. Usado para precis�o no movimento
            while ((endPos - transform.position).sqrMagnitude > Mathf.Epsilon)
            {
                transform.position = Vector2.MoveTowards(transform.position, endPos, moveSpeed * Time.deltaTime);

                yield return null;
            }

            transform.position = endPos;

            isMoving = false;
            Battle();
            Interacao();
            //EntrarLoja();
            //SairLoja();
        }
    }

    public bool Walking(Vector3 endPos)
    {
        if (Physics2D.OverlapCircle(endPos, 0.2f, objectsLayer) != null)
        {
            return false;
        }
        return true;
    }
    #endregion

    public void Battle()
    {
        if (Physics2D.OverlapCircle(transform.position, 0.2f, grassLayer))
        {
            Debug.Log("esta no layer grassLayer");
            if (Random.Range(1, 101) <= 20)
            {
                inimigoAleatorio = true;
                canMove = false;
                entrarBatalha = true;
                Debug.Log("encontrou uma batalha");
                
            }
        }
    }

    #region interacao de npc
    public void Interacao()
    {
        if (Physics2D.OverlapCircle(transform.position, 0.5f, npcLayer))
        {
            interactController.panelDialogue.SetActive(true);
            interactController.textoNpc.SetText("Oi");
            Debug.Log("ta no layer do npc");
        }

        //Interacao com inimimgo
        else if (Physics2D.OverlapCircle(transform.position, 0.5f, npcEnemyLayer))
        {
            Debug.Log("esta no layer npcEnemyL");
            interactController.panelDialogue.SetActive(true);
            if (isNPCDefeated == false)
            {
                vsNPC = true;
                interactController.textoNpc.SetText("Voce se meteu em encrenca");
                // Chama a fun��o para iniciar a contagem regressiva ap�s intera��o
                StartCountdown();
            }
            else if (isNPCDefeated == true)
            {
                interactController.textoNpc.SetText("Eu fui derrotado, droga!");
            }
        }

        //Interacao com pokemon
        //else if (Physics2D.OverlapCircle(transform.position, 0.5f, npcCriatura))
        //{
        //    Debug.Log("esta no layer npcpokemon");
        //    if (isCriaDefeated == false)
        //    {
        //        vsCria = true;
        //        // Chama a fun��o para iniciar a contagem regressiva ap�s intera��o
        //        StartCountdown();
        //    }
        //    else if (isCriaDefeated == true)
        //    {
        //        vsCria = false;
        //        //Destroy(interactController.pokemon);
        //    }
        //}

        //Interacao com vendedor
        else if (Physics2D.OverlapCircle(transform.position, 0.5f, npcVendedor))
        {
            Debug.Log("esta no layer vendedor");
            interactController.panelDialogue.SetActive(true);
            interactController.textoNpc.SetText("Como posso te ajudar?");

            interactController.panelVendedor.SetActive(true);
        }

        //Interacao com curandeira
        else if (Physics2D.OverlapCircle(transform.position, 0.5f, npcCura))
        {
            Debug.Log("esta no layer cura");
            interactController.panelDialogue.SetActive(true);
            interactController.panelCuradora.SetActive(true);
            interactController.textoNpc.SetText("Voce gostaria de curar seus pokemons?");
            
        }

        //Nao esta interagindo
        else
        {
            if (interactController.panelVendedor.activeSelf == true)
            {
                interactController.panelVendedor.SetActive(false);
            }
            interactController.panelDialogue.SetActive(false);
            interactController.panelCuradora.SetActive(false);
            isInteracting = false; // Reinicia a intera��o
        }
    }
    //Countdown para transicao de tela
    private void StartCountdown()
    {
        if (!isInteracting)
        {
            isInteracting = true;
            StartCoroutine(CountDownCoroutine());
        }
    }
    private IEnumerator CountDownCoroutine()
    {
        yield return new WaitForSeconds(2f); // Espera 2 segundos

        entrarBatalha = true; // Carrega a batalha
    }
    #endregion

    //public void EntrarLoja()
    //{
    //    if (Physics2D.OverlapCircle(transform.position, 0.2f, lojaPortaLayer))
    //    {
    //        Debug.Log("ta no layer da loja");
    //        entrouLoja = true;
    //    }
    //}

    //public void SairLoja()
    //{
    //    if (Physics2D.OverlapCircle(transform.position, 0.2f, lojaSaidaLayer))
    //    {
    //        Debug.Log("ta no layer da saida");
    //        saiuLoja = true;
    //    }
    //}
}
