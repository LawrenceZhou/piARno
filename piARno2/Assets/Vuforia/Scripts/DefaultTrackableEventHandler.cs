/*==============================================================================
Copyright (c) 2010-2014 Qualcomm Connected Experiences, Inc.
All Rights Reserved.
Confidential and Proprietary - Protected under copyright and other laws.
==============================================================================*/

using UnityEngine;
using UnityEngine.VR.WSA.Persistence;
using UnityEngine.VR.WSA;

namespace Vuforia
{
    /// <summary>
    /// A custom handler that implements the ITrackableEventHandler interface.
    /// </summary>
    public class DefaultTrackableEventHandler : MonoBehaviour,
                                                ITrackableEventHandler
    {
        #region PRIVATE_MEMBER_VARIABLES
 
        private TrackableBehaviour mTrackableBehaviour;
        public GameObject monster;
		public GameObject musicSheet;
		public GameObject greenBar;
        public GameObject startButton;
        public GameObject stopButton;
        public GameObject logo;
        public GameObject background;
        private int count = 0;

        #endregion // PRIVATE_MEMBER_VARIABLES



        #region UNTIY_MONOBEHAVIOUR_METHODS

        void Start()
        {
            mTrackableBehaviour = GetComponent<TrackableBehaviour>();
            if (mTrackableBehaviour)
            {
                mTrackableBehaviour.RegisterTrackableEventHandler(this);
            }
            
        }

        #endregion // UNTIY_MONOBEHAVIOUR_METHODS

       


        #region PUBLIC_METHODS

        /// <summary>
        /// Implementation of the ITrackableEventHandler function called when the
        /// tracking state changes.
        /// </summary>
        public void OnTrackableStateChanged(
                                        TrackableBehaviour.Status previousStatus,
                                        TrackableBehaviour.Status newStatus)
        {
            if (newStatus == TrackableBehaviour.Status.DETECTED ||
                newStatus == TrackableBehaviour.Status.TRACKED ||
                newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
            {
                OnTrackingFound();
            }
            else
            {
                OnTrackingLost();
            }
        }

        #endregion // PUBLIC_METHODS



        #region PRIVATE_METHODS


        private void OnTrackingFound()
        {
            Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);
            Collider[] colliderComponents = GetComponentsInChildren<Collider>(true);

            // Enable rendering:
            foreach (Renderer component in rendererComponents)
            {
                component.enabled = true;
            }

            // Enable colliders:
            foreach (Collider component in colliderComponents)
            {
                component.enabled = true;
            }

            Vector3 pointOnTarget = new Vector3(-0.5f, 0, -0.23f);

            // We convert the local point to world coordinates
            Vector3 targetPointInWorldRef = transform.TransformPoint(pointOnTarget);

            Debug.Log("target point in world coords: " + targetPointInWorldRef.x + ", " + targetPointInWorldRef.y + ", " + targetPointInWorldRef.z);
            if (count < 1)
            {
                //GameObject player = Instantiate(monster, targetPointInWorldRef, Quaternion.AngleAxis(180, Vector3.right)) as GameObject;
                Instantiate(monster, targetPointInWorldRef, Quaternion.identity);
				Vector3 sheetInWorldRef = targetPointInWorldRef + new Vector3(0.222f, 0, -0.12f);
				Vector3 barInWorldRef = targetPointInWorldRef + new Vector3(0.01f, 0, -0.12f);
				Instantiate(musicSheet, sheetInWorldRef, Quaternion.AngleAxis(180, Vector3.right));
				Instantiate(greenBar, barInWorldRef, Quaternion.AngleAxis(90, Vector3.right));

                Vector3 startInWorldRef = targetPointInWorldRef + new Vector3(0.10f, -0.08f, -0.2f);
                Vector3 stopInWorldRef = targetPointInWorldRef + new Vector3(0.34f, -0.08f, -0.2f);
                Instantiate(startButton, startInWorldRef, Quaternion.AngleAxis(180, Vector3.right));
                Instantiate(stopButton, stopInWorldRef, Quaternion.AngleAxis(180, Vector3.right));

                Vector3 logoInWorldRef = targetPointInWorldRef + new Vector3(0.22f, -0.08f, -0.2f);
                Instantiate(logo, logoInWorldRef, Quaternion.AngleAxis(180, Vector3.right));

                Vector3 bgInWorldRef = targetPointInWorldRef + new Vector3(0.22f, -0.2f, -0.22f);
                Instantiate(background, bgInWorldRef, Quaternion.AngleAxis(180, Vector3.right));


                count++;
                DigitalEyewearARController.Instance.EnableWorldAnchorUsage(false);
                TrackerManager.Instance.GetTracker<ObjectTracker>().Stop();
            }
            Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " found");
        }


        private void OnTrackingLost()
        {
            Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);
            Collider[] colliderComponents = GetComponentsInChildren<Collider>(true);

            // Disable rendering:
            foreach (Renderer component in rendererComponents)
            {
                component.enabled = false;
            }

            // Disable colliders:
            foreach (Collider component in colliderComponents)
            {
                component.enabled = false;
            }

            //Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " lost");
        }

        #endregion // PRIVATE_METHODS
    }
}
