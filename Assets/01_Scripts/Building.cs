using UnityEngine;

public class Building : MonoBehaviour
{
    public GameObject targetObject;

    // Start is called before the first frame update
    void Start()
    {
    }

    public void BuildLab()
    {
        if (BuildManager.Instance.IsBuild("metal", 5, "stone", 5)) 
        {
            targetObject.SetActive(true); // 스프라이트가 나오지 않음. 
                                          // 모든 건축물에 개별적으로 이런식의 코드를 하나씩 다 입력해야 하는지?
                                          // 또는 BuildManager에서 변수를 배열 형식으로 선언한 다음, 변수에 숫자 대신 인스펙터 창에 스프라이트를 넣고,
                                          // 해당 오브젝트를 프리펩으로 만들지?
            Debug.Log("OO");
        }
    }

    void OnMouseDown()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            if (spriteRenderer != null && spriteRenderer.sprite != null && spriteRenderer.sprite.name == "Lab")
            {
                transform.GetChild(0).gameObject.SetActive(true);
                Debug.Log("Lab!");
            }

            if (spriteRenderer != null && spriteRenderer.sprite != null && spriteRenderer.sprite.name == "Farm")
            {
                transform.GetChild(0).gameObject.SetActive(true);
                Debug.Log("Farm!");
            }
        }
    }

    private float timer = 0f;
    private float interval = 2f; // 5초
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= interval)
        {
            WpWork();
            timer = 0f; // 타이머 초기화
        }
    }

    void WpWork()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            if (spriteRenderer != null && spriteRenderer.sprite != null && spriteRenderer.sprite.name == "Wp")
            {

                ItemManager.Instance.pureWater += 1;
                FindObjectOfType<UIManager>().GetComponent<UIManager>().SyncPureWaterCountText(ItemManager.Instance.pureWater);

                ItemManager.Instance.pollutedWater -= 1;
                FindObjectOfType<UIManager>().GetComponent<UIManager>().SyncPollutedWaterCountText(ItemManager.Instance.pollutedWater);
            }
        }
    }
}