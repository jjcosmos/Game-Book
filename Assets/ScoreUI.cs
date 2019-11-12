using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI Score_Text;
    
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        Score_Text.text = $"Score: {RGameManager.visibleBossHealth}";   
    }
}
