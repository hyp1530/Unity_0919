using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lady : MonoBehaviour {
    private Animator ani;
    private Rigidbody rig;  

    [Header("速度"),Range(1f,100f)]
    public float speed = 1.5f;

    [Header("旋轉速度"), Range(1f, 100f)]
    public float turn = 1.5f;

    [Header("血量"), Range(100, 500)]
    public float hp = 100;

    public string parRun = "跑步開關";
    public string parAtk = "攻擊觸發";
    public string parDam = "受傷觸發";
    public string parJump = "跳躍觸發";
    public string parDead = "死亡開關";

    public int MyProperty { get; set; }
    public bool isAttack
    {
        get
        {
            return ani.GetCurrentAnimatorStateInfo(0).IsName("攻擊");
        }
    }

    public bool isDamage
    {
        get
        {
            return ani.GetCurrentAnimatorStateInfo(0).IsName("受傷");
        }
    }

    void Start ()
    {
        ani = GetComponent<Animator>();
        rig = GetComponent<Rigidbody>();
	}
  
    private void Update()
    {
        //print("是否為攻擊動畫：" + isAttack;
        //print("是否為受傷動畫：" + isDamage;

        if (isAttack || isDamage) return;

        Turn();
        Attack();
    }

    private void FixedUpdate()
    {
        if (isAttack || isDamage) return;

        Walk();
        Jump();      
    }
    private void OnTriggerEnter(Collider other)
    {
        print(other.tag);

        if (other.tag == "陷阱")
        {
            Hurt();
        }
    }
    private void Walk()
    {
        ani.SetBool(parRun, Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0);

        rig.AddForce(transform.forward * Input.GetAxisRaw("Vertical") * speed+ transform.right* Input.GetAxisRaw("Horizontal") * speed);
    }
    private void Turn()
    {
        float x = Input.GetAxis("Mouse X");   
        transform.Rotate(0, x*turn*Time.deltaTime, 0);
    }
    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            ani.SetTrigger(parJump);
    }
    private void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
            ani.SetTrigger(parAtk);
    }

    private void Hurt()
    {
        ani.SetTrigger(parDam);
        hp -= 20;
        if (hp <= 0) Dead();
    }

    private void Dead()
    {
        ani.SetBool(parDead, true);
        this.enabled = false;
    }
    
   

}
