﻿
using MotionSystems;
using System.Runtime.InteropServices;
using UnityEngine;

public class SensorManager : MonoBehaviour
{
    private const float DRAWING_HEAVE_MAX = 1.0f;

    // Heave change step
    private const float DRAWING_HEAVE_STEP = 0.05f;

    // Maximum value of pitch angle that is available in the game
    private const float DRAWING_PITCH_MAX = 16;

    // Pitch change step
    private const float DRAWING_PITCH_STEP = 2;

    // Maximum value of roll angle that is available in the game
    private const float DRAWING_ROLL_MAX = 16;

    private const float DRAWING_ROLL_MIN = -5;

    // Pitch change step
    private const float DRAWING_ROLL_STEP = 1;

    // Origin position of the shaft
    //    private Vector3 m_originPosition;

    // Origin rotation of the board
    //  private Vector3 m_originRotation;

    // Current platform's heave in game
    private float m_heave = 0;

    // Current platform's pitch in game
    private float m_pitch = 0;

    // Current platform's roll in game
    private float m_roll = 0;

    // FSMI api
    private ForceSeatMI m_fsmi;

    // Position in physical coordinates that will be send to the platform
    private FSMI_TopTablePositionPhysical m_platformPosition = new FSMI_TopTablePositionPhysical();

    static SensorManager instance;


    void Update()
    {
        SendDataToPlatform();
    }

    void SendDataToPlatform()
    {
        // Convert parameters to logical units
        m_platformPosition.state = FSMI_State.NO_PAUSE;
        m_platformPosition.roll = Mathf.Deg2Rad * m_roll;
        m_platformPosition.pitch = -Mathf.Deg2Rad * m_pitch;
        m_platformPosition.heave = m_heave * 100;


        // Send data to platform
        m_fsmi.SendTopTablePosPhy(ref m_platformPosition);
    }

    public static SensorManager Instance()
    {
        if (instance == null)
        {
            instance = new SensorManager();
        }
        return instance;
    }

    public void InitialiseSimulation()
    {
        m_fsmi = new ForceSeatMI();

        if (instance.m_fsmi.IsLoaded())
        {
            // Find platform's components

            // Prepare data structure by clearing it and setting correct size
            m_platformPosition.mask = 0;
            m_platformPosition.structSize = (byte)Marshal.SizeOf(instance.m_platformPosition);

            m_platformPosition.state = FSMI_State.NO_PAUSE;

            // Set fields that can be changed by demo application
            m_platformPosition.mask = FSMI_POS_BIT.STATE | FSMI_POS_BIT.POSITION;

            m_fsmi.BeginMotionControl();

            SendDataToPlatform();
        }
        else
        {
            Debug.LogError("ForceSeatMI library has not been found!Please install ForceSeatPM.");
        }
    }

    public void EndSimulation()
    {
        if (m_fsmi.IsLoaded())
        {
            m_fsmi.EndMotionControl();
            m_fsmi.Dispose();
        }
    }

    public void SendWalkSensation()
    {
        m_heave = 0.3f;
        m_roll = Mathf.Clamp(instance.m_platformPosition.roll - DRAWING_ROLL_STEP, DRAWING_ROLL_MIN, DRAWING_ROLL_MAX);
        m_pitch = 0f;
    }

    public void SendShootSensation() { }

    public void SendHitSensation() { }

}
