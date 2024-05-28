using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHp : MonoBehaviour
{
    public Slider hp;
    public Image hpColor;
    public bool isChanging;
    public int hpChange;

    // Start is called before the first frame update
    void Start()
    {
        hp = GetComponent<Slider>();
        hpColor = hp.GetComponentsInChildren<Image>()[1];
        hpChange = (int)hp.value;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isChanging)
        {
            //if (Input.GetKeyDown(KeyCode.X))
            //{
            //    hpChange -= 6;
            //    if (hpChange < 0)
            //    {
            //        hpChange = 0;
            //    }
            //    StartCoroutine(HpDown(hpChange));
            //}
            //if (Input.GetKeyDown(KeyCode.C))
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
            if (hp.value == 0)
            {
                Debug.Log("Desmaiou");
            }
        }
    }

    IEnumerator HpDown(int endHp)
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

    public IEnumerator HpUp(int endHp)
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
}
