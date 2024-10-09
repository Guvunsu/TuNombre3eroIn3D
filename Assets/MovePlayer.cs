using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MovePlayer : MonoBehaviour {
    Vector3 m_velocity;
    bool m_isGround;
    float m_gravity;
    CharacterController m_Charactercontroller;
    [SerializeField] float m_speed;
    [SerializeField] float m_jumpForce;
    [SerializeField] Transform m_checker;
    [SerializeField] LayerMask m_groundMask;

    void Start() {
        m_gravity = -9.81f;
        m_Charactercontroller = GetComponent<CharacterController>();
    }

    void Update() {
        // estamos haciendo un rigidbody al player y le damos un valor a este y detectara si estamos saltando o no 
        m_isGround = Physics.CheckSphere(m_checker.position, 0.5f, m_groundMask);

        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        Vector3 m_move = transform.right * moveX + transform.forward * moveY;
        m_Charactercontroller.Move(m_move * m_speed * Time.deltaTime);
        if (Input.GetButtonDown("Jump") && m_isGround) {
            m_velocity.y = Mathf.Sqrt(-2 * m_gravity * m_jumpForce);
        }
        m_velocity.y += m_gravity * Time.deltaTime;
        m_Charactercontroller.Move(m_velocity * Time.deltaTime);
    }
}
