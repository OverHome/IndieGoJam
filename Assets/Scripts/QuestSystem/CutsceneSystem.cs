using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class CutsceneSystem : MonoBehaviour
{
    [SerializeField] private RawImage rawImage;
    [SerializeField] private VideoPlayer videoPlayer;
    [SerializeField] private List<Cutscene> cutscenes;
    
    private void Start()
    {
        QuestSystem.Instance.OnChangeQuest.AddListener(TryPlay);
        TryPlay(QuestSystem.Instance.GetQuestId());
    }

    private void TryPlay(int id)
    {
        foreach (var cutscene in cutscenes)
        {
            if (cutscene.Quest.Id == id)
            {
                rawImage.enabled = true;
                videoPlayer.enabled = true;
                videoPlayer.clip = cutscene.Video;
                videoPlayer.loopPointReached += EndReached;
                break;
            }
        }
    }

    private void EndReached(VideoPlayer source)
    {
        rawImage.enabled = false;
        videoPlayer.enabled = false;
        videoPlayer.loopPointReached -= EndReached;
    }
}
