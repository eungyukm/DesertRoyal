using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TitleScreenManager : VisualElement
{
    private VisualElement _titleScreen;

    private VisualElement _optionScreen;

    private VisualElement _aboutScreen;

    private string sceneName = "Main";
    
    public new class UxmlFactory : UxmlFactory<TitleScreenManager, UxmlTraits>
    {
        
    }
    
    public new class UxmlTraits : VisualElement.UxmlTraits
    {
        private UxmlStringAttributeDescription _startScene = new UxmlStringAttributeDescription()
        {
            name = "start-scene",
            defaultValue = "Main"
        };

        public override void Init(VisualElement ve, IUxmlAttributes bag, CreationContext cc)
        {
            base.Init(ve, bag, cc);
            var sceneName = _startScene.GetValueFromBag(bag, cc);
        }
    }

    public TitleScreenManager()
    {
        RegisterCallback<GeometryChangedEvent>(OnGeometryChange);
    }

    private void OnGeometryChange(GeometryChangedEvent evt)
    {
        _titleScreen = this.Q("TitleScreen");
        _aboutScreen = this.Q ("About");
        
        _titleScreen?.Q("about")?.RegisterCallback<ClickEvent>(ev => EnableAboutScreen());
        _aboutScreen?.Q("back-button")?.RegisterCallback<ClickEvent>(ev => EnableTitleScreen());
    }

    private void Init(string sceneName)
    {
        this.sceneName = sceneName;
    }
    
    void EnableTitleScreen()
    {
        _titleScreen.style.display = DisplayStyle.Flex;
        _aboutScreen.style.display = DisplayStyle.None;
    }
    
    void EnableAboutScreen()
    {
        _titleScreen.style.display = DisplayStyle.None;
        _aboutScreen.style.display = DisplayStyle.Flex;
    }
}
