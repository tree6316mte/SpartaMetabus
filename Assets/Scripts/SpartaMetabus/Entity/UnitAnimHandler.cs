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

    // ToString �ּ�ȭ�Ͽ� GC�� ���̴� ���� ����
    private Dictionary<UnitAnimState, List<AnimationClip>> animStateClipList = new();
    private Dictionary<UnitAnimState, string> animStateStringCache = new();

    // clip's ����
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

        // ��� �ִϸ��̼� Ŭ���� �����ɴϴ�
        AnimationClip[] clips = animator.runtimeAnimatorController.animationClips;

        foreach (AnimationClip clip in clips)
        {
            // ������ Ŭ������ �������̵��մϴ�
            OverrideController[clip.name] = clip;
        }

        // ���¿� ���� animClip�� ����
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

    // �ִϸ��̼� ���
    public void PlayAnimation(UnitAnimState _playState, int _index)
    {
        // �ִϸ��̼� Ŭ�� ����ֱ�
        OverrideController[animStateStringCache[_playState]] = animStateClipList[_playState][_index];

        // �����̴� �������� �����(����)�������� ���� �������� Ȯ��
        bool isMove = _playState == UnitAnimState.MOVE;
        bool isDebuff = _playState == UnitAnimState.DEBUFF;
        bool isDeath = _playState == UnitAnimState.DEATH;
        animator.SetBool("isMove", isMove);
        animator.SetBool("isDebuff", isDebuff);
        animator.SetBool("isDeath", isDeath);

        // �����̰ų� ����� �ɸ��� �ʾ��� ���� Ʈ���� �۵�
        if (!isMove && !isDebuff)
        {
            AnimatorControllerParameter[] parameters = animator.parameters;

            // ��Ȱ�� Ʈ���� �۵��� ���� �Ķ���� ��� ��ȸ�ϸ� Enum�� ��
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
