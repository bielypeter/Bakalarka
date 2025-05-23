// Copyright (c) Mixed Reality Toolkit Contributors
// Licensed under the BSD 3-Clause

using System.Collections.Generic;
using UnityEngine;


namespace MixedReality.Toolkit.SpatialManipulation
{
    /// <summary>
    /// This class defines the default manipulation logic for translation handles of bounds control
    /// </summary>
    public class BoundsControlMoveLogic : ManipulationLogic<Vector3>
    {
        private BoundsControl boundsCont;
        private BoundsHandleInteractable currentHandle;
        private Vector3 initialGrabPoint;
        private MixedRealityTransform initialTransformOnGrabStart;

        /// <inheritdoc />
        public override void Setup(List<UnityEngine.XR.Interaction.Toolkit.Interactors.IXRSelectInteractor> interactors, UnityEngine.XR.Interaction.Toolkit.Interactables.IXRSelectInteractable interactable, MixedRealityTransform currentTarget)
        {
            base.Setup(interactors, interactable, currentTarget);
            currentHandle = interactable.transform.GetComponent<BoundsHandleInteractable>();
            boundsCont = currentHandle.BoundsControlRoot;
            initialGrabPoint = currentHandle.interactorsSelecting[0].GetAttachTransform(currentHandle).position;
            initialTransformOnGrabStart = new MixedRealityTransform(boundsCont.Target.transform);
        }

        /// <inheritdoc />
        public override Vector3 Update(List<UnityEngine.XR.Interaction.Toolkit.Interactors.IXRSelectInteractor> interactors, UnityEngine.XR.Interaction.Toolkit.Interactables.IXRSelectInteractable interactable, MixedRealityTransform currentTarget, bool centeredAnchor)
        {
            base.Update(interactors, interactable, currentTarget, centeredAnchor);

            Vector3 currentGrabPoint = currentHandle.interactorsSelecting[0].GetAttachTransform(currentHandle).position;
            Vector3 translateVectorAlongAxis = Vector3.Project(currentGrabPoint - initialGrabPoint, currentHandle.transform.forward);

            return initialTransformOnGrabStart.Position + translateVectorAlongAxis;
        }
    }
}
