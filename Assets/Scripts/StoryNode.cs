using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using UnityEditor;

[System.Serializable]
public class StoryNode : MonoBehaviour
{
    // Start is called before the first frame update
    public int index;
    [SerializeField] public Transform CameraFocus;
    [SerializeField] Transform CamOrbitPoint;
    [SerializeField] public StoryNode Option1;
    [SerializeField] public StoryNode Option2;
    [SerializeField] public StoryNode Option3;
    [SerializeField] public StoryNode Option4;
    [SerializeField] public StoryNode Option5;

    public bool TriggerMinigameScene;
    public int SceneToLoad;
    public bool UseSmallFont;
    

    public StoryNode next;
    [SerializeField] [TextArea] public List<string> Dialogue;
    public int DialogueIndex;
    [SerializeField] GUIStyle style;

    

    
     

    private void Start()
    {
        GetComponent<MeshRenderer>().enabled = false;
    }

   

    public void SelectOption(int optionIndex)//1 through 4
    {
        music.musicPlayer.SelectSound();
        if(!Gamemanager.ReturningFromBattleFlag && TriggerMinigameScene)
        {
            return;
        }
        else if (Gamemanager.ReturningFromBattleFlag && TriggerMinigameScene)
        {
            Gamemanager.ReturningFromBattleFlag = false;
        }
        Gamemanager.StaticDisplayText.color = Color.white;
        switch (optionIndex)
        {
            case 1:
                next = Option1;
                break;
            case 2:
                next = Option2;
                break;
            case 3:
                next = Option3;
                break;
            case 4:
                next = Option4;
                break;
            case 5:
                next = Option4;
                break;
            default:
                break;

        }
        
    }

    public void Activate()
    {
        if (TriggerMinigameScene && !Gamemanager.ReturningFromBattleFlag)
        {
            music.musicPlayer.FadeOut();
            StartCoroutine(LoadSceneDelay());
            
        }
        Gamemanager.StaticDisplayText.fontSize = 15;
        Gamemanager.StaticDisplayText.text = Dialogue[DialogueIndex];

        if (Gamemanager.ReturningFromBattleFlag)
        {
            
            if (Gamemanager.WonBattleFlag)
            {
                Gamemanager.WonBattleFlag = false;
                SelectOption(1);
                Debug.Log("GOING TO WIN OPTION");
            }
            else
            {
                SelectOption(2);
                Debug.Log("GOING TO Lose OPTION");
            }
        }
    }

    private IEnumerator LoadSceneDelay()
    {
        Gamemanager.reEntryNode  = transform.name;
        yield return new WaitForSeconds(3);
        try { SceneManager.LoadScene(SceneToLoad); }
        catch (Exception e)
        {
            Debug.LogError($"Scene load failed. Error code {e}");
        }
    }


    private void OnDrawGizmos()
    { if (TriggerMinigameScene)
            Gizmos.DrawWireSphere(transform.position, 5f);

        if (Option1)
        {
            Debug.DrawLine(transform.position, Option1.transform.position);
        }
        if (Option2)
        {
            Debug.DrawLine(transform.position, Option2.transform.position, Color.red);
        }
        if (Option3)
        {
            Debug.DrawLine(transform.position, Option3.transform.position, Color.blue);
        }
        if (Option4)
        {
            Debug.DrawLine(transform.position, Option4.transform.position, Color.green);
        }
        if (Option5)
        {
            Debug.DrawLine(transform.position, Option5.transform.position, Color.yellow);
        }
        
        
    }

    private void OnDrawGizmosSelected()
    {
        if(Dialogue[0] == "DEADEND")
        {
            style.fontSize = 30;
            style.normal.textColor = Color.red;
        }
        else
        {
            style.normal.textColor = Color.black;
            style.fontSize = 11;
        }
        string displayText = "";
        foreach (string line in Dialogue)
        {
            displayText += line + "\n";
            //Handles.Label(transform.position, displayText, style);
        }
        if (Option1)
        {
            Gizmos.color = Color.white;
            Gizmos.DrawWireSphere(Option1.transform.position,2);
        }
        if (Option2)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(Option2.transform.position, 2);
        }
        if (Option3)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(Option3.transform.position, 2);
        }
        if (Option4)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(Option4.transform.position, 2);
        }
        if (Option5)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(Option5.transform.position, 2);
        }
        

    }

    public void MoveNext()
    {
        //stuff
        music.musicPlayer.SelectSound();
        if (DialogueIndex + 1 >= Dialogue.Count)
        {
            DialogueIndex = 0;
            //Debug.Log("resetti");
        }
        else
        {
            DialogueIndex++;
            //Debug.Log("Index increased my One");
        }
        if(DialogueIndex == Dialogue.Count - 1)
        {
            Gamemanager.StaticDisplayText.color = Color.yellow;
        }
        else
        {
            Gamemanager.StaticDisplayText.color = Color.white;
        }
        if(DialogueIndex == Dialogue.Count - 1 && UseSmallFont)
        {
            Gamemanager.StaticDisplayText.fontSize = 11;
            Gamemanager.StaticDisplayText.text = Dialogue[DialogueIndex];
        }
        else
        {
            Gamemanager.StaticDisplayText.fontSize = 15;
            Gamemanager.StaticDisplayText.text = Dialogue[DialogueIndex];
        }
        
    }
}
