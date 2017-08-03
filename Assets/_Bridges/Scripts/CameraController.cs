using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;

public class CameraController : MonoBehaviour
{

    public PlayerController playerController;
    private Vector3 velocity = Vector3.zero;
    private float firstXDistance;
    private float firstZDistance;
    private float currentXDistance;
    private float currentZDistance;
    private BlurOptimized blurEffect;

    void Start()
    {
        blurEffect = GetComponent<BlurOptimized>();
        if (blurEffect != null)
        {
            blurEffect.enabled = false;
        }
        firstXDistance = transform.position.x - playerController.transform.position.x;
        firstZDistance = transform.position.z - playerController.transform.position.z;
    }

    void Update()
    {
        if (playerController.isRunning && !playerController.gameManager.gameOver)
        {
            Vector3 pos = transform.position;
            pos.x = playerController.transform.position.x + firstXDistance;
            pos.z = playerController.transform.position.z + firstZDistance;
            transform.position = Vector3.SmoothDamp(transform.position, pos, ref velocity, 0.1f);
        }
    }

    public void ResetPosition()
    {
        Vector3 pos = transform.position;
        pos.x = playerController.transform.position.x + firstXDistance;
        pos.z = playerController.transform.position.z + firstZDistance;

        transform.position = pos;
    }

    public void EnableBlurEffect()
    {
        if (blurEffect != null)
        {
            blurEffect.enabled = true;
        }
    }

    public void DisableBlurEffect()
    {
        if (blurEffect != null)
        {
            blurEffect.enabled = false;
        }
    }
}
