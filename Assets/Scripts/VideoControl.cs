using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoControl : MonoBehaviour
{

    private UnityEngine.Video.VideoPlayer videoPlayer;
    private bool isPaused;
    public double time;
    public double currentTime;
    private VideoSource videoSource;
    private AudioSource audioSource;
    public GameObject ferryButton, pirateButton, playButton, pauseButton;
    [SerializeField]
    int frameCount;


    void Start()
    {
        videoPlayer = GetComponent<UnityEngine.Video.VideoPlayer>();
        StartCoroutine(StreamVideo());
    }

    IEnumerator StreamVideo()
    {
        //Add AudioSource
        audioSource = gameObject.GetComponent<AudioSource>();

        //Disable Play on Awake for both Video and Audio
        videoPlayer.playOnAwake = false;
        audioSource.playOnAwake = false;
        audioSource.Pause();

        //We want to play from video clip not from url

        videoPlayer.source = VideoSource.VideoClip;

        // Vide clip from Url
        videoPlayer.source = VideoSource.Url;
        videoPlayer.url = "https://dl.dropbox.com/s/igb9uquchu0zsjo/PirateFerry2.mp4";


        //Set Audio Output to AudioSource
        videoPlayer.audioOutputMode = VideoAudioOutputMode.AudioSource;

        //Assign the Audio from Video to AudioSource to be played
        videoPlayer.EnableAudioTrack(0, true);
        videoPlayer.SetTargetAudioSource(0, audioSource);
        videoPlayer.Prepare();
        //Wait until video is prepared
        while (!videoPlayer.isPrepared)
        {
            yield return null;
        }

        Debug.Log("Done Preparing Video");

        frameCount = (int)videoPlayer.frameCount;
        //Play Video
        videoPlayer.Play();

        //Play Sound
        audioSource.Play();

        Debug.Log("Playing Video");

        Debug.Log("Done Playing Video");
    }

    //Check if input keys have been pressed and call methods accordingly.
    void Update()
    {
        ControlVideo();
    }

    public void ControlVideo()
    {
        if (videoPlayer.time > 30)
        {
            pirateButton.SetActive(false);
            ferryButton.SetActive(true);
        }
        else
        {
            pirateButton.SetActive(true);
            ferryButton.SetActive(false);
        }

        if (videoPlayer.isPlaying)
        {
            playButton.SetActive(false);
            pauseButton.SetActive(true);
        }
        else
        {
            playButton.SetActive(true);
            pauseButton.SetActive(false);
        }
        if (videoPlayer.isPlaying && (int)videoPlayer.frame >= frameCount)
        {
            SceneManager.LoadScene("Credits");
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }

    public void Play()
    {
        videoPlayer.Play();
    }
    public void Pause()
    {
        videoPlayer.Pause();
    }


    public void SkipFerry()
    {
        videoPlayer.time = 0;
        videoPlayer.Play();
    }

    public void SkipPirate()
    {
        videoPlayer.time = 30;
        videoPlayer.Play();
    }
}