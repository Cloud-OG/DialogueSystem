using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using StarterAssets;
using UnityEngine;
using UnityEngine.InputSystem;

public class ThirdPersonShooterController : MonoBehaviour
{
    [SerializeField] private float normalSensitivity;
    [SerializeField] private LayerMask aimColliderLayerMask = new LayerMask();
    
    private ThirdPersonController _thirdPersonController;
    private StarterAssets.StarterAssetsInputs starterAssetsInputs;
    private Animator _animator;
    
    private void Awake()
    {
        _thirdPersonController = GetComponent<ThirdPersonController>();
        starterAssetsInputs = GetComponent<StarterAssetsInputs>();
        _animator = GetComponent<Animator>();
    }
    
    void Start()
    {
        
    }
    
    void Update()
    {
        Vector3 mouseWorldPosition = Vector3.zero;
        
        Vector2 screenCenterPoint = new Vector2(Screen.width / 2f, Screen.height / 2f);
        Ray ray = Camera.main.ScreenPointToRay(screenCenterPoint);
        Transform hitTransform = null;
        if (Physics.Raycast(ray, out RaycastHit raycastHit, 999f, aimColliderLayerMask))
        {
            mouseWorldPosition = raycastHit.point;
            hitTransform = raycastHit.transform;
        }

        _thirdPersonController.SetSensitivity(normalSensitivity);
        _thirdPersonController.SetRotateOnMove(true);
        _animator.SetLayerWeight(1, Mathf.Lerp(_animator.GetLayerWeight(1), 0f, Time.deltaTime * 10f));
        
    }
}
