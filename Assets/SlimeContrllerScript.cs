using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SlimeContrllerScript : MonoBehaviour
{
    
    public class Enums
    {   public enum actionMonster
        {
            idle = 1,
            walk = 2,
            run = 3,
            turnLeft = 4,
            turnRight = 5,
            attack = 6,
            specialAttack = 7,
            getHit = 8,
            die = 9
        }
    }
    //public int OP;
    public float speed;
    public float pX;
    public float pY;
    public float pZ;
    public int Action1;
    public bool isFence;
    public bool isDead;
    public int A;
    public int di1;
    public int di2;
    public int T;
    public int Ti;
    public int Ti2;
    public bool isRayFound;
    public bool isIceBlast;
    public Animator AnimatorScript;
    public GameObject Eff;
    public GameObject Sli;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Action1 = 0;
        isFence = false;
        isDead = false;
        isIceBlast = false;
        isRayFound = false;
        Eff.SetActive(true);
    }

    // Update is called once per frame
    /*void Update()
    {
        //Ra();
        if (Action1 == 1)
            {
                idle();
            }
        else if (Action1 == 2)
            {
                walk();
            }
        else if (Action1 == 3)
            {
                run();


            }
        else if (Action1 == 4)
            {
                turnLeft();

            }
        else if (Action1 == 5)
            {
                turnRight();

            }
        else if (Action1 == 6)
            {
                Attack();
            }
        else if (Action1 == 7)
            {
                SpecialAttack();
            }
        else if (Action1 == 8)
            {
                GetHit();
            }
        else if (Action1 == 9)
            {
                Die();
            }

        if (isDead == false)
        {
            if (isIceBlast == true)
            {

                if (A < 200)
                {
                    delay();
                    Action1 = 8;
                    delay();
                    T = T + 1;
                    A = A + 1;
                }
                else
                {
                    isDead = true;
                }
            }
            else
            {
                if (T >= 15)
                { 
                    Action1 = 1;
                    T = 0;
                }
                float counter = 0;
                float E = GetAnimatorWaitTime();
                while (counter < E)
                {
                    counter += Time.deltaTime;
                }
                
            }
            if (isFence == true)
            {
                Action1 = 9;
                isDead = true;
            }
            else if (isFence == false)
            {
                float Distanciing = ToPlayerDistanciing();
                if (Distanciing <= 10)
                {
                    this.transform.LookAt(player.transform);
                    Action1 = 3;
                    fixLocation();
                    if (Distanciing <= 1.2)
                    {
                        if (Action1 != 6)
                        {
                            Ti2 = Ti2 + 1;
                            if (Ti2 == 20)
                            {
                                Action1 = 6;
                                Ti = 0;
                            }
                            else if (Ti2 == 0)
                            {
                                Action1 = 6;
                            }
                        }
                        else
                        {
                            Ti = Ti + 1;
                            if(Ti == 20)
                            {
                                Action1 = 1;
                                Ti2 = 1;
                            }
                        }
                      /*  Ti = Ti + 1;
                        if (Ti >= 20)
                        {
                            Action1 = 6;
                            Ti = 0;
                        }
                        else
                        {
                            Action1 = 1;
                        }*//*
                        fixLocation();
                    }
                }
                else
                {
                    Action1 = 1;
                    fixLocation();
                }
            }

        } 
        else
        {
            Action1 = 9;
        }
        isIceBlast = false;
    }*/
    void Update()
    {
       // player = GameObject.FindGameObjectWithTag("Player");
        animationManager();
        if (isDead == false)
        {
            if (isFence == false)
            {
                actionManager();
            }
            else
            {
                Dead();
            }
        }
        else
        {
            if(di1 <= 200 && di1 >= 0)
            {
                di1 = di1 + 1;
                di2 = di2 + 1;
                Dead();
            }
            else if (di1 > 200)
            {
                
                this.gameObject.SetActive(false);
            }
            if(di2 >= 100)
            {
                SwitchMode();
            }
            else
            {
                Eff.SetActive(false);
            }
            
        }
    }
    private void FixedUpdate()
    {
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        if (Physics.Raycast(transform.position, fwd, out hit, 10))
        {
            Debug.Log("พบแล้ว" + hit.distance);
            if (hit.distance <= 10)
            {
                isRayFound = true;
                if (hit.distance <= 1.2)
                {
                    combatMode();
                }
                else
                {
                    runToPlayer();
                }
            }
        }
        else
        {
            isRayFound = false;
            Action1 = 1;
        }
    }
    void SwitchMode()
    {
        Eff.SetActive(true);
        Eff.transform.position = Sli.transform.position;
    }
    void idleMode()
    {
        idle();
    }
    void Dead()
    {
        Action1 = (int)Enums.actionMonster.die;
        isDead = true;     
    }
    void actionManager()
    {
       // idleMode();
        float Distanciing = ToPlayerDistanciing();
        Debug.Log(Distanciing);
       /* if (Distanciing <= 10 && Distanciing > 1.2)
        {
            runToPlayer();
        }
        else if(Distanciing <= 1.2)
        {
            combatMode();
        }*/

        if (Distanciing <= 10)
        {
            if(Distanciing <= 1.2)
            {
                combatMode();
            }
            else
            {
                runToPlayer();
            }       
        }

    }
    void animationManager()
    {
        if (Action1 == 1)
        {
            idle();
        }
        else if (Action1 == 2)
        {
            walk();
        }
        else if (Action1 == 3)
        {
            run();
        }
        else if (Action1 == 4)
        {
            turnLeft();
        }
        else if (Action1 == 5)
        {
            turnRight();
        }
        else if (Action1 == 6)
        {
            Attack();
        }
        else if (Action1 == 7)
        {
            SpecialAttack();
        }
        else if (Action1 == 8)
        {
            GetHit();
        }
        else if (Action1 == 9)
        {
            Die();
        }
    }
    void runToPlayer()
    {
        this.transform.LookAt(player.transform);
        Action1 = (int)Enums.actionMonster.run;
        fixLocation();
    }
    void combatMode()
    {
        float Distanciing = ToPlayerDistanciing();
        if (Distanciing <= 1.2)
        {
            if (Action1 != (int)Enums.actionMonster.attack)
            {   
                Ti2 = Ti2 + 1;
                if (Ti2 == 10)
                {
                    Action1 = (int)Enums.actionMonster.attack;
                    Ti = 0;
                }
                else if (Ti2 == 0)
                {
                    Action1 = (int)Enums.actionMonster.attack;
                }
                else if (Ti2 > 100)
                {
                    Action1 = (int)Enums.actionMonster.attack;
                }
            }
            else
            {
                Ti = Ti + 1;
                if (Ti == 10)
                {
                    Action1 = (int)Enums.actionMonster.idle;
                    Ti2 = 1;
                }                
                else if (Ti > 20)
                {
                    Action1 = (int)Enums.actionMonster.attack;
                    Ti = 0;
                }
                /*else
                {
                    Action1 = 1;
                }*/
                fixLocation();
            }
        }
        
    }
    void deadMode()
    {
        Die();
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.collider.tag + " Crash " + collision.collider.name);
        if (collision.collider.tag == "Sword")
        {
             isFence = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
    }
    private void OnParticleCollision(GameObject other)
    {
         Debug.Log(other.name);
         if (other.name == "Chill")
         {
              isIceBlast = true;
         }
    }
    void walk()
    {
        speed = 0.01F;
        pX = this.transform.position.x;
        pY = this.transform.position.y;
        pZ = this.transform.position.z;
        /* Debug.Log("pX = " + pX);
        Debug.Log("pY = " + pY);
        Debug.Log("pZ = " + pZ);
        pZ = pZ + speed;
        this.transform.position = new Vector3(pX, pY, pZ);*/
        this.transform.Translate(new Vector3(0, 0, speed));
        AnimatorScript = this.GetComponent<Animator>();
        if (AnimatorScript != null)
        {
            AnimatorScript.Play("Victory");
        }
    }
    void run()
    {
        speed = 0.02F;
        pX = this.transform.position.x;
        pY = this.transform.position.y;
        pZ = this.transform.position.z;
        /*Debug.Log("pX = " + pX);
        Debug.Log("pY = " + pY);
        Debug.Log("pZ = " + pZ);
        pZ = pZ + speed;
        this.transform.position = new Vector3(pX, pY, pZ);*/
        this.transform.Translate(new Vector3(0, 0, speed));
        AnimatorScript = this.GetComponent<Animator>();
        if (AnimatorScript != null)
        {
            AnimatorScript.Play("RunFWD");
        }
    }
    void Ra()
    {
        int Ac;
        int AA;
        Ac = Action1;
        AA = Ac + Random.Range(1, 5);
        Action1 = AA;
    }

    void turnRight()
    {
        float Yeuler;
        float yRotation = 90.0f;
        Yeuler = this.transform.eulerAngles.y;
        yRotation = Yeuler + Random.Range(100, 180);
        //transform.eulerAngles = new Vector3(transform.eulerAngles.x, yRotation, transform.eulerAngles.z);
        transform.eulerAngles = new Vector3(0, yRotation, 0);
    }
    void turnLeft()
    {
        float Yeuler;
        float yRotation = -90.0f;
        Yeuler = this.transform.eulerAngles.y;
        yRotation = Yeuler + Random.Range(-100, -180);
        //transform.eulerAngles = new Vector3(transform.eulerAngles.x, yRotation, transform.eulerAngles.z);
        transform.eulerAngles = new Vector3(0, yRotation, 0);
    }
    void idle()
    {
        AnimatorScript = this.GetComponent<Animator>();
        if (AnimatorScript != null)
        {
            AnimatorScript.Play("IdleNormal");
        }
    }
    void Attack()
    {
        AnimatorScript = this.GetComponent<Animator>();
        if (AnimatorScript != null)
        {
            AnimatorScript.Play("Attack01");
        }
    }
    void SpecialAttack()
    {
        AnimatorScript = this.GetComponent<Animator>();
        if (AnimatorScript != null)
        {
            AnimatorScript.Play("Attack02");
        }
    }
    void GetHit()
    {
        AnimatorScript = this.GetComponent<Animator>();
        if (AnimatorScript != null)
        {
            AnimatorScript.Play("GetHit");
        }
    }
    void Die()
    {
        AnimatorScript = this.GetComponent<Animator>();
        if (AnimatorScript != null)
        {
            AnimatorScript.Play("Die");
        }
    }

    void fixLocation()
    {
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
    }
    float ToPlayerDistanciing()
    {
        Vector3 thistank;
        if (isRayFound == true)
        {
            thistank = this.transform.position - player.transform.position;
            Debug.Log(thistank.magnitude);
            return thistank.magnitude;
        }
        else
        {
            isRayFound = false;
            return 11;
        }
    }
    public IEnumerable<bool> CheckAnimationDone()
    {
        AnimatorScript = this.GetComponent<Animator>();
        if (AnimatorScript != null)
        {
            float counter = 0;
           // AnimatorStateInfo b = AnimatorScript.GetCurrentAnimatorStateInfo(0);
            float waitTime = AnimatorScript.GetCurrentAnimatorStateInfo(0).length;
            while(counter < (waitTime))
            {
                counter += Time.deltaTime;
                yield return true;
            }
            yield return true;
        }
        yield return false;
    }
    public float GetAnimatorWaitTime()
    {
        AnimatorScript = this.GetComponent<Animator>();
        if (AnimatorScript != null)
        {
            float counter = 0;
            float waitTime = AnimatorScript.GetCurrentAnimatorStateInfo(0).length;
            return waitTime;
        }
        return 0;
    }
    public IEnumerable delay()
    {
        yield return new WaitForSeconds(500000);
    }
}
