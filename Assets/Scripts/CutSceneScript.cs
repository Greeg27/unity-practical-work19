using Cinemachine;
using System.Collections;
using TMPro;
using UnityEngine;

public class CutSceneScript : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera cam1;
    [SerializeField] CinemachineVirtualCamera cam2;
    [SerializeField] GameObject FishTalkPanel;
    [SerializeField] GameObject GirlTalkPanel;
    [SerializeField] TMP_Text GirlTalk;
    [SerializeField] SpriteRenderer Girl;
    [SerializeField] GameManagerScript gameManagerScript;

    private bool activ;
    private int TalkIndix;
    private string[] GirlTalks = { "Рыбка", "Рыбка!", "Чомолчиш?", "Рыбка?", "РЫБКААА!!" };

    public void TalkGo()
    {
        StartCoroutine(TalkTime());
    }

    private void ChangePriority()
    {
        int priority = cam1.Priority;
        cam1.Priority = cam2.Priority;
        cam2.Priority = priority;
    }

    private void ChangePanel()
    {
        activ = !activ;

        if (!activ)
        {
            ChangeText();
        }

        FishTalkPanel.SetActive(activ);
        GirlTalkPanel.SetActive(!activ);
    }

    private void ChangeText()
    {
        GirlTalk.text = GirlTalks[TalkIndix];
        TalkIndix++;

        if (TalkIndix == 4)
        {
            SpriteFlip();
        }
    }

    private void SpriteFlip()
    {
        Girl.flipX = false;
    }

    IEnumerator TalkTime()
    {
        for (int i = 0; i < 10; i++)
        {
            yield return new WaitForSeconds(3);
            ChangePriority();
            yield return new WaitForSeconds(2);
            ChangePanel();
        }
        yield return new WaitForSeconds(3);
        gameManagerScript.NextLevel();
    }
        
}
