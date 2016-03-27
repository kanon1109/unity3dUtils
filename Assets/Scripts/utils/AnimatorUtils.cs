using UnityEngine;
public class AnimatorUtils
{
    /// <summary>
    /// 播放设置bool值的动画
    /// </summary>
    /// <param name="animator">动画组件</param>
    /// <param name="name">动作名称</param>
    public static void playBoolAnimal(Animator animator, string name)
    {
        if (AnimatorUtils.isName(animator, name)) return;
        int length = animator.parameters.Length;
        for (int i = 0; i < length; ++i)
        {
            animator.SetBool(animator.parameters[i].name, false);
        }
        animator.SetBool(name, true);
    }

    /// <summary>
    /// 判断是否处于某个状态比animator.isName准确；
    /// </summary>
    /// <param name="animator">模型动作组件</param>
    /// <param name="name">动作名称</param>
    /// <returns></returns>
    public static bool isName(Animator animator, string name)
    {
        bool isRunning = false;
        int length = animator.parameters.Length;
        for (int i = 0; i < length; ++i)
        {
            AnimatorControllerParameter acp = animator.parameters[i];
            if (acp.name == name)
                isRunning = animator.GetBool(acp.nameHash);
        }
        return isRunning;
    }
}
