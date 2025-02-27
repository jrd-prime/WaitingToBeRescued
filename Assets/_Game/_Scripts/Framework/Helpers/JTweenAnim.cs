﻿using _Game._Scripts.Framework.Data.Constants;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;
using UnityEngine.UIElements;

namespace _Game._Scripts.Framework.Helpers
{
    public class JTweenAnim
    {
        private readonly VisualElement _visualElement;
        private readonly float _visualElementWidth;
        private readonly float _animationDuration;
        private float _currentWidth;
        private TweenerCore<float, float, FloatOptions> _tween;

        public JTweenAnim(VisualElement visualElement, float visualElementWidth, float animationDuration)
        {
            _visualElement = visualElement;
            _visualElementWidth = visualElementWidth;
            _currentWidth = _visualElementWidth;
            _animationDuration = animationDuration;
        }

        public void RunTween(float widthPercent)
        {
            var targetWidth = _visualElementWidth * widthPercent;
            if (Mathf.Abs(targetWidth - _currentWidth) < JMathConst.Epsilon) return;
            _tween?.Kill();
            _tween = DOTween.To(() => _currentWidth, SetBarWidth, targetWidth, _animationDuration);
     
        }

        private void SetBarWidth(float width)
        {
            _currentWidth = width;
            _visualElement.style.width = width;
        }
    }
}
