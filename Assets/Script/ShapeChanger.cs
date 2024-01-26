using UnityEngine;

public class ShapeChanger : MonoBehaviour
{
    private int currentShapeIndex = 0; // ���� ��� ���� ��������Ʈ�� �ε���
    public Sprite[] shapeSprites; // ����, �ﰢ��, �簢�� ��������Ʈ�� �����ϴ� �迭
    CircleCollider2D circleCollider;
    PolygonCollider2D polygonCollider;
    BoxCollider2D boxCollider; 
    public Transform myTransform; //Ʈ������
    private int randomIncrease = 0;  //ũ�⸦ ������ų�� �E�� �����ϴ� �����μ�
    private float randomSize = 0; //ũ�⸦ �󸶳� �������� �������� �����μ�

    void Start()
    {
        //������ Circle
        CircleCollider2D circleCollider = gameObject.AddComponent<CircleCollider2D>();
        // ���� ���� �� 10�ʸ��� ShapeChange �Լ� ȣ��
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
        // ��������Ʈ �ε��� ������Ʈ �� �迭 ���� üũ
        currentShapeIndex += 1;
        if (currentShapeIndex >2) 
        {
            currentShapeIndex = 0;   
        }

        // ���ο� ��������Ʈ �Ҵ�
        GetComponent<SpriteRenderer>().sprite = shapeSprites[currentShapeIndex];

        if (currentShapeIndex == 0)
        {
            boxCollider = GetComponent<BoxCollider2D>();
            if (boxCollider != null)
            {
                // Box Collider 2D�� ����.
                Destroy(boxCollider);
                circleCollider = gameObject.AddComponent<CircleCollider2D>();
            }
        }
        else if (currentShapeIndex == 1)
        {
            circleCollider = GetComponent<CircleCollider2D>();
            if (circleCollider != null)
            {
                // Circle Collider 2D�� ����.
                Destroy(circleCollider);
                polygonCollider = gameObject.AddComponent<PolygonCollider2D>();
            }
        }
        else if (currentShapeIndex == 2)
        {
            polygonCollider = GetComponent<PolygonCollider2D>();
            if (polygonCollider != null)
            {
                // Polygon Collider 2D�� ����.
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

    // ���⿡�� �ٸ� �ʿ��� �Լ� �� ������ �߰��� �� �ֽ��ϴ�.