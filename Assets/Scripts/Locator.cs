using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Locator
{
    private static CameraController _cameraController;

    public static void ProvideCameraController(CameraController cc) => _cameraController = cc;

    public static CameraController GetCameraController() => _cameraController;
}
