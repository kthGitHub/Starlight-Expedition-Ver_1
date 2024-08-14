using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class People : MonoBehaviour // ����� ����
{
    private float timer = 0f;
    private float interval = 5f; // 5��

    void Start() // ��ũ��Ʈ�� ���� ��ü�� Ȱ��ȭ�� �� ȣ��˴ϴ�.
    {
        int tagValue = Random.Range(0, 10) < 3 ? 1 : 0; // 30% Ȯ���� �±� �� ����

        PlayerPrefs.SetInt("SpriteTag", tagValue); // �±� ���� PlayerPrefs�� �����ϰų�, Ư�� ������ �Ҵ��� �� �ֽ��ϴ�.

        if (tagValue == 1) // �±� ���� 1�� ���� �ڷ�ƾ ����
        {
            StartCoroutine(MakeIdeaRoutine());
        }
    }

    IEnumerator MakeIdeaRoutine() // �±� ���� 1�� �� 5�ʸ��� "IDEA"�� �����ϴ� �ڷ�ƾ
    {
        while (true)
        {
            ItemManager.Instance.ideaCount++;
            FindObjectOfType<UIManager>().GetComponent<UIManager>().SyncIdeaCountText(ItemManager.Instance.ideaCount);

            Debug.Log("IDEA");
            yield return new WaitForSeconds(5f); // 5�� ���
        }
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            ItemManager.Instance.ideaCount++;
            /* GameObject.Find("UIManager").GetComponent<UIManager>().SyncIdeaCountText(ItemManager.Instance.ideaCount); (�Ʒ� 42��° �ڵ�� ���� ���)
               ���� ������Ʈ �߿��� �̸��� "UIManager"�� ���� ã��, �� ���� ã�� ������Ʈ���� ������Ʈ�� �����´�, Ÿ���� "UIManager"
               UIManager���� SyncIdeaCountText �޼ҵ带 ��������, ItemManager�� ideaCount�� ���� */
            FindObjectOfType<UIManager>().GetComponent<UIManager>().SyncIdeaCountText(ItemManager.Instance.ideaCount);
            /* ���� ������Ʈ�� ������Ʈ �߿��� Ÿ���� "UIManager"�� ���� ã��, �װ��� �����´�
               UIManager���� SyncIdeaCountText �޼ҵ带 ��������, ItemManager�� ideaCount�� ���� */
        }


        // 5�ʵ��� �Ϸ簡 ������ �ڵ�
        timer += Time.deltaTime;

        if (timer >= interval)
        {
            DailySettlement();
            timer = 0f; // Ÿ�̸� �ʱ�ȭ
        }
    }

    // "PureWater"�� -3�� �Һ��ϴ� �ڵ�
    void DailySettlement()
    {
        ItemManager.Instance.pureWater -= 3;
        FindObjectOfType<UIManager>().GetComponent<UIManager>().SyncPureWaterCountText(ItemManager.Instance.pureWater);

        ItemManager.Instance.pollutedWater += 3;
        FindObjectOfType<UIManager>().GetComponent<UIManager>().SyncPollutedWaterCountText(ItemManager.Instance.pollutedWater);
    }

    void OnMouseDown()
    {
        transform.GetChild(0).gameObject.SetActive(true);
    }
}
