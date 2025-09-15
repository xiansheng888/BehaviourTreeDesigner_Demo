using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;



namespace Assets.scripts.ai
{

    [TaskDescription("追踪一个对象")]
    [TaskCategory("MyGame")]
    internal class FollowAction : BehaviorDesigner.Runtime.Tasks.Action
    {
        [BehaviorDesigner.Runtime.Tasks.Tooltip("追踪的对象")]
        public UnityEngine.GameObject target;

        private float speed;
        private float attackDistance;
        public override void OnAwake()
        {
            base.OnAwake();

        }
        public override void OnStart()
        {
            base.OnStart();
            this.speed = (float)this.Owner.GetVariable("speed").GetValue();
            this.attackDistance = (float)this.Owner.GetVariable("attackDistance").GetValue();
        }

        public override TaskStatus OnUpdate()
        {
            UnityEngine.Debug.Log("FollowAction OnUpdate");
            Vector3 dir = (this.target.transform.position - this.transform.position).normalized;
            this.transform.position += dir * Time.deltaTime * speed;
            if (Vector3.Distance(this.target.transform.position, this.transform.position) < this.attackDistance)
            {
                return TaskStatus.Success;
            }
            else
            {
                return TaskStatus.Running;
            }

        }
        public override void OnEnd()
        {
            base.OnEnd();
        }

        public override void OnBehaviorComplete()
        {
            base.OnBehaviorComplete();
        }
    }
}
