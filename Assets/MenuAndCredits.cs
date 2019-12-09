using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering.PostProcessing;

public class MenuAndCredits : MonoBehaviour
{
    // Start is called before the first frame update
    bool hasAudioSource;
    bool haspp;
    AudioSource source;
    PostProcessVolume volume;
    ColorGrading grade = null;
    bool loadingNew;
    public bool isInvalidScene;
    [SerializeField] AudioClip clip;
    void Start()
    {
        if (GetComponent<AudioSource>())
        {
            source = GetComponent<AudioSource>();
            hasAudioSource = true;
        }
        else if (GetComponentInChildren<AudioSource>())
        {
            source = GetComponentInChildren<AudioSource>();
            hasAudioSource = true;
        }
        if (GetComponent<PostProcessVolume>())
        {
            volume = GetComponent<PostProcessVolume>();
            haspp = true;
            volume.profile.TryGetSettings(out grade);
            grade.postExposure.value = 0;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !loadingNew)
        {
            if (hasAudioSource)
            {
                source.PlayOneShot(clip,.5f);
            }
            loadingNew = true;
            StartCoroutine(QuitgameSafe());
        }

        if (Input.GetKeyDown(KeyCode.Return) && !loadingNew && !isInvalidScene)
        {
            if (hasAudioSource)
            {
                source.PlayOneShot(clip,.5f);
            }
            loadingNew = true;
            StartCoroutine(LoadSceneSafe());
        }
    }

    public IEnumerator LoadSceneSafe()
    {
        while (hasAudioSource && source.volume > .01f)
        {
            source.volume -= Time.deltaTime * .3f;

            if (haspp)
            {
                grade.postExposure.value -= 3 * Time.deltaTime;
            }

            yield return null;
        }

        SceneManager.LoadScene(1);

    }

    public IEnumerator QuitgameSafe()
    {
        Debug.Log("Quitting");
        while(hasAudioSource && source.volume > .01f )
        {
            source.volume -= Time.deltaTime * .3f;

            if (haspp)
            {
                grade.postExposure.value -= 3 * Time.deltaTime;
            }

            yield return null;
        }
        Application.Quit();
    }
}
