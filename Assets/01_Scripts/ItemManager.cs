using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour // ������ ������ ����
{
    public static ItemManager Instance;
        
    public int ideaCount = 0; // ideaCount�� ���� ���� ������Ʈ�� ���� ����
    public int pureWater = 0;
    public int pollutedWater = 0;
    public int wood = 0;
    public int stone = 0;
    public int metal = 0;

    private void Awake() // �ش� ���� ������Ʈ�� Ȱ��ȭ�� �� ���� ���� ����Ǵ� �κ�
    {
        Instance = this; // Instance�� ItemManager Ŭ������ ������ �ν��Ͻ��� ���� (�̱��� ����)
    }

    private void Update()
    {
        FindObjectOfType<UIManager>().GetComponent<UIManager>().SyncWoodCountText(ItemManager.Instance.wood);
        FindObjectOfType<UIManager>().GetComponent<UIManager>().SyncStoneCountText(ItemManager.Instance.stone);
        FindObjectOfType<UIManager>().GetComponent<UIManager>().SyncMetalCountText(ItemManager.Instance.metal);
    }

    // �������� ������ ��ȯ�ϴ� �Լ�
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

    // �������� ������ ���̴� �Լ�
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
