using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Gamemanager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public StoryNode currentNode;
    [SerializeField] TextMeshProUGUI DisplayText;
    public static TextMeshProUGUI StaticDisplayText;
    public static bool isPaused;
    public static Gamemanager _Instance;
    public static string reEntryNode;
    public string rNodeVis;
    //use on returning the the main scene
    public static bool ReturningFromBattleFlag;
    public static bool WonBattleFlag;
    void Start()
    {
        if (reEntryNode != null)
        {
            Debug.Log("SETTING VIA REENTRY");
            currentNode = GameObject.Find(reEntryNode).GetComponent<StoryNode>();
        }
        if(currentNode != null)
        {
            currentNode.Activate();
        }
        else
        {
            Debug.LogError("Starting story node cannot be unassigned");
        }
    }

    public void Refresh()
    {
        if (reEntryNode != null)
        {
            Debug.Log("SETTING VIA REENTRY");
            currentNode = GameObject.Find(reEntryNode).GetComponent<StoryNode>();
        }
        if (currentNode != null)
        {
            currentNode.Activate();
        }
        else
        {
            Debug.LogError("Starting story node cannot be unassigned");
        }

        DisplayText = GameObject.Find("DisplayText").GetComponent<TextMeshProUGUI>();
    }

    private void Awake()
    {
        DontDestroyOnLoad(this);
        if(_Instance == null)
        {
            _Instance = this;
        }
        else
        {
            if(_Instance != this)
            {
                Destroy(this.gameObject);
            }
        }


        StaticDisplayText = DisplayText;
    }

    // Update is called once per frame
    void Update()
    {
        rNodeVis = reEntryNode;
        if(currentNode == null && !isPaused)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentNode.SelectOption(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentNode.SelectOption(2);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            currentNode.SelectOption(3);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            currentNode.SelectOption(4);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            currentNode.SelectOption(5);
        }
        else if (Input.GetKeyDown(KeyCode.Return))
        {
            currentNode.MoveNext();
        }

        if(currentNode.next != null)
        {
            currentNode = currentNode.next;
            currentNode.Activate();
        }
    }
}
