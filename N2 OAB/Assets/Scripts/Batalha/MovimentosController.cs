using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class MovimentosController : MonoBehaviour
{
    public Moves moveAction;
    public MoveBase[] moveBase;
    string[] moveNames = { "Ember", "Growl", "Scratch"};

    // Start is called before the first frame update
    void Start()
    {
        moveAction = GameObject.Find("BatalhaController").GetComponent<Moves>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            MovimentosSetup();

        }
    }

    public void MovimentosSetup()
    {
        for (int i = 0; i < moveBase.Length; i++)
        {
            moveBase[i] = AssetDatabase.LoadAssetAtPath<MoveBase>("Assets/Game/Resources/" + moveNames[i] + ".assets");
        }

        for (int i = 0;i < moveBase.Length; i++)
        {
            GameObject move = GameObject.Find("Ataque" + (i + 1));
            move.GetComponentInChildren<TextMeshProUGUI>().text = moveNames[i];
            string ataque = move.GetComponentInChildren<TextMeshProUGUI>().text;
            move.GetComponent<Button>().onClick.AddListener(delegate { Invoke(ataque, 0f); });
        }
    }

    public void Ember()
    {
        moveAction.PhysicalDamage(moveAction.enemy);
    }

    public void Growl()
    {

    }

    public void Scratch()
    {

    }
}
