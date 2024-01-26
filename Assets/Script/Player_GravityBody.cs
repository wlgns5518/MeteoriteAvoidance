using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_GravityBody : MonoBehaviour
{
    private GravityAttractor attractor; //지구 오브젝트 참조용
    private Rigidbody2D rb; //리지드바디 참조용
    public SpriteRenderer player; //플레이어 스프라이트 변경용

    private bool isGrounded; //땅 체크용
    public float jumpForce = 16f; // 점프 힘 조절용
    public float jumpCooldown = 0.2f; //점프 쿨타임용1
    private float lastJumpTime;  //점프 쿨타임용2
    public float orbitSpeed = 150f; // 공전 속도 조절용
    private float lastHorizontalInput;  //마지막으로 입력한 키보드 방향값
    private int isDashKeyPressed = 0; //대쉬 키가 눌린 순간에만 대쉬 작동하도록 체크하는 용도

    public float stamina = 70f; //대쉬용 스태미나
    public float maxStamina = 70f; //최대 스태미나
    public float staminaRegenRate = 0.5f; //초당 스태미나 리젠

    public float playerHp = 100f; // 플레이어 체력
    public float playerMaxhp = 100f; // 플레이어 최대 체력
    
    private bool isShield = false; //실드가 씌워져있는지
    public Sprite shield;
    public Sprite circle;

    public PlayerStats stats;

    private void Start()
    {
        attractor = FindObjectOfType<GravityAttractor>();
        rb = GetComponent<Rigidbody2D>();
        InvokeRepeating("RegenerateStamina", 0f, 0.1f); //스태미나 리젠 시작
        player = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        
        attractor.Attract(rb);

        //이동
        float horizontalInput = Input.GetAxis("Horizontal");
        if (horizontalInput != 0)
        {
            OrbitAroundAttractor(horizontalInput);
            lastHorizontalInput = horizontalInput;
        }
        // 점프
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && Time.time - lastJumpTime > jumpCooldown)
        {
            Jump();
        }

        // 대쉬: 쉬프트 키 감지
        // 쉬프트 키가 눌렸을 때 OrbitAroundAttractor 호출
        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetMouseButtonDown(1))
        {
            if (stamina >= 14)
            {
                if (isDashKeyPressed == 0 )      //부드러운 대쉬를 위해.. 연속 호출.. 대쉬 한번당 스태미나 14 소모
                {
                    Invoke("OrbitAroundAttractorWithShift", 0f);
                    Invoke("OrbitAroundAttractorWithShift", 0.01f);
                    Invoke("OrbitAroundAttractorWithShift", 0.015f);
                    Invoke("OrbitAroundAttractorWithShift", 0.02f);
                    Invoke("OrbitAroundAttractorWithShift", 0.025f);
                    Invoke("OrbitAroundAttractorWithShift", 0.03f);
                    Invoke("OrbitAroundAttractorWithShift", 0.035f);
                    Invoke("OrbitAroundAttractorWithShift", 0.04f);
                    Invoke("OrbitAroundAttractorWithShift", 0.055f);
                    Invoke("OrbitAroundAttractorWithShift", 0.07f);
                    Invoke("OrbitAroundAttractorWithShift", 0.095f);
                    Invoke("OrbitAroundAttractorWithShift", 0.11f);
                    Invoke("OrbitAroundAttractorWithShift", 0.135f);
                    Invoke("OrbitAroundAttractorWithShift", 0.15f);
                    isDashKeyPressed = 1;
                    
                }
            }
            else
            {
                Debug.Log($"스태미나 부족. 스태미나: {stamina}");
            }
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift) || Input.GetMouseButtonUp(1))
        {
            isDashKeyPressed = 0;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // 땅과 충돌 계산
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        if (collision.gameObject.CompareTag("Meteor"))
        {
            if (isShield)
            {
                isShield = false;
                player.sprite = circle;
                
            }
            else
            {
                playerHp -= 15;
                stats.UpdateStats();
                if (playerHp < 0)
                {
                    playerHp = 0;
                }
            }

            Debug.Log($"현재 HP: {playerHp}/{playerMaxhp}");
        }


        if (collision.gameObject.CompareTag("blueshielditem"))
        {
            isShield = true;
            player.sprite = shield;
        }
    }

    void Jump()
    {
        //두 오브젝트의 좌표 계산
        Vector2 awayFromAttractor = ((Vector2)rb.position - (Vector2)attractor.transform.position).normalized;

        // 반대방향으로 점프
        rb.AddForce(awayFromAttractor * jumpForce, ForceMode2D.Impulse);

        // 점프 쿨타임 계산
        lastJumpTime = Time.time;

        // 땅에서 떨어짐 판정
        isGrounded = false;
    }

    void OrbitAroundAttractor(float horizontalInput)
    {
        float orbitDirection = Mathf.Sign(horizontalInput) * -1;
        transform.RotateAround(attractor.transform.position, Vector3.forward, orbitDirection * orbitSpeed * Time.deltaTime);
    }

    void OrbitAroundAttractorWithShift()  //대쉬
    {
        float orbitDirection = Mathf.Sign(lastHorizontalInput) * -1;
        transform.RotateAround(attractor.transform.position, Vector3.forward, orbitDirection * 250 * Time.deltaTime);
        stamina -= 1;
        if (stamina < 0)
        {
            stamina = 0;
        }
    }

    void RegenerateStamina() //스태미나 리젠
    {
        if (stamina < maxStamina)
        {
            stamina += staminaRegenRate;
            
        }
        else if (stamina > maxStamina)
        {
            stamina = maxStamina;
        }
    }
}