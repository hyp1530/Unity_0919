using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private Animator m_Animator;

    // Use this for initialization
    void Start()
    {
        m_Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            m_Animator.SetTrigger("跳舞");
        }
        m_Animator.SetBool("跑步", Input.GetKey(KeyCode.R));
    }
}
