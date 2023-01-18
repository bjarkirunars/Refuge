using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;
using UnityEngine.AI;
// using NodeCanvas.DialogueTrees;

public class ActionManager : MonoBehaviour
{
    Animator m_Animator;

    // public TwoBoneIKConstraint m_RightArmIK;    // Procedural animation mechanism for the right arm
    // public GameObject m_RightArmIKTarget;       // The position that the procedural mechanism tries to put the hand into
   
    public GameObject m_FocusTarget;        // Head should rest on this target
    public GameObject m_GlanceAtTarget;     // Eyes only briefly turn to this target

    bool m_gazeTracking;                    // Should a target be followed by head and eyes?
    GameObject m_TrackingTarget;            // If tracking, this is the target followed

    NavMeshAgent m_NavAgent;                // This agent's path finding and path following component
    public GameObject[] m_Destinations;     // List of potential (known) destinations

    
    // bool m_isReadyingRightArm;              // True if a procedural arm motion has been started
    float m_timePassed;                     // How long that motion has been going
    // public float m_RightArmMoveDuration;    // How long that motion should last

    // public GameObject m_RightHand;          // Where we can attach props if we want

    public GameObject m_CharacterMesh;
    private SkinnedMeshRenderer m_SkinnedMeshRenderer;

    // public DialogueTree dialogue;
    // private float dialogueCount = 0;

    public enum BlendShapes
    {
        CloseEyes,
        Smile,
        EyebrowRaise,
        OpenMouth
    }
    

    // Start is called before the first frame update
    void Start()
    {
        // Initialization
        m_Animator = GetComponent< Animator >();
        m_NavAgent = GetComponent< NavMeshAgent >();
        m_gazeTracking = false;
        // dialogueCount = 1;
        
        // m_isReadyingRightArm = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Follow a target with the head
        if(m_gazeTracking)
        {
            GazeAt(m_TrackingTarget);
        }
        if(Vector3.Distance(transform.position, m_Destinations[0].transform.position)>1)
            {
                m_Animator.SetBool("walking", true);
                WalkTo(m_Destinations[0]);
            } else 
            {
                Quaternion lookRotation = Quaternion.LookRotation(new Vector3(0, -1, -20));
                transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, 0.5f);
                m_Animator.SetBool("walking", false);
                m_Animator.SetBool("sit", true);
            }

        // Bring the weight of the procedural arm constraint gradually up if activated (so it doesn't just snap)
        // if (m_isReadyingRightArm)
        // {
        //     m_timePassed = m_timePassed + Time.deltaTime;
        //     m_RightArmIK.weight = Mathf.Clamp(m_timePassed / m_RightArmMoveDuration, 0.0f, 1.0f);
        //     if (m_RightArmIK.weight == 1.0f)
        //     {
        //         m_isReadyingRightArm = false;
        //         m_timePassed = 0.0f;

        //     }
        // }
    }

    // Locomotion
    public void WalkTo(GameObject target)
    {
        m_NavAgent.destination = target.transform.position;
    }

    // public void WalkAway()
    // {
    //     foreach(GameObject destination in m_Destinations)
    //     {
    //         if(Vector3.Distance(transform.position, destination.transform.position)>1.0)
    //         {
    //             WalkTo(destination);
    //             break;
    //         }
    //     }
    // }

    // ====== GAZE ======
    public void GlanceAt(GameObject target)
    {
        // Brief target set for eyes
        m_GlanceAtTarget.transform.SetPositionAndRotation(target.transform.position, target.transform.rotation);
        Invoke("StopGlancing", 1.0f);
    }

    public void StopGlancing()
    {
        // Eyes reset to resting target
        m_GlanceAtTarget.transform.SetPositionAndRotation(m_FocusTarget.transform.position, m_FocusTarget.transform.rotation);
    }

    public void GazeAt(GameObject target)
    {
        // New resting target set for the eyes and head. Glance reset at the same time
        m_FocusTarget.transform.SetPositionAndRotation(target.transform.position, target.transform.rotation);
        m_GlanceAtTarget.transform.SetPositionAndRotation(target.transform.position, target.transform.rotation);
    }

    public void GazeTrack(GameObject target)
    {
        // Initiate tracking a target with head and eyes
        m_TrackingTarget = target;
        m_gazeTracking = true;
        // if(dialogueCount == 1) {
        //     dialogue.StartDialogue();
        //     dialogueCount = 0;
        // }
    }

    public void StopGazeTrack()
    {
        // Stop tracking a target (but gaze remains in same direction)
        m_gazeTracking = false;
    }

    // ====== MANIPULATION ======

    // public void RightArmReachObject(GameObject target)
    // {
    //     m_RightArmIKTarget.transform.SetPositionAndRotation(target.transform.position, target.transform.rotation);
    //     m_isReadyingRightArm = true;
    // }

    // public void RightHandAttachObject(GameObject target)
    // {
    //     target.transform.SetParent(m_RightHand.transform, true);
    // }

    // public void RightArmRelax()
    // {
    //     m_RightArmIK.weight = 0.0f;
    // }
}
