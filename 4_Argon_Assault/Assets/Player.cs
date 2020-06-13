using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    [Tooltip("In ms^-1")][SerializeField] float Speed = 20f;
    [Tooltip("In m")] [SerializeField] float XRange = 10f;
    [Tooltip("In m")][SerializeField] float YRange = 6.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
    }

    private void ProcessRotation()
    {
        transform.localRotation = Quaternion.Euler(0f, 90f, 0f);
    }

    private void ProcessTranslation()
    {
        float xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float xOffest = xThrow * Speed * Time.deltaTime;
        float rawXPos = transform.localPosition.x + xOffest;
        float clampedXPos = Mathf.Clamp(rawXPos, -XRange, XRange);

        float yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        float yOffest = yThrow * Speed * Time.deltaTime;
        float rawYPos = transform.localPosition.y + yOffest;
        float clampedYPos = Mathf.Clamp(rawYPos, -YRange, YRange);

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
    }
}
