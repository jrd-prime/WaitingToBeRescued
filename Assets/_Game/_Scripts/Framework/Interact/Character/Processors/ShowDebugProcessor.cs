﻿using System;
using _Game._Scripts.Framework.Data.DTO.InteractableObj;
using _Game._Scripts.Framework.Interact.Character._Base;
using JetBrains.Annotations;

namespace _Game._Scripts.Framework.Interact.Character.Processors
{
    [UsedImplicitly]
    public class ShowDebugProcessor : CharacterInteractProcessorBase
    {
        public override void Process(IInteractObjectDto objDto)
        {
            if (objDto is null) throw new ArgumentNullException(nameof(objDto));

            //objDto.Settings.ShowDebug();

            base.Process(objDto);
        }
    }
}
