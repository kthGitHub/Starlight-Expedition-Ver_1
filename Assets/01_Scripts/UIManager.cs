using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour // ����� ���� �����ִ� ����
{
    public Text ideaCountText;
    public Text pureWaterCountText;
    public Text pollutedWaterCountText;
    public Text woodCountText;
    public Text stoneCountText;
    public Text metalCountText;

    public GameObject settingScreen;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W)) // WŰ�� �����ٸ�
        {
            FindObjectOfType<UIManager>().GetComponent<UIManager>().settingScreen.SetActive(true); // settingScreen�� Ȱ��ȭ

        }
    }


    /* GameObject.Find("UIManager").GetComponent<UIManager>().SyncIdeaCountText(ItemManager.Instance.ideaCount);�� ����� ��,
       ideaCountText.text = count.ToString();���� ���ڸ� ���ڿ��� ��ȯ�Ͽ� �ؽ�Ʈ ������Ʈ�� �ݿ� */
    public void SyncIdeaCountText(int count)
    {
        ideaCountText.text = count.ToString();
    }

    public void SyncPureWaterCountText(int count)
    {
        pureWaterCountText.text = count.ToString();
    }

    public void SyncPollutedWaterCountText(int count)
    {
        pollutedWaterCountText.text = count.ToString();
    }

    public void SyncWoodCountText(int count)
    {
        woodCountText.text = count.ToString();
    }

    public void SyncStoneCountText(int count)
    {
        stoneCountText.text = count.ToString();
    }

    public void SyncMetalCountText(int count)
    {
        metalCountText.text = count.ToString();
    }
}
