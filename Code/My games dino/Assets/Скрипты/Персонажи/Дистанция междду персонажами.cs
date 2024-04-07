using UnityEngine;
using Cinemachine;

public class CameraFollow : MonoBehaviour
{
    public Transform player1;
    public Transform player2;
    public float maxDistance = 10f;

    private CinemachineVirtualCamera virtualCamera;

    private void Start()
    {
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
    }

    private void Update()
    {
        float distance = Vector3.Distance(player1.position, player2.position);
        if (distance > maxDistance)
        {
            // Находим середину между персонажами
            Vector3 middlePoint = (player1.position + player2.position) / 2f;
            // Направляем камеру в эту точку
            virtualCamera.transform.position = new Vector3(middlePoint.x, middlePoint.y, virtualCamera.transform.position.z);
        }
    }
}
