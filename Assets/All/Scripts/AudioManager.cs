using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioSource audioSourceBGM;
    public AudioSource audioSourceSE;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            Initialize();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Initialize()
    {
        audioSourceBGM = gameObject.AddComponent<AudioSource>();
        audioSourceSE = gameObject.AddComponent<AudioSource>();
        audioSourceBGM.volume = .3f;
        audioSourceBGM.loop = true;
        audioSourceSE.volume = .5f;
    }

    public void PlayBGM(AudioClip audioClip)
    {
        //Debug.Assert(audioClip);
        audioSourceBGM.Stop();
        audioSourceBGM.clip = audioClip;
        audioSourceBGM.Play();
    }

    public void PlaySE(AudioClip audioClip)
    {
        //Debug.Assert(audioClip);
        audioSourceSE.PlayOneShot(audioClip);
    }
}
