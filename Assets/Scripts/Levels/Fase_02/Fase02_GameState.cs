using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Fase02_GameState : MonoBehaviour
{
    public Fase02_References references;
    private GameObject Player;
    private Canvas Canvas;
    private ToggleCamera_fase02 ToggleCamera;
    private Fase02_GetProblemInfo getProblemInfo;
    public Dictionary<string, bool> States = new Dictionary<string, bool>();

    public string currentState = "Start";
    public string previousState = "Exploration";

    private readonly string SimulationName = "Simulation";
    private readonly string ExplorationName = "Exploration";
    private readonly string WinName = "Win";
    private readonly string LostName = "Lost";
    private readonly string PauseName = "Pause";
    private readonly string StartName = "Start";
    private ToggleUIElement inputfieldUI;
    public float UnitScale = 0.91177873f; //the amount of units to relative to a meter. (prev = 0.5492f, 1.111436f)

    public bool pausedFromUI = false;

    public bool FirstExplanationWindow = false;
    public Transform[] listPosition;


    private void Awake()
    {
        InitializeStates();    
        //Application.targetFrameRate = 60;
    }
    
    private void Start() 
    {
        listPosition = new Transform[5];
        listPosition[0] = copyTransform(references.Ball.transform);
        listPosition[1] = copyTransform(references.Box.transform);
        listPosition[2] = copyTransform(references.Seesaw.transform);
        listPosition[3] = copyTransform(references.Seesaw_Base.transform);
        listPosition[4] = copyTransform(references.Seesaw_Support.transform);
        //UnitScale = 0.54f;
        Canvas = references.Canvas.GetComponent<Canvas>();
        getProblemInfo = transform.GetComponent<Fase02_GetProblemInfo>();
        SwitchState(getStartName());
    }

    private void Update()
    {
        
    }


    public void SwitchState(string newState)
    {
        //Debug.Log("State switched to " + newState, this);
        Dictionary<string, bool>.KeyCollection kc = States.Keys;

        foreach(string key in kc.ToList())
        {
            States[key] = false;
        }

        States[newState] = true;

        if(newState != currentState)
        {
            previousState = currentState;
        }
        currentState = newState;

        if (newState == getExplorationName())
        {
            changeExploration();
        }
        else if (newState == getSimulationName())
        {
            changeSimulation();
        }
        else if (newState == getLostName())
        {
            changeLost();
        }
        else if (newState == getWinName())
        {
            changeWin();
        }
        else if (newState == getPauseName())
        {
            changePause();
        }
        else if (newState == getStartName())
        {
            changeStart();
        }
    }

    public void resetTransform(GameObject src, Transform target, Rigidbody rb)
    {
        if(rb){
            rb.isKinematic = true;
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
        
        src.transform.localPosition = target.localPosition;
        src.transform.localRotation = target.localRotation;
        if (rb) rb.isKinematic=false;
    }

    public Transform copyTransform(Transform src){
        GameObject empty = new GameObject();
        Transform target = empty.transform;
        target.localPosition = src.localPosition;
        target.localRotation = src.localRotation;
        return target;
    }

    public void ResetValues()
    {
        //GameObject Fase02_Timer =  Utils.GetChildWithName(Canvas.gameObject, "Timer");
        //Fase02_Timer.GetComponent<Fase02_Timer>().Reset();
        references.Box.GetComponent<Fase02_BoxCollider>().colidiu = false;
        references.Player.GetComponent<Fase02_PlayerController>().setBallMass();
        Debug.Log("Inicial: " + listPosition[0].localPosition);
        resetTransform(references.Seesaw, listPosition[2], references.Seesaw.GetComponent<Rigidbody>());
        resetTransform(references.Seesaw_Base, listPosition[3], references.Seesaw_Base.GetComponent<Rigidbody>());
        resetTransform(references.Seesaw_Support, listPosition[4], references.Seesaw_Support.GetComponent<Rigidbody>());
        resetTransform(references.Ball, listPosition[0], references.Ball.GetComponent<Rigidbody>());
        resetTransform(references.Box, listPosition[1], references.Box.GetComponent<Rigidbody>());
        Transform obj = references.ExplorerCamera.GetComponent<Fase02_BackupTransform>().obj;
        Debug.Log("OI " + obj.localPosition.x + " " + obj.localPosition.y + " " + obj.localPosition.z);
        resetTransform(references.ExplorerCamera, references.ExplorerCamera.GetComponent<Fase02_BackupTransform>().obj, null);
    }

    private void changeExploration()
    {
        ResumeUIElements();
        ResetValues();
        GameObject levelStats = Utils.GetChildWithName(Canvas.gameObject, "Level Stats");
        levelStats.GetComponent<ToggleUIElement>().Show();
        GameObject explanationContainer = Utils.GetChildWithName(Canvas.gameObject, "Explanation Container");
        explanationContainer.GetComponent<ToggleUIElement>().Hide();
        GameObject buttons = Utils.GetChildWithName(Canvas.gameObject, "Buttons");
        GameObject buttons_helpButton = Utils.GetChildWithName(buttons, "Help");
        buttons_helpButton.GetComponent<ToggleUIElement>().Show();
        GameObject buttons_playButton = Utils.GetChildWithName(buttons, "Play Button");
        GameObject buttons_playButton_text = Utils.GetChildWithName(buttons_playButton, "Text");
        buttons_playButton_text.GetComponent<TMPro.TMP_Text>().text = "PLAY";
        /*GameObject joysticks_container = Utils.GetChildWithName(Canvas.gameObject, "Joysticks Container");
        joysticks_container.GetComponent<ToggleUIElement>().Show();*/

        if(GetComponent<ToggleCamera_fase02>().currentCamera.name == "Explorer Camera"){
            GameObject joysticks_container = Utils.GetChildWithName(Canvas.gameObject, "Joysticks Container");
            joysticks_container.GetComponent<ToggleUIElement>().Show();
        }
        UnfreezeUI();
        pausedFromUI = false;
    }

    private void changeSimulation()
    {
        ResumeUIElements();
        GameObject joysticks_container = Utils.GetChildWithName(Canvas.gameObject, "Joysticks Container");
        joysticks_container.GetComponent<ToggleUIElement>().Hide();
        GameObject levelStats = Utils.GetChildWithName(Canvas.gameObject, "Level Stats");
        levelStats.GetComponent<ToggleUIElement>().Show();
        GameObject buttons = Utils.GetChildWithName(Canvas.gameObject, "Buttons");
        GameObject buttons_helpButton = Utils.GetChildWithName(buttons, "Help");
        buttons_helpButton.GetComponent<ToggleUIElement>().Hide();
        GameObject buttons_playButton = Utils.GetChildWithName(buttons, "Play Button");
        GameObject buttons_playButton_text = Utils.GetChildWithName(buttons_playButton.gameObject, "Text");
        buttons_playButton_text.GetComponent<TMPro.TMP_Text>().text = "STOP";
        GameObject inputField = Utils.GetChildWithName(Canvas.gameObject, "Input Container");
        TMPro.TMP_InputField textMesh = Utils.GetChildWithName(inputField, "Massa da Caixa").GetComponent<TMPro.TMP_InputField>();
        textMesh.text = "";
        inputField.GetComponent<ToggleUIElement>().Hide();
    }

    private void changePause()
    {
        pausedFromUI = true;
        GamePause.PauseGame();
        PauseUIElements();
    }

    private void changeLost()
    {
        ResetValues();
        SwitchState(getExplorationName());
    }

    private void changeWin()
    {
        GameObject buttons = Utils.GetChildWithName(Canvas.gameObject, "Buttons");
        buttons.GetComponent<ToggleUIElement>().Hide();
        //inputfieldUI.Hide();
        GameObject levelStats = Utils.GetChildWithName(Canvas.gameObject, "Level Stats");
        levelStats.GetComponent<ToggleUIElement>().Hide();
        GameObject joysticks_container = Utils.GetChildWithName(Canvas.gameObject, "Joysticks Container");
        joysticks_container.GetComponent<ToggleUIElement>().Hide();
        GameObject winnerWindow = Utils.GetChildWithName(Canvas.gameObject, "Winner Window");
        winnerWindow.GetComponent<ToggleUIElement>().Show();
        GameObject TimeText = Utils.GetChildWithName(winnerWindow.gameObject, "Time Taken");
        GameObject Fase02_Timer =  Utils.GetChildWithName(Canvas.gameObject, "Timer");
        string text = "Tempo tomado: ";
        text = text + Fase02_Timer.GetComponent<TMPro.TMP_Text>().text;
        TimeText.GetComponent<TMPro.TMP_Text>().text = text;
        GamePause.PauseGame();
    }

    public void tryAgain(){
        ResetValues();
        GameObject Fase02_Timer =  Utils.GetChildWithName(Canvas.gameObject, "Timer");
        Fase02_Timer.GetComponent<Fase02_Timer>().Reset();
        currentState = getStartName();
        previousState = getExplorationName();
        SwitchState(getStartName());
    }

    private void changeStart()
    {
        FreezeUI();
        pausedFromUI = true;
        GamePause.PauseGame();
        ResumeUIElements();
        GameObject buttons = Utils.GetChildWithName(Canvas.gameObject, "Buttons");
        FreezeElement(buttons);
        GameObject buttons_helpButton = Utils.GetChildWithName(buttons, "Help");
        buttons_helpButton.GetComponent<ToggleUIElement>().Hide();
        GameObject explanationContainer = Utils.GetChildWithName(Canvas.gameObject, "Explanation Container");
        explanationContainer.GetComponent<ToggleUIElement>().Show();
        getProblemInfo.OnVariablesChange();
        references.QuestionInfo.GetComponent<Fase02_SetProblemInfo>().OnInfoChanged(getProblemInfo);
        references.ExplanationInfo.GetComponent<Fase02_SetProblemInfo>().OnInfoChanged(getProblemInfo);
        GameObject ball = references.Ball.gameObject;
        Fase02_PlayerController ballCont = ball.GetComponent<Fase02_PlayerController>();
        ballCont.setBallMass();
    }

    private void PauseUIElements()
    {
        GameObject buttons = Utils.GetChildWithName(Canvas.gameObject, "Buttons");
        buttons.GetComponent<ToggleUIElement>().Hide();
        //inputfieldUI.Hide();
        GameObject joysticks_container = Utils.GetChildWithName(Canvas.gameObject, "Joysticks Container");
        joysticks_container.GetComponent<ToggleUIElement>().Hide();
        GameObject pauseMenu = Utils.GetChildWithName(Canvas.gameObject, "Pause Menu");
        pauseMenu.GetComponent<ToggleUIElement>().Show();
    }

    private void ResumeUIElements()
    {
        GetComponent<Fase02_ToggleInputField>().canShow = true;
        GamePause.ResumeGame();
        GameObject buttons = Utils.GetChildWithName(Canvas.gameObject, "Buttons");
        buttons.GetComponent<ToggleUIElement>().Show();
        GameObject pauseMenu = Utils.GetChildWithName(Canvas.gameObject, "Pause Menu");
        pauseMenu.GetComponent<ToggleUIElement>().Hide();

    }

    public void FreezeUI()
    {
        GameObject buttons = Utils.GetChildWithName(Canvas.gameObject, "Buttons");
        FreezeElement(buttons);
        GameObject joysticks_container = Utils.GetChildWithName(Canvas.gameObject, "Joysticks Container");
        FreezeElement(joysticks_container);
    }

    private void FreezeElement(GameObject elem)
    {
        Utils.Freeze(elem.GetComponent<CanvasGroup>());
    }

    public void UnfreezeUI()
    {
        GameObject buttons = Utils.GetChildWithName(Canvas.gameObject, "Buttons");
        UnfreezeElement(buttons);
        GameObject joysticks_container = Utils.GetChildWithName(Canvas.gameObject, "Joysticks Container");
        UnfreezeElement(joysticks_container);
    }

    private void UnfreezeElement(GameObject elem)
    {
        Utils.Unfreeze(elem.GetComponent<CanvasGroup>());
    }

    public void SwitchToPreviousState()
    {
        SwitchState(previousState);
    }

    private void InitializeStates()
    {
        States.Add(getStartName(), true);
        States.Add(getExplorationName(), false);
        States.Add(getSimulationName(), false);
        States.Add(getLostName(), false);
        States.Add(getWinName(), false);
        States.Add(getPauseName(), false);
    }


    public void GS_SwitchCameras(){
        ToggleCamera.switchCameras();
        string text = ToggleCamera.getActiveCameraName() + " selecionada.";
        ShowMessage(text, Canvas.gameObject, "Message Container", "Action Message", new Color(154.0f/255.0f,0,0,1));
    }

    public void ShowMessage(string msg, GameObject canvas, string message_container_name, string action_message_name, Color color){
        GameObject MessageContainer = Utils.GetChildWithName(canvas, message_container_name);
        GameObject message = Utils.GetChildWithName(MessageContainer, action_message_name);
        TMPro.TMP_Text messageTMP = message.GetComponent<TMPro.TMP_Text>();
        messageTMP.text = msg;
        messageTMP.color = color;
        ToggleUIElement MessageContainerUI = MessageContainer.GetComponent<ToggleUIElement>();
        MessageContainerUI.Show();
        StartCoroutine(HideMessage(4.0f, MessageContainerUI));
    }

    private IEnumerator HideMessage(float waitTime, ToggleUIElement uiElem)
    {
        yield return new WaitForSecondsRealtime(waitTime);
        uiElem.Hide();
    }


    public string getSimulationName()
    {
        return SimulationName;
    }

    public string getExplorationName()
    {
        return ExplorationName;
    }

    public string getLostName()
    {
        return LostName;
    }

    public string getWinName()
    {
        return WinName;
    }

    public string getPauseName()
    {
        return PauseName;
    }

    public string getStartName()
    {
        return StartName;
    }



    public void setFirstExplanationWindow(bool value)
    {
        FirstExplanationWindow = value;
    }
}
