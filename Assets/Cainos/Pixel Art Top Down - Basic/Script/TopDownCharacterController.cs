﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cainos.PixelArtTopDown_Basic
{
    public class TopDownCharacterController : MonoBehaviour
    {
        public float speed;

        private Animator animator;

        private void Start()
        {
            animator = GetComponent<Animator>();
        }


        private void Update()
        {
            Vector2 dir = Vector2.zero;
            if (Input.GetKey(KeyCode.A))
            {
                dir.x = -1;
                animator.SetInteger("Direction", 3);
                GameManager.Instance.Logger.Log("A");
            }
            else if (Input.GetKey(KeyCode.D))
            {
                dir.x = 1;
                animator.SetInteger("Direction", 2);
                GameManager.Instance.Logger.Log("D");
            }

            if (Input.GetKey(KeyCode.W))
            {
                dir.y = 1;
                animator.SetInteger("Direction", 1);
                GameManager.Instance.Logger.Log("W");
            }
            else if (Input.GetKey(KeyCode.S))
            {
                dir.y = -1;
                animator.SetInteger("Direction", 0);
                GameManager.Instance.Logger.Log("S");
            }

            dir.Normalize();
            animator.SetBool("IsMoving", dir.magnitude > 0);

            GetComponent<Rigidbody2D>().linearVelocity = speed * dir;
        }
    }
}
