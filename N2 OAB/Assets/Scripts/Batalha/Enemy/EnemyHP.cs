using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnemyHP : MonoBehaviour
{
    public Slider hp;
    public Image hpColor;
    public bool isChanging;
    public int hpChange;

    public bool isAlive;

    public PlayerController playerScript;
    public Sprites spriteScript;

    // Start is called before the first frame update
    void Start()
    {
        playerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        spriteScript = GameObject.Find("ScriptSprites").GetComponent <Sprites>();

        hp = GetComponent<Slider>();
        hpColor = hp.GetComponentsInChildren<Image>()[1];
        hpChange = (int)hp.value;
        isAlive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isChanging)
        {
            //if (Input.GetKeyDown(KeyCode.N))
            //{
            //    hpChange -= 6;
            //    if (hpChange < 0)
            //    {
            //        hpChange = 0;
            //    }
            //    StartCoroutine(HpDown(hpChange));
            //}
            //if (Input.GetKeyDown(KeyCode.M))
            //{
            //    hpChange += 6;
            //    if (hpChange > hp.maxValue)
            //    {
            //        hpChange = (int)hp.maxValue;
            //    }
            //    StartCoroutine(HpUp(hpChange));
            //}
            if (hp.value > hp.maxValue / 2)
            {
                hpColor.color = Color.green;
            }
            else if (hp.value > hp.maxValue / 4)
            {
                hpColor.color = Color.yellow;
            }
            else
            {
                hpColor.color = Color.red;
            }

            if (hp.value <= 0)
            {
                
                Debug.Log("Desmaiou");
                StartCountDown();
                isAlive = false;

                if (playerScript.vsNPC == true)
                {
                    playerScript.isNPCDefeated = true;
                }
                else if (playerScript.vsCria == true)
                {
                    playerScript.isCriaDefeated = true;
                }
            }
        }


    }

    public IEnumerator HpDown(int endHp)
    {
        isChanging = true;
        while (Mathf.Abs(endHp - hp.value) > 0.05)
        {
            hp.value -= 0.05f;
            yield return null;
        }
        hp.value = endHp;

        isChanging = false;
    }

    IEnumerator HpUp(int endHp)
    {
        isChanging = true;
        while (Mathf.Abs(endHp - hp.value) > 0.05)
        {
            hp.value += 0.05f;
            yield return null;
        }
        hp.value = endHp;

        isChanging = false;
    }

    void StartCountDown()
    {
        if (!isAlive)
        {
            Debug.Log("comecou o countdown");
            playerScript.sairBatalha = true;
        }
    }

    public void VidaPokemon()
    {
        
    }
}
