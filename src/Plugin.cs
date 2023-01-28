using System;
using System.Drawing.Text;
using BepInEx.Configuration;
using BepInEx;
using BepInEx.Logging;
using UnityEngine;
using System;
using System.Collections;
using System.Linq;
using System.Xml.Linq;
using BepInEx;
using BepInEx.Configuration;
using Mirror;
using UnityEngine.InputSystem.Utilities;

namespace DinkumAutoSaver 
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    
    public class Plugin : BaseUnityPlugin
    {

        private readonly ConfigEntry<KeyCode> _toggleEnabledHotKey;
        // Hotkey configured to trigger  autosave
        private readonly ConfigEntry<KeyCode> _instantHotKey;
        // Time between saves
        private readonly ConfigEntry<int> _minutesBetweenSaves;
        // If it should automatically start saving.
        private readonly ConfigEntry<bool> _enabled;

        // If its enabled or not
        private bool _isEnabled = true;

        private float _timer;

        public Plugin()
        {
            _enabled = Config.Bind("General", "Enabled", true, "Whether or not the auto save is enabled by default.");
            _instantHotKey = Config.Bind("General", "HotKey", KeyCode.F12, "Key that toggles auto save immediately.");
            _minutesBetweenSaves = Config.Bind("General", "timeBetweenSavesInMinutes", 5, "The time between the saves in minutes.");
            _toggleEnabledHotKey = Config.Bind("General", "toggleEnabledHotKey", KeyCode.F11, "Key that toggles interval auto save on/off");
        }

        public void Start()
        {
            Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");
        }
        
        private void Awake()
        {
            // Plugin startup logic
            Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");
            
        }

        private void Update()
        {
            if (NetworkMapSharer.share.localChar == null)
            {
                _timer = 0; // should reset timer till a user is assigned
                return;
            } 

            if (Input.GetKeyDown(_instantHotKey.Value))
            {
                NotificationManager.manage.createChatNotification($"Instant saving right meow!");
                NetworkPlayersManager.manage.saveButton();
            }

            if (Input.GetKeyDown(_toggleEnabledHotKey.Value))
            {
                 _enabled.Value = !_enabled.Value;
                NotificationManager.manage.createChatNotification($"Autosave is now {(_enabled.Value ? "enabled" : "disabled")}.");
                Config.Save();
            }
            
            if (!_enabled.Value) return; // Not enabled 
            _timer += Time.deltaTime;
            if (!(_timer >= _minutesBetweenSaves.Value * 60)) return;

            NotificationManager.manage.createChatNotification($"Autosaving...");
            NetworkPlayersManager.manage.saveButton();
            _timer = 0;
        }
        
        
    }
}
