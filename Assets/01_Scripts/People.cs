using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class People : MonoBehaviour // 기능의 역할
{
    private float timer = 0f;
    private float interval = 5f; // 5초

    void Start() // 스크립트가 붙은 객체가 활성화될 때 호출됩니다.
    {
        int tagValue = Random.Range(0, 10) < 3 ? 1 : 0; // 30% 확률로 태그 값 결정

        PlayerPrefs.SetInt("SpriteTag", tagValue); // 태그 값을 PlayerPrefs에 저장하거나, 특정 변수에 할당할 수 있습니다.

        if (tagValue == 1) // 태그 값이 1일 때만 코루틴 실행
        {
            StartCoroutine(MakeIdeaRoutine());
        }
    }

    IEnumerator MakeIdeaRoutine() // 태그 값이 1일 때 5초마다 "IDEA"를 생성하는 코루틴
    {
        while (true)
        {
            ItemManager.Instance.ideaCount++;
            FindObjectOfType<UIManager>().GetComponent<UIManager>().SyncIdeaCountText(ItemManager.Instance.ideaCount);

            Debug.Log("IDEA");
            yield return new WaitForSeconds(5f); // 5초 대기
        }
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            ItemManager.Instance.ideaCount++;
            /* GameObject.Find("UIManager").GetComponent<UIManager>().SyncIdeaCountText(ItemManager.Instance.ideaCount); (아래 42번째 코드와 같은 기능)
               게임 오브젝트 중에서 이름이 "UIManager"인 것을 찾고, 그 다음 찾은 오브젝트에서 컴포넌트를 가져온다, 타입이 "UIManager"
               UIManager에서 SyncIdeaCountText 메소드를 가져오고, ItemManager의 ideaCount를 참조 */
            FindObjectOfType<UIManager>().GetComponent<UIManager>().SyncIdeaCountText(ItemManager.Instance.ideaCount);
            /* 게임 오브젝트의 컴포넌트 중에서 타입이 "UIManager"인 것을 찾고, 그것을 가져온다
               UIManager에서 SyncIdeaCountText 메소드를 가져오고, ItemManager의 ideaCount를 참조 */
        }


        // 5초동안 하루가 지나는 코드
        timer += Time.deltaTime;

        if (timer >= interval)
        {
            DailySettlement();
            timer = 0f; // 타이머 초기화
        }
    }

    // "PureWater"를 -3씩 소비하는 코드
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
