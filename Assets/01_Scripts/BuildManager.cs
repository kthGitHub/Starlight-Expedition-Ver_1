using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Apple.ReplayKit;

public class BuildManager : MonoBehaviour  // ���带 �Ѱ��� ���ִ� �� ��� �Ѹ�ۿ�������� 
{
    public static BuildManager Instance;

    private void Awake()
    {
        Instance = this; // Instance�� ItemManager Ŭ������ ������ �ν��Ͻ��� ���� (�̱��� ����)
    }

    void Start()
    {

    }

    void Update()
    {
        
    }

    public bool IsBuild(string item1, int itemCount1, string item2, int itemCount2)
    {
        // Assume item1 is wood, item2 is stone, item3 is another resource, etc.
        if (ItemManager.Instance.GetItemCount(item1) >= itemCount1 &&
            ItemManager.Instance.GetItemCount(item2) >= itemCount2)
        {
            Debug.Log("�ǹ��� ���� �� �ֽ��ϴ�.");
            ItemManager.Instance.DecreaseItemCount(item1, itemCount1);
            ItemManager.Instance.DecreaseItemCount(item2, itemCount2);
            return true;
        }
        else
        {
            Debug.Log(item1 + " " + item2 + " �� �����մϴ�!");
        }

        return false;
    }


    public bool IsBuild(string item1, int itemCount1, string item2, int itemCount2, string item3, int itemCount3)
    {
        // Assume item1 is wood, item2 is stone, item3 is another resource, etc.
        if (ItemManager.Instance.GetItemCount(item1) >= itemCount1 &&
            ItemManager.Instance.GetItemCount(item2) >= itemCount2 &&
            ItemManager.Instance.GetItemCount(item3) >= itemCount3)
        {
            Debug.Log("�ǹ��� ���� �� �ֽ��ϴ�.");
            ItemManager.Instance.DecreaseItemCount(item1, itemCount1);
            ItemManager.Instance.DecreaseItemCount(item2, itemCount2);
            ItemManager.Instance.DecreaseItemCount(item3, itemCount3);
            return true;
        }

        Debug.Log("�ǹ��� ���� �� �����ϴ�.");
        return false;
    }

}
