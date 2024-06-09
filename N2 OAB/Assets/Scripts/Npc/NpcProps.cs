using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcProps : MonoBehaviour
{
    [SerializeField] public string dialogo;
    public int dialogoCode;
    public InteractionController interactionController;

    // Start is called before the first frame update
    void Start()
    {
        interactionController = GameObject.Find("InteractController").GetComponent<InteractionController>();
    }

    // Update is called once per frame
    void Update()
    {
        MudaDialogo();
    }
    public void AtualizaDialogo()
    {
        switch (dialogoCode)
        {
            case 1:
                dialogo = "Ola, aventureiro, você pode se mover com WASD e P para ver seus pokemons";
                break;
            case 2:
                dialogo = "Soube que ao norte existe mais uma cidade";
                break;
            case 3:
                dialogo = "Cuidado com os treinadores, eles são muito perigosos";
                break;
            //case 4:
            //    dialogo = "Para ver seus pokemons, aperte P";
            //    break;
            default:
                dialogo = "Oi";
                break;
        }
    }

    public void MudaDialogo()
    {
        if (dialogoCode == 1 && Input.GetKeyDown(KeyCode.Space))
        {
            dialogo = "Ao sudoeste você pode encontrar uma cidade";
            interactionController.textoNpc.text = dialogo;
        }
    }
}
