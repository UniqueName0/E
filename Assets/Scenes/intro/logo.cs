using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class logo : MonoBehaviour
{
    private VideoPlayer logoPlayer;

    // Start is called before the first frame update
    void Start()
    {
        this.logoPlayer = GetComponent<VideoPlayer>();

        this.logoPlayer.loopPointReached += LogoEnd;
    }

    void LogoEnd(VideoPlayer vp)
    {
        SceneManager.LoadScene("title", LoadSceneMode.Single);
    }


}
