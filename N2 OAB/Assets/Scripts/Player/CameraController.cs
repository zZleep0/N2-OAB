using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
    public Camera overworldCam;
    public Camera battleCam;

    public Image painel;

    public bool changeCam = false;
    public bool cam = true;

    //public GameObject playerObj;
    public PlayerController playerScript;

    // Start is called before the first frame update
    void Start()
    {
        overworldCam = GameObject.Find("Main Camera").GetComponent<Camera>();
        battleCam = GameObject.Find("CameraBatalha").GetComponent<Camera>();
        painel = GameObject.Find("PanelTransicao").GetComponent<Image>();
        playerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        //playerObj = GameObject.Find("Player");

        overworldCam.enabled = cam;
        battleCam.enabled = !cam;
    }

    // Update is called once per frame
    void Update()
    {

        if (playerScript.entrarBatalha == true)//Input.GetKeyDown(KeyCode.K)
        {
            StartCoroutine(EntrarBatalha());
            playerScript.entrarBatalha = false;

        }
        else if (playerScript.sairBatalha == true)
        {
            playerScript.canMove = true;
            StartCoroutine(SairBatalha());
            playerScript.sairBatalha = false;
        }


    }

    public IEnumerator EntrarBatalha()
    {
        changeCam = true;
        //for (int i = 0; i < 8 ; i++)
        //{
        //    painel.color = new Color(painel.color.r, painel.color.g, painel.color.b, 1f);
        //    yield return new WaitForSeconds(0.1f);
        //    painel.color = new Color(painel.color.r, painel.color.g, painel.color.b, 0f);
        //    yield return new WaitForSeconds(0.1f);
        //}
        painel.color = new Color(painel.color.r, painel.color.g, painel.color.b, 1f);
        yield return new WaitForSeconds(0.3f);

        cam = !cam;
        overworldCam.enabled = cam;
        battleCam.enabled = !cam;
        //playerObj.transform.position = new Vector2(battleCam.transform.position.x, battleCam.transform.position.y);

        yield return new WaitForSeconds(0.2f);

        painel.color = new Color(painel.color.r, painel.color.g, painel.color.b, 0f);
        yield return new WaitForSeconds(0.1f);


        changeCam = false;

    }

    public IEnumerator SairBatalha()
    {
        changeCam = true;
        painel.color = new Color(painel.color.r, painel.color.g, painel.color.b, 1f);
        yield return new WaitForSeconds(0.1f);

        cam = !cam;
        overworldCam.enabled = cam;
        battleCam.enabled = !cam;
        //playerObj.transform.position = new Vector2(overworldCam.transform.position.x, overworldCam.transform.position.y);

        yield return new WaitForSeconds(0.2f);

        painel.color = new Color(painel.color.r, painel.color.g, painel.color.b, 0f);
        yield return new WaitForSeconds(0.1f);

        changeCam = false;
    }
}
