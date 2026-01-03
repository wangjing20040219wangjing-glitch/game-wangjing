using UnityEngine;

public class RobotManualMove : MonoBehaviour
{
    private ArticulationBody articulationBody;

    void Start()
    {
        articulationBody = GetComponent<ArticulationBody>();
        if (articulationBody == null)
        {
            Debug.LogError("No ArticulationBody found!");
            return;
        }
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // 控制 X 和 Z 轴的位置目标
        if (articulationBody != null)
        {
            // 获取当前世界位置
            Vector3 currentPos = transform.position;

            // 设置目标位置
            Vector3 targetPos = currentPos + new Vector3(
                horizontal * 0.1f, // 左右移动
                0,
                vertical * 0.1f    // 前后移动
            );

            // 设置 Articulation Body 的目标位置（通过 Transform）
            transform.position = targetPos;
        }
    }
}