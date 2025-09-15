using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;
[TaskDescription("判断是否和玩家之间的距离足够近")]
[TaskCategory("MyGame")]
public class IsCloseFromPlayer : Conditional
{
    [BehaviorDesigner.Runtime.Tasks.Tooltip("阈值")]
    public float distanceThreshold = 5.0f;
    private Transform playerTransform;
    private Transform aiTransform;
    public override void OnStart()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        aiTransform = this.transform;
    }
    public override TaskStatus OnUpdate()
    {
        if (playerTransform == null || aiTransform == null)
        {
            return TaskStatus.Failure;
        }
        float distance = Vector3.Distance(playerTransform.position, aiTransform.position);
        return distance <= distanceThreshold ? TaskStatus.Success : TaskStatus.Failure;
    }
    public override void OnReset()
    {
        distanceThreshold = 5.0f;
        playerTransform = null;
        aiTransform = null;
    }
}
