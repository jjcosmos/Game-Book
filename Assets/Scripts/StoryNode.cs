using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

//[System.Serializable]
public class StoryNode : MonoBehaviour
{
    // Start is called before the first frame update
    public int index;
    [SerializeField] public Transform CameraFocus;
    [SerializeField] Transform CamOrbitPoint;
    [SerializeField] StoryNode Option1;
    [SerializeField] StoryNode Option2;
    [SerializeField] StoryNode Option3;
    [SerializeField] StoryNode Option4;

    public bool TriggerMinigameScene;
    public int SceneToLoad;

    public StoryNode next;
    [SerializeField] [TextArea] List<string> Dialogue;
    public int DialogueIndex;

    private void Start()
    {
        
    }

    public void SelectOption(int optionIndex)//1 through 4
    {
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
            default:
                break;

        }
        
    }

    public void Activate()
    {
        if (TriggerMinigameScene)
        {
            StartCoroutine(LoadSceneDelay());
            
        }
        Gamemanager.StaticDisplayText.text = Dialogue[DialogueIndex];
    }

    private IEnumerator LoadSceneDelay()
    {
        yield return new WaitForSeconds(3);
        try { SceneManager.LoadScene(SceneToLoad); }
        catch (Exception e)
        {
            Debug.LogError($"Scene load failed. Error code {e}");
        }
    }


    private void OnDrawGizmos()
    {   if(TriggerMinigameScene)
            Gizmos.DrawWireSphere(transform.position, 5f);
    }

    public void MoveNext()
    {
        //stuff
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
        Gamemanager.StaticDisplayText.text = Dialogue[DialogueIndex];
    }
}
