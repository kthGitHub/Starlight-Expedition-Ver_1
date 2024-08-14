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
            targetObject.SetActive(true); // ��������Ʈ�� ������ ����. 
                                          // ��� ���๰�� ���������� �̷����� �ڵ带 �ϳ��� �� �Է��ؾ� �ϴ���?
                                          // �Ǵ� BuildManager���� ������ �迭 �������� ������ ����, ������ ���� ��� �ν����� â�� ��������Ʈ�� �ְ�,
                                          // �ش� ������Ʈ�� ���������� ������?
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
    private float interval = 2f; // 5��
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= interval)
        {
            WpWork();
            timer = 0f; // Ÿ�̸� �ʱ�ȭ
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