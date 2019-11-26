using System.Collections;
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
                StartCoroutine(NoteDestroyFX());
                //gameObject.SetActive(false);
            }
            
        }
    }

    private IEnumerator NoteDestroyFX()
    {
        float i = 0;
        while(transform.localScale.x < 3)
        {
            Debug.Log("Loop");
            transform.localScale = new Vector3( transform.localScale.x + Time.deltaTime * 3, transform.localScale.y + Time.deltaTime * 3, 1);
            rend.color = Color.Lerp(Color.white, Color.clear, i);
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
            canBePressed = true;
            if (isEndTrigger) { 
                RGameManager.instance.EndLevelAndLoadNext();
                Gamemanager.WonBattleFlag = true;
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
            }
        }
    }
}
