using Character;
using JetBrains.Annotations;
using UnityEngine;

namespace Animators
{
    [UsedImplicitly]
    public sealed class DeathAnimatorTrigger
    {
        private static readonly int _Death = Animator.StringToHash("Death");
        private readonly Animator _animator;

        public DeathAnimatorTrigger(PlayerService playerService)
        {
            _animator = playerService.Character.GetComponent<Animator>();
        }

        public void Death()
        {
            _animator.SetTrigger(_Death);
        }
    }
}