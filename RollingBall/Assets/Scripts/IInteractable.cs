﻿namespace RollingBall
{
    public interface IInteractable : IAction
    {
        bool IsInteractable { get; }
    }
}