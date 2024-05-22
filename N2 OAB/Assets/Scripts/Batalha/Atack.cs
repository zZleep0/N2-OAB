using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Atack : MonoBehaviour
{
    [SerializeField] MoveBase[] moves;
    string[] moveNames = { "BodySlam", "Cut", "Disable", "Growth", "Harden", "Pound", "QuickAttack" };

    public Slider pokeSlider;
    public int hpchange;
    public EnemyHP enemyhp;

    private void Start()
    {
        Movimentos();

        //for (int i = 0; i < moves.Length; i++)
        //{
        //    GameObject move = GameObject.Find("Ataque" + (i + 1));
        //    move.GetComponentInChildren<TextMeshProUGUI>().text = moves[i];
        //    string ataque = move.GetComponentInChildren<TextMeshProUGUI>().text;
        //    move.GetComponent<Button>().onClick.AddListener(delegate { Invoke(ataque, 0f); });
        //}
        enemyhp = GameObject.Find("HpEnemySlider").GetComponent<EnemyHP>();
        GameObject.Find("LutarPanel").SetActive(false);
        enemyhp.hp = GameObject.Find("HpEnemySlider").GetComponent<Slider>();


    }

    public void Movimentos()
    {
        for (int i = 0; i < moves.Length; i++)
        {
            moves[i] = AssetDatabase.LoadAssetAtPath<MoveBase>("Assets/Pokemon/Moves/Normal/" + moveNames[i] + ".assets");
        }
    }

    public void Confusion()
    {
        //pokeSlider = GameObject.Find("HpEnemySlider").GetComponent<Slider>();
        //pokeSlider.value -= 10;

        hpchange = (int)enemyhp.hp.value;
        hpchange -= 10;
        if (hpchange < 0)
        {
            hpchange = 0;
        }
        StartCoroutine(enemyhp.HpDown(hpchange));
        Debug.Log("usou Confusion");
    }

    public void Frustration()
    {
        Debug.Log("O ataque aumentou");
    }

    public void ShadowBall()
    {
        hpchange = (int)enemyhp.hp.value;
        hpchange -= 20;
        StartCoroutine(enemyhp.HpDown(hpchange));
    }

    public void FirePunch()
    {
        hpchange = (int)enemyhp.hp.value;
        hpchange -= 15;
        StartCoroutine(enemyhp.HpDown(hpchange));
    }
}
