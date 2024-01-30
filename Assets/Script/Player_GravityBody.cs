using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player_GravityBody : MonoBehaviour
{
    private GravityAttractor attractor; //���� ������Ʈ ������
    private Rigidbody2D rb; //������ٵ� ������
    public SpriteRenderer player; //�÷��̾� ��������Ʈ �����
  //  private ParticleController particleController;

    private bool isGrounded; //�� üũ��
    public float jumpForce = 14.5f; // ���� �� ������
    public float jumpCooldown = 0.2f; //���� ��Ÿ�ӿ�1
    private float lastJumpTime;  //���� ��Ÿ�ӿ�2
    public float orbitSpeed = 150f; // ���� �ӵ� ������
    private float lastHorizontalInput;  //���������� �Է��� Ű���� ���Ⱚ
    private int isDashKeyPressed = 0; //�뽬 Ű�� ���� �������� �뽬 �۵��ϵ��� üũ�ϴ� �뵵

    public float stamina = 70f; //�뽬�� ���¹̳�
    public float maxStamina = 70f; //�ִ� ���¹̳�
    public float staminaRegenRate = 0.2f; //�ʴ� ���¹̳� ����

    public float playerHp = 100f; // �÷��̾� ü��
    public float playerMaxhp = 100f; // �÷��̾� �ִ� ü��
    
    private int isShield = 0; //�ǵ尡 �������ִ���
    public Sprite shield;
    public Sprite circle;

    public Slider HpBar;
    public Slider StaminaBar;

    public AudioClip jump;
    public AudioClip dash;
    public AudioClip pickup;
    public AudioClip damaged;
    public AudioClip bomb;
    public AudioClip hittedshield;
    public AudioClip brokenshield;
    public AudioSource audioSource;


    private void Start()
    {
        attractor = FindObjectOfType<GravityAttractor>();
        rb = GetComponent<Rigidbody2D>();
        InvokeRepeating("RegenerateStamina", 0f, 0.1f); //���¹̳� ���� ����
        player = GetComponent<SpriteRenderer>();
        
    }

    private void Update()
    {
        
        attractor.Attract(rb);

        //�̵�
        float horizontalInput = Input.GetAxis("Horizontal");
        if (horizontalInput != 0)
        {
            OrbitAroundAttractor(horizontalInput);
            lastHorizontalInput = horizontalInput;
        }
        // ����
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && Time.time - lastJumpTime > jumpCooldown)
        {
            Jump();
        }

        // �뽬: ����Ʈ Ű ����
        // ����Ʈ Ű�� ������ �� OrbitAroundAttractor ȣ��
        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetMouseButtonDown(1))
        {
            if (stamina >= 24)
            {
                if (isDashKeyPressed == 0 )      //�ε巯�� �뽬�� ����.. ���� ȣ��.. �뽬 �ѹ��� ���¹̳� 24 �Ҹ�
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
                Debug.Log($"���¹̳� ����. ���¹̳�: {stamina}");
            }
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift) || Input.GetMouseButtonUp(1))
        {
            isDashKeyPressed = 0;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // ���� �浹 ���
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        if (collision.gameObject.CompareTag("Meteor"))
        {
            if (isShield >=1)
            {
                isShield -= 1;

                if (isShield <= 0)
                {
                    isShield = 0;
                    player.sprite = circle;
                    player.transform.localScale = new Vector3(0.25f, 0.25f, 1);
                    audioSource.PlayOneShot(brokenshield,1f); //�ǵ��ı�ȿ����
                }
            }
            else
            {
                playerHp -= 22;
                audioSource.PlayOneShot(damaged); //�ǰ�ȿ����

                if (playerHp < 0)
                {
                    playerHp = 0;
                    HpBar.value = playerHp / playerMaxhp;
                    SceneManager.LoadScene("EndScene");
                }
                HpBar.value = playerHp / playerMaxhp;
            }

            Debug.Log($"���� HP: {playerHp}/{playerMaxhp}");
        }


        if (collision.gameObject.CompareTag("BlueShieldItem"))
        {
            isShield += 2;
            player.sprite = shield;
            player.transform.localScale = new Vector3(0.5f, 0.5f, 1);
            audioSource.PlayOneShot(hittedshield); //�ǵ��ļ�ȿ����
        }

        if (collision.gameObject.CompareTag("GreenHealingItem")) //Hp���� �±� �� �� �÷��̾� ü�� ȸ�� ��� �� ����� ������ ȸ���� Ȯ�εǳ� ��� �ݿ��ȵ� /Item
        {
            playerHp += 32;
            if (playerHp > playerMaxhp)
            {
                playerHp = playerMaxhp;
                audioSource.PlayOneShot(pickup,1f); //�������ǽ���ȿ����
            }
            HpBar.value = playerHp / playerMaxhp;
           // Vector3 position = player.transform.position;          
           // particleController.CreateHealParticle(position);
                      
        }

        if (collision.gameObject.CompareTag("GreenStaminaItem")) //Sp���� �±� �� �� �÷��̾� ��� ȸ�� ��� �� ����� ������ ȸ���� Ȯ��/Item
        {
            stamina += 50;
            if (stamina > maxStamina)
            {
                stamina = maxStamina;
                audioSource.PlayOneShot(pickup,1f); //������ǽ���ȿ����
            }
            playerHp += 12;
            if (playerHp > playerMaxhp)
            {
                playerHp = playerMaxhp;
            }
            HpBar.value = playerHp / playerMaxhp;
            StaminaBar.value = stamina / maxStamina;





            Debug.Log($"���� SP: {stamina}/{maxStamina}");
        }

        if (collision.gameObject.CompareTag("RedFakeGloveItem"))
        {
            audioSource.PlayOneShot(pickup); //¡�����ȿ����
            audioSource.PlayOneShot(bomb, 2f); //������
        }

    }

    void Jump()
    {
        //�� ������Ʈ�� ��ǥ ���
        Vector2 awayFromAttractor = ((Vector2)rb.position - (Vector2)attractor.transform.position).normalized;

        // �ݴ�������� ����
        rb.AddForce(awayFromAttractor * jumpForce, ForceMode2D.Impulse);

        // ���� ��Ÿ�� ���
        lastJumpTime = Time.time;

        // ������ ������ ����
        isGrounded = false;

        //����ȿ����
        audioSource.PlayOneShot(jump);

    }

    void OrbitAroundAttractor(float horizontalInput)
    {
        float orbitDirection = Mathf.Sign(horizontalInput) * -1;
        transform.RotateAround(attractor.transform.position, Vector3.forward, orbitDirection * orbitSpeed * Time.deltaTime);
    }

    void OrbitAroundAttractorWithShift()  //�뽬
    {
        float orbitDirection = Mathf.Sign(lastHorizontalInput) * -1;
        transform.RotateAround(attractor.transform.position, Vector3.forward, orbitDirection * 500 * Time.deltaTime);
        stamina -= 1.7f;
        if (stamina < 0)
        {
            stamina = 0;
        }
        StaminaBar.value = stamina / maxStamina;

        //�뽬ȿ����
        audioSource.PlayOneShot(dash);
    }

    void RegenerateStamina() //���¹̳� ����
    {
        if (stamina < maxStamina)
        {
            stamina += staminaRegenRate;
            StaminaBar.value = stamina / maxStamina;
        }
        else if (stamina > maxStamina)
        {
            stamina = maxStamina;
        }
    }

    //�����۽���� �Ҹ����



}