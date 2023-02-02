using CodeBase.Infrastructure;
using UnityEditor;
using UnityEngine;

namespace CodeBase.Editor
{
    public class BehaviourTreeWindow : EditorWindow
    {
        private SaveService _saveService;
        private BehaviourTreeInstaller _behaviourTreeInstaller;

        [MenuItem("Window/Behaviour tree")]
        public static void ShowMyEditor()
        {
            EditorWindow window = GetWindow<BehaviourTreeWindow>();
            window.titleContent = new GUIContent("Behaviour tree");
        }
        
        private void CreateGUI()
        {
            _behaviourTreeInstaller = new BehaviourTreeInstaller(Repaint);
            _saveService = new SaveService();
        }

        private void OnGUI()
        {
            _behaviourTreeInstaller.Update();
            _saveService.Save();
        }
    }
}