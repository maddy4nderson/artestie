using UnityEngine;
using UnityEngine.XR.ARFoundation;
using System.Collections.Generic;
using UnityEngine.XR.ARSubsystems;

public class ImageTracker : MonoBehaviour
{
    [SerializeField]
ARTrackedImageManager m_ImageManager;
public GameObject noosaScene;
void OnEnable() => m_ImageManager.trackablesChanged.AddListener(OnChanged);

void OnDisable() => m_ImageManager.trackablesChanged.RemoveListener(OnChanged);

void OnChanged(ARTrackablesChangedEventArgs<ARTrackedImage> eventArgs)
{
    foreach (var newImage in eventArgs.added)
    {
        GameObject newObject = Instantiate(noosaScene);
        newObject.transform.SetParent(newImage.transform, false);

        // Handle added event
    }

    foreach (var updatedImage in eventArgs.updated)
    {
        // Handle updated event
    }

    foreach (var removed in eventArgs.removed)
    {
        // Handle removed event
        TrackableId removedImageTrackableId = removed.Key;
        ARTrackedImage removedImage = removed.Value;
    }
}

}
