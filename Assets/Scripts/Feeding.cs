using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Feeding : MonoBehaviour
{
    [SerializeField] private Quest quest;

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
        yield return new WaitForSeconds(2);
        QuestSystem.Instance.NextQuest();
        yield return new WaitForSeconds(21);
        SceneManager.LoadScene(1);
    }
}
