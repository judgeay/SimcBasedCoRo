﻿using System.Windows.Forms;
using Styx.Common;
using Styx.WoWInternals;

namespace SimcBasedCoRo.Managers
{
    public static class HotkeysManager
    {
        #region Fields

        private static bool _keysRegistered;

        #endregion

        #region Public Methods

        public static void RegisterHotKeys()
        {
            if (_keysRegistered)
                return;

            Styx.Common.HotkeysManager.Register("AoeOn", Keys.A, ModifierKeys.Control, ret =>
            {
                SimCraftCombatRoutine.UseAoe = !SimCraftCombatRoutine.UseAoe;
                Lua.DoString(SimCraftCombatRoutine.UseAoe ? "print('AoE Mode: Enabled!')" : @"print('AoE Mode: Disabled!')");
            });

            _keysRegistered = true;
        }

        public static void RemoveHotkeys()
        {
            if (!_keysRegistered)
                return;

            Styx.Common.HotkeysManager.Unregister("AoeOn");

            _keysRegistered = false;
        }

        #endregion
    }
}