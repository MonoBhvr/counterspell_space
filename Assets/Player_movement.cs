using UnityEngine;

public class Player_controller : MonoBehaviour
{
    
    private Rigidbody2D rb;
    public bool on_clicK = false;
    private Vector2 mouse_pos_org;
    private Vector2 mouse_pos_now;
    private LineRenderer lr;

    public float speed = 10;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        lr = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mouse_pos_org = Input.mousePosition;
        }
        if(Input.GetMouseButton(0))
        {
            on_clicK = true;
            mouse_pos_now = Input.mousePosition;
        }
        else
        {
            on_clicK = false;
            mouse_pos_now = new Vector2();
            mouse_pos_org = new Vector2();
        }

        if (on_clicK)
        {
            float distance = Vector2.Distance(mouse_pos_now, mouse_pos_org);
            distance = Mathf.Clamp(distance, 0, 600);
            print(distance);
            Vector2 direction = (mouse_pos_now - mouse_pos_org).normalized;
            
            //player moves on outer space. no gravity, only the power of small rocket
            //use wasd keys

            rb.AddForce(direction * distance * Time.deltaTime * speed * 0.1f);
            
            rb.velocity = Vector2.ClampMagnitude(rb.velocity, 10);
            lr.enabled = true;
            lr.SetPosition(0, Camera.main.ScreenToWorldPoint(mouse_pos_org) + new Vector3(0,0,3));
            lr.SetPosition(1, Camera.main.ScreenToWorldPoint(mouse_pos_now) + new Vector3(0,0,3));
            
        }
        else
        {
            lr.enabled = false;
            if (Input.GetKey(KeyCode.W))
            {
                rb.AddForce(Vector2.up * speed);
            }
            if (Input.GetKey(KeyCode.S))
            {
                rb.AddForce(Vector2.down * speed);
            }
            if (Input.GetKey(KeyCode.A))
            {
                rb.AddForce(Vector2.left * speed);
            }
            if (Input.GetKey(KeyCode.D))
            {
                rb.AddForce(Vector2.right * speed);
            }   
        }
        
    }
    void OnDrawGizmos()
    {
        if (on_clicK)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(Camera.main.WorldToScreenPoint(mouse_pos_org), Camera.main.WorldToScreenPoint(mouse_pos_now));
        }
    }
}

