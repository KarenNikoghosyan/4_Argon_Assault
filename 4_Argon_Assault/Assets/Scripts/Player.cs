using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    [Tooltip("In ms^-1")][SerializeField] float Speed = 20f;
    [Tooltip("In m")] [SerializeField] float XRange = 20f;
    [Tooltip("In m")][SerializeField] float YRange = 12f;
    [SerializeField] float positionPitchFactor = -2.5f;
    [SerializeField] float controlPitchFactor = -30f;

    [SerializeField] float positionYawFactor = 2.5f;

    [SerializeField] float controlRollFactor = -30f;


    float xThrow, yThrow;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        print("Player hit triggered something");
    }

    // Update is called once per frame
    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
    }

    private void ProcessRotation()
    {
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControl = yThrow * controlPitchFactor;
        float pitch = pitchDueToPosition + pitchDueToControl;

        float yaw = transform.localPosition.x * positionYawFactor;

        float roll = xThrow * controlRollFactor;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    private void ProcessTranslation()
    {
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float xOffest = xThrow * Speed * Time.deltaTime;
        float rawXPos = transform.localPosition.x + xOffest;
        float clampedXPos = Mathf.Clamp(rawXPos, -XRange, XRange);

        yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        float yOffest = yThrow * Speed * Time.deltaTime;
        float rawYPos = transform.localPosition.y + yOffest;
        float clampedYPos = Mathf.Clamp(rawYPos, -YRange, YRange);

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
    }
}
