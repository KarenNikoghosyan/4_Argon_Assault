using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour
{
    [Header("General")]
    [Tooltip("In ms^-1")][SerializeField] float ControlSpeed = 20f;
    [Tooltip("In m")] [SerializeField] float XRange = 20f;
    [Tooltip("In m")][SerializeField] float YRange = 12f;
    [Header("Screen-Position Based")]
    [SerializeField] float positionPitchFactor = -2.5f;
    [SerializeField] float positionYawFactor = 2.5f;
    [Header("Control-Throw Based")]
    [SerializeField] float controlPitchFactor = -30f;

    [SerializeField] float controlRollFactor = -30f;


    float xThrow, yThrow;
    bool isControlEnabled = true;

    // Update is called once per frame
    void Update()
    {
        if (isControlEnabled)
        {
            ProcessTranslation();
            ProcessRotation();
        }
    }
    private void OnPlayerDeath()
    {
        isControlEnabled = false;
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
        float xOffest = xThrow * ControlSpeed * Time.deltaTime;
        float rawXPos = transform.localPosition.x + xOffest;
        float clampedXPos = Mathf.Clamp(rawXPos, -XRange, XRange);

        yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        float yOffest = yThrow * ControlSpeed * Time.deltaTime;
        float rawYPos = transform.localPosition.y + yOffest;
        float clampedYPos = Mathf.Clamp(rawYPos, -YRange, YRange);

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
    }
}
