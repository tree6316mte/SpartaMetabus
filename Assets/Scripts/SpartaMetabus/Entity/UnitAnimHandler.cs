using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum UnitAnimState
{
    IDLE,
    MOVE,
    ATTACK,
    DAMAGED,
    DEBUFF,
    DEATH,
    OTHER,
}

public class UnitAnimHandler : MonoBehaviour
{
    private Animator animator;
    private AnimatorOverrideController OverrideController;

    // ToString 최소화하여 GC가 쌓이는 것을 방지
    private Dictionary<UnitAnimState, List<AnimationClip>> animStateClipList = new();
    private Dictionary<UnitAnimState, string> animStateStringCache = new();

    // clip's 저장
    public List<AnimationClip> idleClipList = new();
    public List<AnimationClip> moveClipList = new();
    public List<AnimationClip> attackClipList = new();
    public List<AnimationClip> damagedClipList = new();
    public List<AnimationClip> debuffClipList = new();
    public List<AnimationClip> deathClipList = new();
    public List<AnimationClip> otherClipList = new();

    public void Start()
    {
        animator = GetComponent<Animator>();

        OverrideController = new AnimatorOverrideController();
        OverrideController.runtimeAnimatorController = animator.runtimeAnimatorController;

        // 모든 애니메이션 클립을 가져옵니다
        AnimationClip[] clips = animator.runtimeAnimatorController.animationClips;

        foreach (AnimationClip clip in clips)
        {
            // 복제된 클립으로 오버라이드합니다
            OverrideController[clip.name] = clip;
        }

        // 상태에 따른 animClip들 저장
        foreach (UnitAnimState state in Enum.GetValues(typeof(UnitAnimState)))
        {
            animStateStringCache[state] = state.ToString();
            animStateClipList[state] = new List<AnimationClip>();
            switch (state)
            {
                case UnitAnimState.IDLE:
                    animStateClipList[state] = idleClipList;
                    break;
                case UnitAnimState.MOVE:
                    animStateClipList[state] = moveClipList;
                    break;
                case UnitAnimState.ATTACK:
                    animStateClipList[state] = attackClipList;
                    break;
                case UnitAnimState.DAMAGED:
                    animStateClipList[state] = damagedClipList;
                    break;
                case UnitAnimState.DEBUFF:
                    animStateClipList[state] = debuffClipList;
                    break;
                case UnitAnimState.DEATH:
                    animStateClipList[state] = deathClipList;
                    break;
                case UnitAnimState.OTHER:
                    animStateClipList[state] = otherClipList;
                    break;
            }
        }
    }

    // 애니메이션 재생
    public void PlayAnimation(UnitAnimState _playState, int _index)
    {
        // 애니메이션 클립 집어넣기
        OverrideController[animStateStringCache[_playState]] = animStateClipList[_playState][_index];

        // 움직이는 상태인지 디버프(스턴)상태인지 죽은 상태인지 확인
        bool isMove = _playState == UnitAnimState.MOVE;
        bool isDebuff = _playState == UnitAnimState.DEBUFF;
        bool isDeath = _playState == UnitAnimState.DEATH;
        animator.SetBool("isMove", isMove);
        animator.SetBool("isDebuff", isDebuff);
        animator.SetBool("isDeath", isDeath);

        // 움직이거나 디버프 걸리지 않았을 때에 트리거 작동
        if (!isMove && !isDebuff)
        {
            AnimatorControllerParameter[] parameters = animator.parameters;

            // 원활한 트리거 작동을 위해 파라미터 모두 순회하며 Enum과 비교
            foreach (AnimatorControllerParameter parameter in parameters)
            {
                if (parameter.type == AnimatorControllerParameterType.Trigger)
                {
                    bool isTrigger = parameter.name.Contains(animStateStringCache[_playState], StringComparison.OrdinalIgnoreCase);
                    if (isTrigger)
                    {
                        // Debug.Log($"Parameter: {parameter.name}, Type: {parameter.type}");
                        animator.SetTrigger(parameter.name);
                        break;
                    }
                }
            }
        }
    }

    public void TempPlay()
    {
        PlayAnimation(UnitAnimState.OTHER, 0);
    }
}
