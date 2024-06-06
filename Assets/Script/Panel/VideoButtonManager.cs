using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class VideoButtonManager : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public Button playButton;
    public Button pauseButton;

    void Start()
    {
        playButton.onClick.AddListener(PlayVideo);
        pauseButton.onClick.AddListener(PauseVideo);

        videoPlayer.playOnAwake = false;

        // �ʱ� ���¿��� playButton�� ��Ȱ��ȭ�ϰ� pauseButton�� Ȱ��ȭ
        playButton.gameObject.SetActive(false);
        pauseButton.gameObject.SetActive(true);
    }

    void PauseVideo()
    {
        videoPlayer.Pause();

        // playButton�� Ȱ��ȭ�ϰ� pauseButton�� ��Ȱ��ȭ
        playButton.gameObject.SetActive(true);
        pauseButton.gameObject.SetActive(false);
    }

    void PlayVideo()
    {
        videoPlayer.Play();

        // playButton�� ��Ȱ��ȭ�ϰ� pauseButton�� Ȱ��ȭ
        playButton.gameObject.SetActive(false);
        pauseButton.gameObject.SetActive(true);
    }
}
