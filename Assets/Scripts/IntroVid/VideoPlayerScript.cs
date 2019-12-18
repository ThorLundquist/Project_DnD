using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoPlayerScript : MonoBehaviour
{
    public Image Panel;
    public RawImage image;
    public VideoClip videoToPlay;
    private VideoPlayer videoPlayer;
    private readonly VideoSource videoSource;
 //   private AudioSource audioSource;
    // Use this for initialization
    void Start()
    {
        Application.runInBackground = true;
        StartCoroutine(PlayVideo());
    }

    IEnumerator PlayVideo()
    {
        //Add VideoPlayer to the GameObject
        videoPlayer = gameObject.AddComponent<VideoPlayer>();

        //Disable Play on Awake for both Video and Audio
        videoPlayer.playOnAwake = false;

        //We want to play from video clip not from url
        videoPlayer.source = VideoSource.VideoClip;       

        //Set Audio Output to AudioSource
        videoPlayer.audioOutputMode = VideoAudioOutputMode.AudioSource;

        //Assign the Audio from Video to AudioSource to be played
        videoPlayer.EnableAudioTrack(0, true);

        //Set video To Play
        videoPlayer.clip = videoToPlay;

        videoPlayer.Prepare();
        //Wait until video is prepared

        WaitForSeconds waitTime = new WaitForSeconds(1);
        while (!videoPlayer.isPrepared)
        {
            Debug.Log("Preparing Video");
            //Prepare/Wait for 5 sceonds only
            yield return waitTime;
            //Break out of the while loop after 5 seconds wait
            break;
        }

        Debug.Log("Done Preparing Video");

        //Play Video
        Debug.Log("Playing Video");
        videoPlayer.Play();

        while (videoPlayer.isPlaying)
        {
            Debug.Log("Video Time: " + Mathf.FloorToInt((float)videoPlayer.time));
            yield return null;
        }
        Debug.Log("Done Playing Video");
        SceneManager.LoadScene(3);
    }

    // Update is called once per frame
    void Update()
    {
        if (videoPlayer.time == 5)
        {
            Panel.gameObject.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(3);
        }
    }

}