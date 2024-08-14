using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour // 아이템 저장의 역할
{
    public static ItemManager Instance;
        
    public int ideaCount = 0; // ideaCount를 통해 게임 오브젝트의 값을 관리
    public int pureWater = 0;
    public int pollutedWater = 0;
    public int wood = 0;
    public int stone = 0;
    public int metal = 0;

    private void Awake() // 해당 게임 오브젝트가 활성화될 때 가장 먼저 실행되는 부분
    {
        Instance = this; // Instance는 ItemManager 클래스의 유일한 인스턴스를 참조 (싱글톤 패턴)
    }

    private void Update()
    {
        FindObjectOfType<UIManager>().GetComponent<UIManager>().SyncWoodCountText(ItemManager.Instance.wood);
        FindObjectOfType<UIManager>().GetComponent<UIManager>().SyncStoneCountText(ItemManager.Instance.stone);
        FindObjectOfType<UIManager>().GetComponent<UIManager>().SyncMetalCountText(ItemManager.Instance.metal);
    }

    // 아이템의 수량을 반환하는 함수
    public int GetItemCount(string itemName)
    {
        switch (itemName)
        {
            case "wood":
                return wood;
            case "stone":
                return stone;
            case "metal":
                return metal;
            case "pureWater":
                return pureWater;
            case "pollutedWater":
                return pollutedWater;
            case "ideaCount":
                return ideaCount;
            default:
                Debug.LogWarning("Invalid item name: " + itemName);
                return 0;
        }
    }

    // 아이템의 수량을 줄이는 함수
    public void DecreaseItemCount(string itemName, int count)
    {
        switch (itemName)
        {
            case "wood":
                wood = Mathf.Max(wood - count, 0);
                break;
            case "stone":
                stone = Mathf.Max(stone - count, 0);
                break;
            case "metal":
                metal = Mathf.Max(metal - count, 0);
                break;
            case "pureWater":
                pureWater = Mathf.Max(pureWater - count, 0);
                break;
            case "pollutedWater":
                pollutedWater = Mathf.Max(pollutedWater - count, 0);
                break;
            case "ideaCount":
                ideaCount = Mathf.Max(ideaCount - count, 0);
                break;
            default:
                Debug.LogWarning("Invalid item name: " + itemName);
                break;
        }
    }
}
