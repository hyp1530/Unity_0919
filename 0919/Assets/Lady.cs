using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lady : MonoBehaviour {
    private Animator ani;
    private Rigidbody rig;
    [Header("速度"),Range(0f,100f)]
    public float speed = 1.5f;

    public string parRun = "跑步開關";
    public string parAtk = "攻擊觸發";
    public string parDam = "受傷觸發";
    public string parJump = "跳躍觸發";
    public string parDead = "死亡開關";
    void Start () {

        ani = GetComponent<Animator>();
        rig = GetComponent<Rigidbody>();
	}
    private void FixedUpdate()
    {
        Walk();
        Jump();
        Attack();
    }

    private void Walk()
    {
        ani.SetBool(parRun, Input.GetAxis("Vertical") != 0 || Input.GetAxis("Vertical") != 0);
        rig.AddForce(transform.forward * Input.GetAxisRaw("Vertical") * speed);
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
    private void Dead()
    {
        ani.SetBool(parDead, true);
    }
    
    private void Hurt()
    {
        ani.SetTrigger(parDam);
    }


}
