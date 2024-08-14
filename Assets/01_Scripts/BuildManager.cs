using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Apple.ReplayKit;

public class BuildManager : MonoBehaviour  // 빌드를 총관리 해주는 애 얘는 한명밖에없어야해 
{
    public static BuildManager Instance;

    private void Awake()
    {
        Instance = this; // Instance는 ItemManager 클래스의 유일한 인스턴스를 참조 (싱글톤 패턴)
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
            Debug.Log("건물을 지을 수 있습니다.");
            ItemManager.Instance.DecreaseItemCount(item1, itemCount1);
            ItemManager.Instance.DecreaseItemCount(item2, itemCount2);
            return true;
        }
        else
        {
            Debug.Log(item1 + " " + item2 + " 가 부족합니다!");
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
            Debug.Log("건물을 지을 수 있습니다.");
            ItemManager.Instance.DecreaseItemCount(item1, itemCount1);
            ItemManager.Instance.DecreaseItemCount(item2, itemCount2);
            ItemManager.Instance.DecreaseItemCount(item3, itemCount3);
            return true;
        }

        Debug.Log("건물을 지을 수 없습니다.");
        return false;
    }

}
