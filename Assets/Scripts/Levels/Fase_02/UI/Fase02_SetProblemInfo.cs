using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Fase02_SetProblemInfo : MonoBehaviour
{
    /*
    O objeto deve chegar na plataforma final passando pela plataforma do meio.
    A plataforma do meio está a X metros de distância da plataforma inicial e possui uma área de Y por Z metros.
    A plataforma final está a W metros da plataforma do meio e possui uma área de K por L metros.
    Você pode decidir a aceleração inicial do objeto e o ângulo do pulo. 
    */

    public Fase02_References references;
    private Fase02_GameState gms;
    public TMPro.TMP_Text textUI;

    [SerializeField]
    private string format = "#.##";

    [SerializeField]
    private Vector3 DimensaoPlataformaInicial = Vector3.zero;
    [SerializeField]
    private Vector3 DimensaoPlataformaFinal = Vector3.zero;
    [SerializeField]
    
    private string info;
    private Dictionary<string, string> Imagens = new Dictionary<string, string>();

    private float UnitScale = 0.0f;

    private void Awake() {
        InitializeImagens();
    }

    private void Start() {
        gms = references.GameState.GetComponent<Fase02_GameState>();
        UnitScale = gms.UnitScale;
    }

    public void OnInfoChanged(Fase02_GetProblemInfo gpi){
        SetValues(gpi);
        SetText();
    }

    public void OnInfoChanged(Fase02_GetProblemInfo gpi, string info){
        SetValues(gpi);
        SetText(info);
    }

    public void SetValues(Fase02_GetProblemInfo gpi){
        //DimensaoPlataformaInicial = gpi.GetDimensaoPlataformaInicial();
    }

    private void SetText(){
        string[] sprites = {"<sprite=0>","<sprite=1>","<sprite=2>"};
        
        info = "" +
            "O robô deve chegar na plataforma final passando pela plataforma do meio." +
            "\nEle inicia seu movimento na plataforma inicial e deve percorrer uma distância de D = " + " metros até pular." +
            "\n" + sprites[2] + "\n\n\n\n\n\n\n\n\n" +
            "\nA plataforma do meio está a uma distância W = " + " metros do ponto do pulo e possui " + " metros de largura e " + " metros de comprimento." +
            "\n" + sprites[0] + "\n\n\n\n\n\n\n\n\n" +
            "\nA plataforma final está a uma distância K = " + " metros da plataforma do meio." +
            "\n" + sprites[1] + "\n\n\n\n\n\n\n\n\n" +
            "\nVocê pode controlar as variáveis de aceleração e de ângulo do pulo." +
            "\nQuando o robô estiver na plataforma inicial, a aceleração é constante até o momento do pulo." +
            "";

        textUI.text = info;
    }

    private void SetText(string info){
        
        string[] sprites = {Imagens["InitialAndMidPlatform"], Imagens["MidAndFinalPlatform"], Imagens["InitialPlatform01"]};
        
        textUI.text = info;
    }

    private void InitializeImagens(){
        Imagens.Add("InitialAndMidPlatform", "<sprite=0>");
        Imagens.Add("MidAndFinalPlatform", "<sprite=1>");
        Imagens.Add("InitialPlatform01", "<sprite=2>");
        Imagens.Add("InitialPlatform02", "<sprite=3>");
    }
}
