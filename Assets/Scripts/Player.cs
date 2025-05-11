using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public SpriteRenderer img_player;
    public PlayerData.PlayerDTO player_dto;
   

    [Header("Attributes")]
    public int health_current;
    public float speed;

    [Header("Prefab")]
    public Transform pivot;
    //public GameManager prefab;

 

    private Rigidbody2D rb;
    
    private float delta_time = 0; 
    private float shoot_time = 0;
    private bool is_shooting = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
       

        player_dto = GameManager.Instance.player_dto;

        img_player.sprite = player_dto.imagen;
        health_current = player_dto.health_max;
    }

    private void Update()
    {
        //if (!gyro_enabled) return;

        if(health_current > 0)
        {
            delta_time += Time.deltaTime;
            if (delta_time >= 1f)
            {
                GameManager.Instance.SetScore();
                UIManager.Instance.UpdateScore();
                delta_time = 0;
            }
            Shoot();
        }
    }

    private void Shoot()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
                is_shooting = true;

            if (touch.phase == TouchPhase.Ended)
                is_shooting = false;
        }

            shoot_time += Time.deltaTime;
            if (shoot_time >= player_dto.health_max && is_shooting)
            {
              ObjectPollingDynamic.instace.GetObject(pivot.position);
                    
                shoot_time = 0;
            }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            health_current -= 10;
            if(health_current <= 0)
            {
                Destroy(this.gameObject);
                GameManager.Instance.GameOver();
            }
        }

    }
}
