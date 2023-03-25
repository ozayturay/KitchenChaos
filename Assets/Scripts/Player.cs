using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

  private bool isWalking;
  [SerializeField] private float moveSpeed = 7.0f;
  [SerializeField] private GameInput gameInput;

  private void Update() {
    Vector2 inputVector = gameInput.GetMovementVectorNormalized();

    Vector3 moveDir = new Vector3(inputVector.x, 0.0f, inputVector.y);
    transform.position += moveDir * moveSpeed * Time.deltaTime;

    isWalking = moveDir != Vector3.zero;

    float rotateSpeed = 10.0f;
    transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * rotateSpeed);
  }

  public bool IsWalking() {
    return isWalking;
  }

}