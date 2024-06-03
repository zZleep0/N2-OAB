using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class XPController : MonoBehaviour
{
    public Slider xp;
    public bool isChanging;
    public int xpChange;

    public EnemyInfosController enemyInfosController;
    public PokeInfosController pokeInfosController;

    // Start is called before the first frame update
    void Start()
    {
        enemyInfosController = GameObject.Find("PanelEnemy").GetComponent<EnemyInfosController>();
        pokeInfosController = GameObject.Find("PanelPlayer").GetComponent<PokeInfosController>();

        xp = GetComponent<Slider>();
        xpChange = (int)xp.value;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isChanging)
        {
            if (enemyInfosController.fimBatalha == true)
            {
                enemyInfosController.fimBatalha = false;
                xpChange += 100;
                StartCoroutine(XpUp(xpChange));
                //enemyInfosController.hpEnemy.isAlive = false;
            }

        }
    }

    IEnumerator XpUp(int endXp)
    {
        isChanging = true;
        while (Mathf.Abs(endXp - xp.value) > 0)
        {
            xp.value++;
            if (xp.value == xp.maxValue)
            {
                pokeInfosController.statusPoke.Level++;
                Debug.Log("Lv agora é " + pokeInfosController.statusPoke.Level);
                pokeInfosController.scriptSprites.textLvlPlayer.text = "Lv " + pokeInfosController.statusPoke.Level;
                xp.maxValue *= 3;
            }
            yield return null;
        }
        xp.value = endXp;

        isChanging = false;
    }
}
