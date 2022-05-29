using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BerserkerContrllerScript : MonoBehaviour
{
    public float speed;
    public float pX;
    public float pY;
    public float pZ;
    public int Action1;
    public bool isIceBlast;
    public bool isDead;
    public Animator AnimatorScript;
    public GameObject AttackCo;
    public bool isMonsters;

    // Start is called before the first frame update
    void Start()
    {
        isMonsters = false;
    }

    // Update is called once per frame
    void Update()
    {
        BoxCollider ER = AttackCo.GetComponent<BoxCollider>();
        /*   if (isMonsters == true)
           {
               GetHit1();
               fixLocation();
               isMonsters = false;
           }*/
        if (Action1 == 9)
        {
            Die();
        }
        if (isDead == false)
        {
            if (isIceBlast == true)
            {
                Die();
                isDead = true;
            }
            else
            {
                /*if (Input.GetKey(KeyCode.Q))
                {
                    walk();
                    fixLocation();
                    ER.enabled = false;
                }
                else if (Input.GetKey(KeyCode.E))
                {
                    run();
                    fixLocation();
                    ER.enabled = false;
                }*/
                if (Input.GetKey(KeyCode.R))
                {
                    Attack1();
                    fixLocation();
                    ER.enabled = true;
                }
                else if (Input.GetKey(KeyCode.T))
                {
                    Attack2();
                    fixLocation();
                    ER.enabled = true;
                }
                else if (Input.GetKey(KeyCode.Y))
                {
                    Attack3();
                    fixLocation();
                    ER.enabled = true;
                }
                else if (Input.GetKey(KeyCode.Alpha1))
                {
                    SkillAttack1();
                    fixLocation();
                    ER.enabled = true;
                }
                else if (Input.GetKey(KeyCode.Alpha2))
                {
                    SkillAttack2();
                    fixLocation();
                    ER.enabled = true;
                }
                else if (Input.GetKey(KeyCode.Alpha3))
                {
                    SkillAttack3();
                    fixLocation();
                    ER.enabled = true;
                }
                else if (Input.GetKey(KeyCode.Alpha4))
                {
                    SkillAttack4();
                    fixLocation();
                    ER.enabled = true;
                }
                else if (Input.GetKey(KeyCode.Z))
                {
                    GetHit1();
                    fixLocation();
                    ER.enabled = false;
                }
                else if (Input.GetKey(KeyCode.X))
                {
                    GetHit2();
                    fixLocation();
                    ER.enabled = false;
                }
                else if (Input.GetKey(KeyCode.C))
                {
                    Die();
                    fixLocation();
                    ER.enabled = false;
                }
                else
                {
                    idle();
                    fixLocation();
                    ER.enabled = false;
                }
            }
        }
        else
        {
            Action1 = 9;
        }

    }
    void idle()
    {
        AnimatorScript = this.GetComponent<Animator>();
        if (AnimatorScript != null)
        {
            AnimatorScript.Play("Berserk_idle_01_hu");
        }
    }
    void walk()
    {
        speed = 0.015F;
        pX = this.transform.position.x;
        pY = this.transform.position.y;
        pZ = this.transform.position.z;
        this.transform.Translate(new Vector3(0, 0, speed));
        AnimatorScript = this.GetComponent<Animator>();
        if (AnimatorScript != null)
        {
            AnimatorScript.Play("Berserk_townwalk_01_hu");
        }
    }
    void run()
    {
        speed = 0.03F;
        pX = this.transform.position.x;
        pY = this.transform.position.y;
        pZ = this.transform.position.z;
        this.transform.Translate(new Vector3(0, 0, speed));
        AnimatorScript = this.GetComponent<Animator>();
        if (AnimatorScript != null)
        {
            AnimatorScript.Play("Berserk_walk_01_hu");
        }
    }
    void Attack1()
    {
        AnimatorScript = this.GetComponent<Animator>();
        if (AnimatorScript != null)
        {
            AnimatorScript.Play("Berserk_attack_01_hu");
        }
    }
    void Attack2()
    {
        AnimatorScript = this.GetComponent<Animator>();
        if (AnimatorScript != null)
        {
            AnimatorScript.Play("Berserk_attack_02_hu");
        }
    }
    void Attack3()
    {
        AnimatorScript = this.GetComponent<Animator>();
        if (AnimatorScript != null)
        {
            AnimatorScript.Play("Berserk_attack_03_hu");
        }
    }
    void SkillAttack1()
    {
        AnimatorScript = this.GetComponent<Animator>();
        if (AnimatorScript != null)
        {
            AnimatorScript.Play("Berserk_skill_01_hu");
        }
    }
    void SkillAttack2()
    {
        AnimatorScript = this.GetComponent<Animator>();
        if (AnimatorScript != null)
        {
            AnimatorScript.Play("Berserk_skill_02_hu");
        }
    }
    void SkillAttack3()
    {
        AnimatorScript = this.GetComponent<Animator>();
        if (AnimatorScript != null)
        {
            AnimatorScript.Play("Berserk_skill_03_hu");
        }
    }
    void SkillAttack4()
    {
        AnimatorScript = this.GetComponent<Animator>();
        if (AnimatorScript != null)
        {
            AnimatorScript.Play("Berserk_skill_04_hu");
        }
    }
    void GetHit1()
    {
        AnimatorScript = this.GetComponent<Animator>();
        if (AnimatorScript != null)
        {
            AnimatorScript.Play("Berserk_hit_01_hu");
        }
    }
    void GetHit2()
    {
        AnimatorScript = this.GetComponent<Animator>();
        if (AnimatorScript != null)
        {
            AnimatorScript.Play("Berserk_hit_02_hu");
        }
    }
    void Die()
    {
        AnimatorScript = this.GetComponent<Animator>();
        if (AnimatorScript != null)
        {
            AnimatorScript.Play("Berserk_die_01_hu");
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.collider.tag + " Crash " + collision.collider.name);
        if (collision.collider.tag == "Monsters")
        {
            isMonsters = true;
        }
    }
    private void OnParticleCollision(GameObject other)
    {
        Debug.Log(other.name);
        if (other.name == "Chill")
        {
            isIceBlast = true;
        }
    }
    void fixLocation()
    {
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
    }
}
