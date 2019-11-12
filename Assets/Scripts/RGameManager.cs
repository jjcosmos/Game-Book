using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RGameManager : MonoBehaviour
{
    public AudioSource music;
    public bool startPlaying;
    public BeatScroller beatScroller;

    public static RGameManager instance;
    public int currentScore;
    public int scorePerNote;
    public int currentMultiplier;
    public int multiplierTracker;
    public int[] multiplierLevels;

    void Start()
    {
        instance = this;
        currentMultiplier = 1;
    }


    void Update()
    {
        if (!startPlaying)
        {
            if (Input.anyKeyDown)
            {
                startPlaying = true;
                beatScroller.hasStarted = true;
                music.Play();
            }
        }
    }

    public void NoteHit()
    {
        if (currentMultiplier - 1 < multiplierLevels.Length)
        {
            multiplierTracker++;
            if (multiplierLevels[currentMultiplier - 1] <= multiplierTracker)
            {
                multiplierTracker = 0;
                currentMultiplier++;
            }
        }

        Debug.Log("Hit");
        currentScore += scorePerNote * currentMultiplier;
    }
    public void NoteMissed()
    {
        Debug.Log("Miss");
    }
}
