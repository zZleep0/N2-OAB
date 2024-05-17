using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //public Cameras camLoja;
    //public NPCInteract npcInteract;

    [Header("Movimento player")]
    public float moveSpeed; //Controle de velocidade
    public bool isMoving; //Indica se o objeto esta se movendo
    public bool isRunning;
    public bool canMove;
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

    [Header("Entrar em estruturas")]
    public bool entrouLoja = false;
    public bool saiuLoja = false;

    [Header("Interacao NPC")]
    public LayerMask npcLayer;
    public LayerMask npcEnemyLayer;
    public LayerMask npcVendedor;
    public LayerMask npcCriatura;
    public bool isInteracting = false;
    public bool isNPCDefeated;
    public bool vsNPC;
    public bool isCriaDefeated;
    public bool vsCria;


    //public GameObject player;
    //public SpriteRenderer spritePlayer;

    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 5;
        canMove = true;

        isCriaDefeated = false;
        isNPCDefeated = false;
        //spritePlayer = GameObject.Find("PlayerMovement_0").GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (SceneManager.GetActiveScene().name == "BattleScene")
        //{
        //    canMove = false;
        //    spritePlayer.enabled = false;
        //}
        //else
        //{
        //    canMove = true;
        //    spritePlayer.enabled = true;
        //}

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

    }

    IEnumerator Move(Vector3 endPos)
    {
        if (canMove == true)
        {
            isMoving = true;

            //sqrMagniture : é a hipotenusa de um triangulo retangulo
            //Mathf.Epsilon : é o menor valor que um float pode ser. Usado para precisão no movimento
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

    public void Battle()
    {
        if (Physics2D.OverlapCircle(transform.position, 0.2f, grassLayer))
        {
            Debug.Log("esta no layer grassLayer");
            if (Random.Range(1, 101) <= 20)
            {
                entrarBatalha = true;
                Debug.Log("encontrou uma batalha");
                //player.SetActive(false);
            }
        }
    }

    public void Interacao()
    {
        if (Physics2D.OverlapCircle(transform.position, 0.5f, npcLayer))
        {
            Debug.Log("ta no layer do npc");
        }
    }

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
