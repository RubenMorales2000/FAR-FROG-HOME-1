using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class script2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject camera = GameObject.Find("Main Camera");
        UnityEngine.Video.VideoPlayer videoPlayer = camera.GetComponent<UnityEngine.Video.VideoPlayer>();
        videoPlayer.loopPointReached += EndReached;
        videoPlayer.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void EndReached(UnityEngine.Video.VideoPlayer vp)
    {
        SceneManager.LoadScene("2DO NIVEL");
    }
}