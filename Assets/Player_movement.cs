using UnityEngine;
using UnityEngine.UI;

public class Player_movement : MonoBehaviour
{
    
    public Rigidbody2D rb;
    public bool on_clicK = false;
    private Vector2 mouse_pos_org;
    private Vector2 mouse_pos_now;
    private LineRenderer lr;
    public float max_fuel = 100;
    public float fuel = 100;
    public float fuel_consumption = 1;
    public Image fuel_bar;
    public Animator run;
    public bool on_charge = false;
    public ParticleSystem smoke;
    public Image item_bar;
    public bool has_item = false;
    public GameObject item;

    public float speed = 10;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        lr = GetComponent<LineRenderer>();
        run = GetComponent<Animator>();
        smoke = transform.GetChild(0).GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = Vector2.zero;
        bool use_fuel = false;
        if(fuel > 0 && on_charge)
        {
            //set direction with wasd keys
            if (Input.GetKey(KeyCode.W))
            {
                direction += Vector2.up * 2.2f;
                use_fuel = true;
                run.SetBool("on_move", true);
                if (Mathf.Abs(transform.rotation.z) < 0.03f)
                {
                    transform.Rotate(0, 0, -0.2f);
                }
            }

            if (Input.GetKey(KeyCode.S))
            {
                direction += Vector2.down * 2.2f;
                use_fuel = true;
                run.SetBool("on_move", true);
                if (Mathf.Abs(transform.rotation.z) < 0.03f)
                {
                    transform.Rotate(0, 0, 0.2f);
                }
            }

            if (Input.GetKey(KeyCode.A))
            {
                direction += Vector2.left;
                use_fuel = true;
                run.SetBool("on_move", true);
            }

            if (transform.rotation.z != 0)
            {
                transform.Rotate(0, 0, -0.6f * transform.rotation.z);
            }

            if (Input.GetKey(KeyCode.D) && rb.velocity.x < -0.5f)
            {
                direction += Vector2.right * 1.1f;
                use_fuel = true;
            }

            if (Input.GetKey(KeyCode.D))
            {

                run.SetBool("move_back", true);
            }
            else
            {
                run.SetBool("move_back", false);
            }

            var emm = smoke.emission;

            if (direction == Vector2.zero)
            {
                run.SetBool("on_move", false);
                // emm.rateOverTime = 0;
                smoke.Stop();

            }
            else if(fuel < 0 && on_charge)
            {
                smoke.Stop();
            }
            else
            {
                // emm.rateOverTime = 120;
                smoke.Play();
            }

            if (rb.velocity.x > -2)
            {
                direction += Vector2.left * 0.3f;
            }

            rb.AddForce(direction * speed);

            if (use_fuel)
            {
                fuel -= fuel_consumption * Time.deltaTime;
            }

        }
        else
        {
            run.SetBool("on_move", false);
            run.SetBool("move_back", false);
            
            transform.Rotate(0, 0, -0.6f * transform.rotation.z);
        }
        fuel += fuel_consumption * Time.deltaTime * 0.3f;
        
        fuel = Mathf.Clamp(fuel, 0, max_fuel);

        fuel_bar.fillAmount = Mathf.Lerp(fuel_bar.fillAmount, fuel / max_fuel, 0.1f);

        if (fuel <= 0.1f && on_charge)
        {
            on_charge = false;
            Invoke("set", 1.5f);
        }

        if (!on_charge)
        {
            fuel += fuel_consumption * Time.deltaTime * 0.3f;
        }

        if(rb.velocity.x > 0)
        {
            rb.AddForce(Vector2.left * rb.velocity.x * 0.8f);
        }

        if (item_bar.GetComponent<Image>().sprite != null)
        {
            has_item = true;
            item_bar.color = new Color(1, 1, 1, 1);
        }
        else
        {
            has_item = false;
            item_bar.color = new Color(1, 1, 1, 0);

        }
        
        
    }

    void set()
    {
        on_charge = true;
    }

    public void lost_item()
    {
        if (item_bar.GetComponent<Image>().sprite == null) return;
        GameObject a = Instantiate(item, transform.position + Vector3.left*1.5f, Quaternion.identity);
        a.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-2, 2), Random.Range(2, 4));
        has_item = false;
        a.GetComponent<SpriteRenderer>().sprite = item_bar.GetComponent<Image>().sprite;
        item_bar.GetComponent<Image>().sprite = null;
        // item_bar.color = new Color(1, 1, 1, 0);
    }
}
