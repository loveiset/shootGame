using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
    public float m_speed = 2;
    protected float m_rotSpeed = 30;

    protected float m_timer = 1.0f;
    protected Transform m_transform;

    public float m_life = 10;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag.CompareTo("bound") == 0)
        {
            m_life = 0;
            Destroy(this.gameObject);
        }
        if (other.tag.CompareTo("PlayerRocket") == 0)
        {
            Rocket rocket = other.GetComponent<Rocket>();
            if (rocket !=null)
            {
                m_life -= rocket.m_power;

                if (m_life <= 0)
                {
                    Destroy(this.gameObject);
                }
            }

            else if (other.tag.CompareTo("Player") == 0)
            {
                m_life = 0;
                Destroy(this.gameObject);
            }
        }
    }

	// Use this for initialization
	void Start () {
        m_transform = this.transform;
	
	}

    protected void UpdateMove()
    {
        m_timer -= Time.deltaTime;
        if (m_timer <= 0)
        {
            m_timer = 3;
            m_rotSpeed = -m_rotSpeed;
        }
        m_transform.Rotate(Vector3.up, m_rotSpeed * Time.deltaTime, Space.World);
        m_transform.Translate(new Vector3(0, 0, -m_speed * Time.deltaTime));
    }
	
	// Update is called once per frame
	void Update () {
        UpdateMove();
	
	}
}
