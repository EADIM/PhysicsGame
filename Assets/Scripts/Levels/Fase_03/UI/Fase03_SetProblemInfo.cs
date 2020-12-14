using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Fase03_SetProblemInfo : MonoBehaviour
{
    /*
    O objeto deve chegar na plataforma final passando pela plataforma do meio.
    A plataforma do meio está a X metros de distância da plataforma inicial e possui uma área de Y por Z metros.
    A plataforma final está a W metros da plataforma do meio e possui uma área de K por L metros.
    Você pode decidir a aceleração inicial do objeto e o ângulo do pulo. 
    */

    public Fase03_References references;
    private Fase03_GameState gms;
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
        gms = references.GameState.GetComponent<Fase03_GameState>();
        UnitScale = gms.UnitScale;
    }

    public void OnInfoChanged(Fase03_GetProblemInfo gpi){
        SetValues(gpi);
        SetText();
    }

    public void OnInfoChanged(Fase03_GetProblemInfo gpi, string info){
        SetValues(gpi);
        SetText(info);
    }

    public void SetValues(Fase03_GetProblemInfo gpi){
        //DimensaoPlataformaInicial = gpi.GetDimensaoPlataformaInicial();
    }

    private void SetText(){
        string[] sprites = {"<sprite=0>","<sprite=1>", "<sprite=2>"};
        
        info = "" +
           "Se você chegou até aqui assumimos que você completou as outras fases e já está pronto para um desafio um pouco maior.\n" + 
           "O objetivo desta fase é escolher a quantidade de rotações necessárias para que o motor levante o bloco a uma altura que o faça deslizar até o buraco e caia na posição correta.\n" + 
           "O bloco será puxado por uma corda inextensível de massa desprezível e que faz parte de um conjunto de polias ideais, conforme a figura.\n" +  "\n\n\n\n" + 
           sprites[0] + "\n\n\n\n\n" + 
           "Há três polias no total, uma fixa (1), sendo na verdade um motor que irá puxar a corda. Uma polia móvel (2), para oferecer ganho mecânico, e uma última polia fixa (3) para direcionar a força. Despreze a força de atrito nas polias.\n" + 
           "Considere que o plano inclinado de 40m está a um ângulo de 21° com o piso e que a base inicial em que a caixa se encontrava tem 4m de comprimento.\n" + "\n\n\n\n" + 
           sprites[1] + "\n\n\n\n\n" + 
           "Finalizada as rotações do motor, a corda irá se romper fazendo com que bloco deslize pelo plano inclinado e pelo piso. O coeficiente de atrito dinâmico entre o bloco e a plataforma que ele está vale 0,3.\n" + 
           "Caso o objeto ultrapasse o piso e caia, sua função será acertar o alvo que está a uma distância horizontal de 4,4m e uma distância vertical de 4,9m do piso. Despreze a resistência do ar.\n" + "\n\n\n\n" + 
           sprites[2] + "\n\n\n\n";

        textUI.text = info;
    }

    private void SetText(string info){
        
        string[] sprites = {"<sprite=0>","<sprite=1>", "<sprite=2>"};
        
        textUI.text = info;
    }
}
