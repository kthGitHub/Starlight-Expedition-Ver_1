using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour // 저장된 것을 보여주는 역할
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
        if (Input.GetKeyDown(KeyCode.W)) // W키를 누른다면
        {
            FindObjectOfType<UIManager>().GetComponent<UIManager>().settingScreen.SetActive(true); // settingScreen을 활성화

        }
    }


    /* GameObject.Find("UIManager").GetComponent<UIManager>().SyncIdeaCountText(ItemManager.Instance.ideaCount);가 실행될 때,
       ideaCountText.text = count.ToString();에서 숫자를 문자열로 변환하여 텍스트 컴포넌트에 반영 */
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
