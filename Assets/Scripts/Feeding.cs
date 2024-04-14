using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Feeding : MonoBehaviour
{
    [SerializeField] private Quest quest;
    [SerializeField] private float timing1;
    [SerializeField] private float timing2;
    [SerializeField] private int sceneId;
    [SerializeField] private bool load;

    private void Start()
    {
        QuestSystem.Instance.OnChangeQuest.AddListener(Some);
    }

    private void Some(int id)
    {
        if (id == quest.Id)
        {
            StartCoroutine(Some1());
        }
    }

    IEnumerator Some1()
    {
        yield return new WaitForSeconds(timing1);
        QuestSystem.Instance.NextQuest();
        yield return new WaitForSeconds(timing2);
        if(load)SceneManager.LoadScene(sceneId);
    }
}
