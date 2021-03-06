﻿using System.Collections;
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
    
    private string info;
    private Dictionary<string, string> Imagens = new Dictionary<string, string>();

    private float UnitScale = 0.0f;

    private void Awake() {
    
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
        string[] sprites = {"<sprite=0>","<sprite=1>"};
        
        info = "" +
           "O objetivo desta fase é apertar o botão do outro lado da plataforma. Mas, devido a altura da plataforma, o robô teve a brilhante ideia de ajustar o seu corpo ao formato de uma bola e se arremessar por uma alavanca\n" +
           "Sua função é definir a massa da caixa para que ela aplique uma força na alavanca e arremesse o robô no botão. Esta caixa está a 51m de altura em relação a alavanca.\n" + "\n\n\n" +
           sprites[1] + "\n\n\n\n" +
           "Considere que o botão está a uma distância horizontal de A =  221,5m em relação ao robô e a 17,3m de altura em relação ao solo.\n" + "\n\n\n" +
           sprites[0] + "\n\n\n\n" +
           "O robô possui uma massa aleatória (apresentada no canto superior esquerdo), considere que o mesmo sempre percorre a distância horizontal máxima condizente com a sua velocidade inicial.\n";

        textUI.text = info;
    }

    private void SetText(string info){
        
        string[] sprites = {"<sprite=0>","<sprite=1>"};
        
        textUI.text = info;
    }
}
