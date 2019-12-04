﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteObj : MonoBehaviour
{
    // Start is called before the first frame update
    public bool canBePressed;
    public bool isEndTrigger;
    public KeyCode keyToPress;
    private bool Cleared;
    private SpriteRenderer rend;
    
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keyToPress))
        {
            if (canBePressed)
            {

                RGameManager.instance.NoteHit();
                Cleared = true;
                rend.color = Color.green;
                StartCoroutine(NoteDestroyFX());
                
                //gameObject.SetActive(false);
            }
            
        }
        
    }

    private IEnumerator NoteDestroyFX()
    {
        Color StartColor = rend.color;
        float i = 0;
        while(transform.localScale.x < 3)
        {
            Debug.Log("Loop");
            transform.localScale = new Vector3( transform.localScale.x + Time.deltaTime * 3, transform.localScale.y + Time.deltaTime * 3, 1);
            rend.color = Color.Lerp(StartColor, Color.clear, i);
            i += Time.deltaTime * 3;
            yield return null;
        }
        rend.enabled = false;
        transform.localScale = Vector3.one;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Activator"))
        {
            rend.color = Color.cyan;
            canBePressed = true;
            if (isEndTrigger) {
                Gamemanager.WonBattleFlag = true;
                RGameManager.instance.EndLevelAndLoadNext();
                
                Debug.Log("WINNNNN");
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Activator"))
        {
            canBePressed = false;
            if (!Cleared)
            {
                RGameManager.instance.NoteMissed();
                rend.color = Color.red;
            }
        }
    }
}
