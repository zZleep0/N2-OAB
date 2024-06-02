using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcProps : MonoBehaviour
{
    [SerializeField] public string dialogo;
    public int dialogoCode;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
