using UnityEngine;

public class ShapeChanger : MonoBehaviour
{
    private int currentShapeIndex = 0; // 현재 사용 중인 스프라이트의 인덱스
    public Sprite[] shapeSprites; // 원형, 삼각형, 사각형 스프라이트를 저장하는 배열
    CircleCollider2D circleCollider;
    PolygonCollider2D polygonCollider;
    BoxCollider2D boxCollider; 
    public Transform myTransform; //트랜스폼
    private int randomIncrease = 0;  //크기를 증가시킬지 뺼지 결정하는 랜덤인수
    private float randomSize = 0; //크기를 얼마나 증감할지 결장히는 랜덤인수

    void Start()
    {
        //시작은 Circle
        CircleCollider2D circleCollider = gameObject.AddComponent<CircleCollider2D>();
        // 게임 시작 시 10초마다 ShapeChange 함수 호출
        InvokeRepeating("ShapeChange", 3f, 3f);
        InvokeRepeating("ShapeResize", 2f, 0.1f);
    }

    private void Update()
    {
       

    }

    void ShapeChange()
    {
        randomIncrease = Random.Range(0, 2);
        randomSize = Random.Range(0.05f, 1.5f);
        // 스프라이트 인덱스 업데이트 및 배열 범위 체크
        currentShapeIndex += 1;
        if (currentShapeIndex >2) 
        {
            currentShapeIndex = 0;   
        }

        // 새로운 스프라이트 할당
        GetComponent<SpriteRenderer>().sprite = shapeSprites[currentShapeIndex];

        if (currentShapeIndex == 0)
        {
            boxCollider = GetComponent<BoxCollider2D>();
            if (boxCollider != null)
            {
                // Box Collider 2D를 삭제.
                Destroy(boxCollider);
                circleCollider = gameObject.AddComponent<CircleCollider2D>();
            }
        }
        else if (currentShapeIndex == 1)
        {
            circleCollider = GetComponent<CircleCollider2D>();
            if (circleCollider != null)
            {
                // Circle Collider 2D를 삭제.
                Destroy(circleCollider);
                polygonCollider = gameObject.AddComponent<PolygonCollider2D>();
            }
        }
        else if (currentShapeIndex == 2)
        {
            polygonCollider = GetComponent<PolygonCollider2D>();
            if (polygonCollider != null)
            {
                // Polygon Collider 2D를 삭제.
                Destroy(polygonCollider);
                boxCollider = gameObject.AddComponent<BoxCollider2D>();
            }
        }
    }

    void ShapeResize()
    {
        if (randomIncrease == 0)
        {
            if (myTransform.localScale.x < (4f + randomSize) && myTransform.localScale.y < (4f + randomSize))
            {
                myTransform.localScale += new Vector3(0.07f, 0.07f, 0f);
            }
        }
        else
        {
            if (myTransform.localScale.x > (4f - randomSize) && myTransform.localScale.y > (4f-randomSize))
            {
                myTransform.localScale -= new Vector3(0.07f, 0.07f, 0f);
            }
        }
    }
}

    // 여기에는 다른 필요한 함수 및 로직을 추가할 수 있습니다.