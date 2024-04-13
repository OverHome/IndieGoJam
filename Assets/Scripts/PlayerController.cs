using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float walkingSpeed = 5;
    [SerializeField] private float runningSpeed = 10;
    [SerializeField] private float sensitivity = 100;
    [SerializeField] private Transform cameraPosition;
    
    private float _xRotation = 0f;
    private float _yRotation = 0f;
    private Vector3 _moveDirection = Vector3.zero;
    private Rigidbody _rb;
    private Camera _playerCamera;
    private InteractWithGame _interactWithGame;

    [HideInInspector] public bool canMove = true;
    [HideInInspector] public bool canMovedCamera = true;

    private void Start()
    {
        _playerCamera = Camera.main;
        _playerCamera.transform.position = cameraPosition.position;
        _playerCamera.transform.SetParent(transform);
        _rb = GetComponent<Rigidbody>();
        _interactWithGame = GetComponent<InteractWithGame>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Cursor.lockState = Cursor.lockState == CursorLockMode.Locked? CursorLockMode.Confined: CursorLockMode.Locked;
            canMovedCamera = CursorLockMode.Locked == Cursor.lockState;
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            _interactWithGame.TryPlayGame();
        }
        
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.fixedDeltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.fixedDeltaTime;

        _yRotation += mouseX;
        _xRotation -= mouseY;
        _xRotation = Mathf.Clamp(_xRotation, -90, 90);
    }

    private void FixedUpdate()
    {
        CharacterMove();
        CameraMove();
    }

    // ReSharper disable Unity.PerformanceAnalysis
    private void CharacterMove()
    {
        Vector3 forward = _playerCamera.transform.TransformDirection(Vector3.forward);
        Vector3 right = _playerCamera.transform.TransformDirection(Vector3.right);

        float curSpeedX = canMove ? walkingSpeed * Input.GetAxis("Vertical") : 0;
        float curSpeedY = canMove ? walkingSpeed * Input.GetAxis("Horizontal") : 0;
        _moveDirection = (forward * curSpeedX) + (right * curSpeedY);
        
        _rb.AddForce(_moveDirection*walkingSpeed*Time.fixedDeltaTime, ForceMode.Force);
    }

    private void CameraMove()
    {
        if (canMovedCamera && _playerCamera != null)
        {
            transform.localRotation = Quaternion.Euler(_xRotation, _yRotation, 0f);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (!other.gameObject.CompareTag("Takeable"))
        {
            Shake();
        }
    }

    private void Shake()
    {
        _playerCamera.transform.DOShakeRotation(0.2f, 2.5f, randomnessMode: ShakeRandomnessMode.Harmonic);
    }

    public Vector3 GetForse()
    {
        return _rb.velocity;
    }

    public void SetMove(bool isCan)
    {
        canMovedCamera = isCan;
        canMove = isCan;
        _rb.velocity = Vector3.zero;
    }
}
