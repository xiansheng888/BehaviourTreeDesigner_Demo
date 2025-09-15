using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;



namespace Assets.scripts.ai
{
    [TaskDescription("怪物的普通攻击")]
    [TaskCategory("MyGame")]
    public class NormalAttackAction : BehaviorDesigner.Runtime.Tasks.Action
    {
        private Animator animator;

        public override void OnAwake()
        {
             
        }
        public override void OnStart()
        {
            this.animator = this.GetComponent<Animator>();
            if (this.animator != null)
            {
                this.animator.SetTrigger("Attack");
            }
        }

        public override void OnEnd()
        {

        }

        public override void OnBehaviorComplete()
        {
             
        }
        public override TaskStatus OnUpdate()
        {
            return TaskStatus.Success;
        }
    }
}
